using Newtonsoft.Json;
using SAI_NETSUITE.Models.Transaccion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAI_NETSUITE.Controllers.Ventas
{
    class PedidoEstatusBOController
    {

        public SalesOrderBOStatusModel regresaInfo(string pedido)
        {

            SAI_NETSUITE.IWS.Connection con = new SAI_NETSUITE.IWS.Connection();
            string json = con.GET("api/SaleOrder/GetExistenceBOByZone?orderId="+pedido, SAI_NETSUITE.Properties.Resources.token);
            SalesOrderBOStatusModel list = JsonConvert.DeserializeObject<SalesOrderBOStatusModel>(json);
            return list;
        }

        public string regresaInfoWMS(string pedido,string tipo)
        {
            string resultado = "";
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1))
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText = @"Declare  @EstatusIWS  nvarchar(30),
		                                     @EstatusWMS nvarchar(35),
		                                     @Pedido int 

		                                     set @Pedido="+pedido+ @"

                                      if exists(select IdOrdenEmbarque from INDAR_INACTIONWMS.dbo.OrdenEmbarque where  NumPedido=@Pedido and Mov='salesorder')
		                                    BEGIN 
			                                    select @EstatusWMS=EOE.Nombre from INDAR_INACTIONWMS.dbo.OrdenEmbarque OE 
				                                    INNER JOIN INDAR_INACTIONWMS.DBO.EstatusOrdenEmbarque EOE on OE.IdEstatusOrdenEmbarque=EOE.IdEstatusOrdenEmbarque
				                                    WHERE OE.NumPedido=@Pedido and Mov='salesorder'
				                                    select @EstatusWMS

		                                    END
		                                    ELSE
			                                    BEGIN
				                                   IF exists(select tranId from iws.dbo.SaleOrders where    tranId=@Pedido )
					                                         BEGIN
															if exists(select  tranid from iws.dbo.SaleOrders where CONVERT(DATE,trandate)=CONVERT(Date,GETDATE()) AND tranId=@Pedido and unificado is null)
																	begin
																			set @EstatusIWS='Espera 5 min a que ingrese a WMS'
																			select @EstatusIWS
																	end
															else IF EXISTS(SELECT TRANID FROM IWS.dbo.SaleOrders WHERE tranId=@Pedido AND unificado=1)
																		begin
																					 select @EstatusWMS=EOE.Nombre from INDAR_INACTIONWMS.dbo.OrdenEmbarque OE 
																					INNER JOIN INDAR_INACTIONWMS.DBO.EstatusOrdenEmbarque EOE on OE.IdEstatusOrdenEmbarque=EOE.IdEstatusOrdenEmbarque
																					WHERE   Mov='cotizacion' and  OE.NumPedido=(SELECT cotizacion FROM IWS.dbo.SaleOrders WHERE tranId=@Pedido AND unificado=1) collate  Modern_Spanish_CI_AI 
																					select @EstatusWMS
																		end 	
															else		
																		begin
																			  set @EstatusWMS='ES_BO'
																	   SELECT @EstatusWMS
																	 end
															 END
				                                    ELSE 
					                                    Begin
					                                     SET @EstatusIWS='No esta ingresado a IWS'
					                                     select @EstatusIWS
					                                    END
			                                    END";

                
                resultado = cmd.ExecuteScalar().ToString();
              

            }
            return resultado;

                

        }
        public string regresaInfoWMS2(string pedido, string tipo)
        {
            string resultado = "";
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1))
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText = @"Declare  @EstatusIWS  nvarchar(30),
		                                     @EstatusWMS nvarchar(35),
		                                     @Pedido int 

		                                     set @Pedido="+pedido+ @"

                                      if exists(select IdOrdenEmbarque from INDAR_INACTIONWMS.dbo.OrdenEmbarque where  NumPedido=@Pedido and Mov='salesorder')
		                                    BEGIN 
			                                    select @EstatusWMS=EOE.Nombre from INDAR_INACTIONWMS.dbo.OrdenEmbarque OE 
				                                    INNER JOIN INDAR_INACTIONWMS.DBO.EstatusOrdenEmbarque EOE on OE.IdEstatusOrdenEmbarque=EOE.IdEstatusOrdenEmbarque
				                                    WHERE OE.NumPedido=@Pedido and Mov='salesorder'
				                                    select @EstatusWMS

		                                    END
		                                    ELSE
			                                    BEGIN
														if exists(select tranId from iws.dbo.SaleOrders where   syncWMS is null and  tranId=@Pedido )
																 BEGIN
																if exists(select  tranid from iws.dbo.SaleOrders where CONVERT(DATE,trandate)=CONVERT(Date,GETDATE()) AND tranId=@Pedido and unificado is null)
																begin
																		set @EstatusIWS='No esta ingresado a WMS'
																		select @EstatusIWS
																end
																else 
																	begin
																		   set @EstatusWMS='No esta ingresado a WMS'
																		   SELECT @EstatusWMS
																   end
																 END
														ELSE 
															Begin
																	 SET @EstatusIWS='No esta ingresado a IWS'
																	 select @EstatusIWS
															END
			                                    END";


                resultado = cmd.ExecuteScalar().ToString();
                /*if (resultado.Equals("Espera 5 min a que ingrese a W") && tipo.Equals("BO"))
                    resultado = "Cambiar el Pedido a Web";*/


            }
            return resultado;



        }
        public void actualizaRenglon(string txtNumpedido, string itemid, int quantity)
        {
            using (IWSEntities ctx = new IWSEntities())
            {
                int pedido = Convert.ToInt32(txtNumpedido);
                var pedidoDetail = from so in ctx.SaleOrders
                                   join sod in ctx.SaleOrdersDetails on so.internalId equals sod.saleOrderId
                                   where so.tranId==pedido  && sod.itemId==(itemid)
                                   select sod;

                pedidoDetail.First().quantity = quantity;
                pedidoDetail.First().backOrdered = 0;
                ctx.SaveChanges();
                
            }
        }

        public void insertaPedidoWMS(string text)
        {
            try
            {
                using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1))
                {
                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand("", myConnection);
                    cmd.CommandText = @" declare @id int 
                                    set @id=" + text + @"  

                                    INSERT INTO INDGDLSQL01.INDAR_INACTIONWMS.int.pedido (id, mov, movid ,fechaEmision, cliente, horaEmision ,formaEnvio, lugarEnvio, fletera ,fechaIngreso, fechaActualizacion, estatusSincronizacion ,fechaEntrega)

                                    SELECT so.internalid,'salesorder',tranid,trandate,companyId,GETDATE(),FO.LIST_ITEM_NAME AS FORMAENVIO,SUBSTRING(isnull(ad.addr1, '') + '' + isnull(ad.addr2, '') + ' ' + isnull(ad.city, '') + ' ' + isnull(ad.state, '') + ' ' + isnull(ad.postalCode, ''), 1, 100),p.LIST_ITEM_NAME as fletera, null,null,0,null FROM IWs.dbo.SaleOrders SO

                                    LEFT JOIN  IWS.DBO.Customers C ON SO.idCustomer = C.internalid

                                    INNER JOIN iws.dbo.FormaEnvio FO on so.shippingWay = fo.LIST_ID

                                    inner join iws.dbo.Address AD on so.shippingAddress = ad.addressID

                                    LEFT JOIN IWS.DBO.Paqueteria P ON SO.package = P.LIST_ID

                                    where so.tranId = @id



                                    INSERT INTO INDGDLSQL01.INDAR_INACTIONWMS.int.pedidodetalle(id, articulo, cantidad, fechaIngreso, fechaActualizacion, estatusSincronizacion)

                                    SELECT saleOrderId, i.itemid,sum(SOD.quantity),null,null,0 FROM IWS.DBO.SaleOrdersDetails SOD

                                    left join iws.dbo.Items I ON SOD.itemId = I.id 
					                left join iws.dbo.SaleOrders SO on SOD.saleOrderId=SO.internalId
                                    WHERE sod.quantity > 0 and SO.tranId = @id

                                    group by saleOrderId,i.itemid


                                    update  iws.dbo.SaleOrders set syncWMS = 1,fechaactualizacion = getdate() where tranid = @id";

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
