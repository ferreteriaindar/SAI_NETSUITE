using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SAI_NETSUITE.Models.Catalogos;
using SAI_NETSUITE.Models.Transaccion;

namespace SAI_NETSUITE.Controllers.Ventas
{
    class CancelarPedidoController
    {
        public SaleOrderCancelSearchModel regresaInfo(string tranid)
        {
            SAI_NETSUITE.IWS.Connection con = new SAI_NETSUITE.IWS.Connection();
            string json = con.GET("api/SaleOrder/GetSaleOrderCancelSearch?tranid=" + tranid, SAI_NETSUITE.Properties.Resources.token);
            SaleOrderCancelSearchModel list = JsonConvert.DeserializeObject<SaleOrderCancelSearchModel>(json);
            return list;
        }

        public string regresaInfoWMS(string tranid)
        {
            string query = @"if exists (select internalId from iws.dbo.SaleOrders where tranid="+tranid+@") 
	                            BEGIN
		                            IF exists(select numpedido from INDAR_INACTIONWMS.dbo.OrdenEmbarque where mov='salesorder' and numpedido="+tranid+ @" )
			                            BEGIN
				                            select EOE.Nombre+ISNULL(OE.Consolidado,'') as resultado from INDAR_INACTIONWMS.dbo.OrdenEmbarque OE 
						                            INNER JOIN  INDAR_INACTIONWMS.DBO.EstatusOrdenEmbarque EOE ON OE.IdEstatusOrdenEmbarque=EOE.IdEstatusOrdenEmbarque
						                            where MOV='salesorder' AND  numpedido=" + tranid+ @" 
			                            END
                                      ELSE
										BEGIN
										  select 'No Ingresado' as resultado
										END
	                            END                        
                            ELSE
	                            BEGIN 
	                            select 'No Ingresado' as resultado
	                            END";

            SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand(query, myConnection);
            return cmd.ExecuteScalar().ToString();
        }

        public string CancelarPedido(string tranid,string status, SaleOrderCancelSearchModel scms,string usuario,string wms)
        {
            var resultadoWMS = "";
            if (!status.Equals("Aprobacion Pendiente") && !wms.Equals("No Ingresado"))
            {
                SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1);
                string query = @"if exists (select * from iws.dbo.SaleOrders where tranid="+tranid+@")
		                            update iws.dbo.SaleOrders set syncwms=1 where tranid="+tranid+@"
                                if exists(select NumPedido from INDAR_INACTIONWMS.dbo.OrdenEmbarque where IdEstatusOrdenEmbarque=0 and NumPedido=" + tranid + @")
		                        BEGIN 
			                        DECLARE  @idOrdenembarque int 
			                        select @idOrdenembarque=IdOrdenEmbarque from INDAR_INACTIONWMS.dbo.OrdenEmbarque where  consolidado is null and  mov='salesorder' and NumPedido=" + tranid + @"
			                        exec INDAR_INACTIONWMS.dbo.spOrdenEmbarqueCancelar @idOrdenembarque,2;
			                        SELECT 'OK' AS resultado
		                        END
                        ELSE
		                        BEGIN 
		                        SELECT 'ERROR YA NO SE PUEDE CANCELAR EN WMS' AS resultado
		                        END";
                myConnection.Open();
                SqlCommand cmd = new SqlCommand(query, myConnection);
                resultadoWMS = cmd.ExecuteScalar().ToString();
            }
            else resultadoWMS = "OK";
            if (resultadoWMS.ToString().Equals("OK"))
            {
                int spedido = scms.result.Resultados.Documentos.Where(y=> y.custitem_categoria_articulo.Equals("S/PEDIDO")). Select(x => x.custitem_categoria_articulo.Equals("S/PEDIDO")).Count();
                //AHORA SE CANCELA A NETSUITE.
                CancelSaleOrdeModel csom = new CancelSaleOrdeModel()
                {
                    apoyo = scms.result.Resultados.Documentos[0].custrecord_apoyo_ventas,
                    //compras=scms.result.Resultados.Documentos[0].
                    saleOrderID = scms.result.Resultados.Documentos[0].internalid,
                    usuario = usuario,
                    vendedor = scms.result.Resultados.Documentos[0].custrecord_representante_vtas,
                    compras = spedido>0&& status!= "Aprobacion Pendiente" ? 1 : 0

                };
                SAI_NETSUITE.IWS.Connection con = new SAI_NETSUITE.IWS.Connection();
                string json = con.POST("api/SaleOrder/SaleOrderCancel",JsonConvert.SerializeObject(csom), SAI_NETSUITE.Properties.Resources.token);
                respuestaIWScs response = JsonConvert.DeserializeObject<respuestaIWScs>(json);
                if (response.result.responseStructure.codeStatus.Equals("OK"))
                    return "OK";
                else return "error " + response.result.responseStructure.descriptionStatus;



                
            }
            else return "Error ya no se puede cancelar en WMS";

        }
    }
}
