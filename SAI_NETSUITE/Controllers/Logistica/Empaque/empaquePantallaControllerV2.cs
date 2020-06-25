using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.LookAndFeel;
using DevExpress.XtraReports.UI;
using Newtonsoft.Json;
using SAI_NETSUITE.Controllers.IWS;
using SAI_NETSUITE.Models.Catalogos;
using SAI_NETSUITE.Models.Transaccion;
using SAI_NETSUITE.Views.Logistica.Empaque;

namespace SAI_NETSUITE.Controllers.Logistica.Empaque
{
    class empaquePantallaControllerV2
    {
        public DataSet cargaDatos()
        {
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1))
            {
                string query = @"exec  indarneg.dbo.spEmpaquePantallaNetsuiteV2";
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;


            }
        }

        public List<pedidoFulfill> regresaPedidosEnCons(string v,string formaEnvio)
        {
            List<pedidoFulfill> lista = new List<pedidoFulfill>();
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1))
            {
                string query = @"select mov,NumPedido,FormaEnvio from INDAR_INACTIONWMS.dbo.OrdenEmbarque where Consolidado='" + v+"'";
                myConnection.Open();
                SqlCommand cmd = new SqlCommand(query, myConnection);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read() & sdr.HasRows)
                {
                    pedidoFulfill p = new pedidoFulfill()
                    {
                        mov = sdr.GetValue(0).ToString(),
                        movid = sdr.GetValue(1).ToString(),
                        cons=v,
                        formaEnvio=formaEnvio
                        
                    };

                    lista.Add(p);

                }
                myConnection.Close();
            }
            return lista;
        }

        public string regresaNumFactura(string pedido)
        {
            /*  string query = @"if exists (select TranId from iws.dbo.Invoices where createdfrom =(select internalId from iws.dbo.SaleOrders where tranid=" + pedido + @")) --and (status='Open' or status is null))
                              select TranId from iws.dbo.Invoices where createdfrom = (select internalId from iws.dbo.SaleOrders where tranid = " + pedido + @") --and (status='Open' or status is null)
                              ELSE PRINT 'NO'";
                              */
            string query = @"if exists (select TranId from iws.dbo.Invoices where createdfrom =(select internalId from iws.dbo.SaleOrders where tranid=" + pedido + @")) --and (status='Open' or status is null))
                     select case when (CfdiComentario is not null and CfdiComentario<>'') 
	                    then
	                    --INICIO DE  DETECTAR ERRORES DE CFDI
                      CASE WHEN CfdiComentario LIKE '%CFDI33132%' THEN 'Error de RFC, CREDITO Y COBRANZA CFDI33132'
                      WHEN CfdiComentario LIKE '%CFDI33134%' THEN 'Error de RFC, CREDITO Y COBRANZA CFDI33134'
                      WHEN CfdiComentario LIKE '%CFDI33137%' THEN 'Error de RFC, CREDITO Y COBRANZA CFDI33134'
                        WHEN CfdiComentario LIKE '%ClaveProdServ%' THEN 'Error de Articulo, Compras corregir claveprodserv'
	                        else CONVERT(varchar(8),tranid)+' '+  CONVERT(varchar(150),ResponseCfdi) 
                         END 
  
                      else  CONVERT(varchar(10),TranId) end  from iws.dbo.Invoices where createdfrom = (select internalId from iws.dbo.SaleOrders where tranid =" + pedido + @") --and (status='Open' or status is null)
                      ELSE PRINT 'NO'";
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand(query, myConnection);
                var resultado = cmd.ExecuteScalar();
                if (resultado != null && !resultado.ToString().Equals("NO"))
                    return "TIMBRAR: " + resultado.ToString();
                else return "TIMBRAR CFDI";
            }
        }

        public string fulfillmentToInvoice(pedidoFulfill pedido)
        {

            string query = @"select SO.internalId,'' as transactionnumber,I.id,FO.CantidadesSurtidas from  IWS.dbo.SaleOrders SO
                        LEFT JOIN INDAR_INACTIONWMS.int.Facturar_Out  FO on Movimiento='salesorder' COLLATE Modern_Spanish_CI_AI and MovId=so.tranid
                        LEFT JOIN IWS.dbo.Items I on FO.Articulo=I.itemid COLLATE Modern_Spanish_CI_AI
                        WHERE FO.Movimiento='" + pedido.mov + "' and FO.MovId=" + pedido.movid;
            Console.WriteLine(query);
            ItemFullfilmentModel iffm = new ItemFullfilmentModel();
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand(query, myConnection);
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Line> list = new List<Line>();
                bool primeravez = true;

                while (sdr.Read() && sdr.HasRows)
                {
                    if (primeravez)
                    {
                        Createdfrom createdfrom = new Createdfrom();
                        createdfrom.id = sdr.GetValue(0).ToString();
                        createdfrom.recordType = "salesorder";
                        iffm.createdfrom = createdfrom;
                        iffm.shipcountry = "MX";
                        Shipstatus shipstatus = new Shipstatus();
                        shipstatus.value = "C";
                        shipstatus.txt = "Shipped";
                        iffm.shipstatus = shipstatus;
                        primeravez = false;
                    }
                    Line line = new Line();
                    line.itemId = sdr.GetValue(2).ToString();
                    line.location = "1";
                    line.quantity = sdr.GetValue(3).ToString();
                    list.Add(line);



                }
                iffm.lines = list;
                if (iffm.lines.Count < 1)
                {
                    pedido.error = "No esta en FacturarOut";
                    responseJson rs = new responseJson();
                    rs.responseStructure.codeStatus = "NOK";
                    rs.responseStructure.descriptionStatus = "No esta en FacturarOut";
                    return JsonConvert.SerializeObject(rs);
                }

            }
            string json = JsonConvert.SerializeObject(iffm, Newtonsoft.Json.Formatting.Indented);
            Connection connection = new Connection();
            string resultado = connection.POST("api/Invoice/fulfillmentToInvoice", json, SAI_NETSUITE.Properties.Resources.token, true);
            return resultado;
        }

        public void registraError(pedidoFulfill pedido, string descriptionStatus)
        {
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1)) 
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                 cmd.CommandText = @"insert into iws.dbo.errorfulfillmentv2 (mov,movid,error,fecha)
                                    values (@mov,@movid,@error,getdate())";
                cmd.Parameters.AddWithValue("@mov", pedido.mov);
                cmd.Parameters.AddWithValue("@movid", pedido.movid);
                cmd.Parameters.AddWithValue("@error", descriptionStatus);
                cmd.ExecuteNonQuery();
                myConnection.Close();
            };
        }

        public void ImprimeFactura(string error, bool porTranID,pedidoFulfill pedidoOrigen,int copias)
        {
            try
            {
                int tranid = 0;
                if (!porTranID)
                {
                    using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
                    {
                        myConnection.Open();
                        string query = @"select tranid from iws.dbo.Invoices where internalid=" + error;// -- where createdfrom =(select internalId from iws.dbo.SaleOrders where tranid=" + error + @") --and (status='Open' or status is null)";
                        SqlCommand cmd = new SqlCommand(query, myConnection);
                        tranid = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    };
                }
                else tranid = Convert.ToInt32(error);

                Controllers.Logistica.Empaque.FacturaIndarController fic = new Controllers.Logistica.Empaque.FacturaIndarController();
                DataSet ds = fic.regresaDatosCabecera(tranid);
                // ds.WriteXmlSchema(@"S:\XML\Almacen\FacturaIndarSinTimbrar.xml");
                Views.Logistica.Empaque.FacturaIndar fi = new FacturaIndar();
                fi.DataSource = ds;
                using (ReportPrintTool printTool = new ReportPrintTool(fi))
                {


                    //                    printTool.ShowRibbonPreviewDialog();
                    printTool.PrinterSettings.Copies =(short) copias;
                    printTool.Print();

                

                }
            }
            catch (Exception ex)
            {
                registraError(pedidoOrigen, "No hay Factura en IWS");
            }

        }

        public void ReglasImprimir(pedidoFulfill pedidoFulfill)
        {
            if (pedidoFulfill.formaEnvio.ToUpper().Contains("OFICINA"))
                ImprimeFactura(pedidoFulfill.error, false, pedidoFulfill, 3);
            else ImprimeFactura(pedidoFulfill.error, false, pedidoFulfill, 2);
            pdfController pdc = new pdfController();
            if (!pedidoFulfill.formaEnvio.ToUpper().Contains("CLIENTE")|| !pedidoFulfill.formaEnvio.ToUpper().Contains("EMPLEADO"))
                pdc.imprimePDFyPackingV2(pedidoFulfill.error, "2");
            if (pedidoFulfill.formaEnvio.ToUpper().Contains("FLETERA") || pedidoFulfill.formaEnvio.ToUpper().Contains("OFICINA"))
                pdc.imprimePDFyPackingV2(pedidoFulfill.error, "1");


        }

        public void ReglasImprimirCons(string cons, List<pedidoFulfill> list)
        {
            string FORMAENVIO = list[0].formaEnvio;
            foreach (var pedido in list)  //PRIMERO  SE IMPRIMEN LAS FACTURAS QUE CONFORMAN  LA CONS
            {
                if (pedido.formaEnvio.ToUpper().Contains("OFICINA"))
                    ImprimeFactura(pedido.error, false, pedido, 3);
                else ImprimeFactura(pedido.error, false, pedido, 2);
            }
            //  pc.imprimePDFyPackingCons(cons, "2");
            // pc.imprimePDFyPackingCons(cons, "1");
            pdfController pdc = new pdfController();
            if (!FORMAENVIO.ToUpper().Contains("CLIENTE") || !FORMAENVIO.ToUpper().Contains("EMPLEADO"))
                pdc.imprimePDFyPackingCons(cons, "2");
            if (FORMAENVIO.ToUpper().Contains("FLETERA") || FORMAENVIO.ToUpper().Contains("OFICINA"))
                pdc.imprimePDFyPackingCons(cons, "1");

        }

        public string EsTimbrada(string error, string numpedido)
        {
            string query = "";
            var resultado = "";
            SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            if (numpedido.Contains("Cons"))
            {
                query= @"  DECLARE @SUMA INT
                              DECLARE @TOTAL INT
                              SELECT @SUMA=sum(UUID),@TOTAL=COUNT(NumPedido) FROM (
                              select NumPedido, case when UUID='0' then 0
                                                     when UUID='' then 0   else 1 end as uuid from (
                              select 
                              MOV,
                              NumPedido,
                              UUID= isnull((SELECT top 1 UUID FROM IWS.DBO.Invoices WHERE createdfrom =(SELECT  internalId FROM IWS.DBO.SaleOrders WHERE tranId=NumPedido) AND status NOT IN ('Voided') order by internalId desc),'0')
  
                                from INDAR_INACTIONWMS.dbo.OrdenEmbarque  where  IdEstatusOrdenEmbarque=6 and Consolidado='" + numpedido + @"'
                             ) as q) AS q2
                             SELECT @TOTAL-@SUMA  
                                 begin 
							 update OE  set FacturaIndar=I.TranId,OE.FechaFactura=GETDATE()  FROM INDAR_INACTIONWMS.DBO.OrdenEmbarque OE
																INNER JOIN  IWS.DBO.SaleOrders SO ON OE.IdPedido=SO.internalId
																INNER JOIN IWS.DBO.Invoices I ON SO.internalId=I.createdfrom
																WHERE OE.Consolidado='" + numpedido+@"'

							 end
                            ";
            }
            else
            {
                query = @"if exists(select * from iws.dbo.Invoices I 
                                    inner join iws.dbo.SaleOrders SO on i.createdfrom = so.internalId
                                    where LEN(i.UUID) > 5  and so.tranId = "+numpedido+@")
			                        BEGIN
                                        DECLARE @idFactura int
                                        select   @idFactura = i.TranId from iws.dbo.Invoices I  
                                          inner  join iws.dbo.SaleOrders SO on i.createdfrom = so.internalId
                                          where LEN(i.UUID) > 5  and so.tranId = "+numpedido+@"
                                         update INDAR_INACTIONWMS.dbo.OrdenEmbarque set FacturaIndar = @idFactura where mov = 'salesorder' and NumPedido = "+numpedido+@"
                                         select 'OK'
                                    END
                            ELSE
                                    BEGIN
                                            select 'NO'
                                    END";
            }
            cmd.CommandText = query;
            resultado = cmd.ExecuteScalar().ToString();
            myConnection.Close();
            myConnection.Dispose();
            if (resultado.ToString().Equals("OK")|| resultado.ToString().Equals("0"))
                return  "TERMINADO";
            else return error;

        }

       

        public string regresaInfoConsSinTimbrar(string v)
        {

            var resultado = "TIMBRAR: ";
            /*string query = @"select error = isnull((select top 1 error from iws.dbo.errorFulFillment where error like '%result%' and  movid = NumPedido collate Modern_Spanish_CI_AS order by fecha desc),'Hablar a Sistemas 400')
                              from indar_inactionwms.dbo.OrdenEmbarque where   IdEstatusOrdenEmbarque=6 and Consolidado = '" + v + "'";*/
            string query = @"		select  hola=stuff	(( select ','+CONVERT(NVARCHAR(15), i.TranId) FROM INDAR_INACTIONWMS.DBO.OrdenEmbarque OE
																INNER JOIN  IWS.DBO.SaleOrders SO ON OE.IdPedido=SO.internalId
																INNER JOIN IWS.DBO.Invoices I ON SO.internalId=I.createdfrom
																WHERE OE.Consolidado='"+v+@"'
																FOR XML PATH ('')
																),1,1,'')";
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {/*
                myConnection.Open();
                SqlCommand cmd = new SqlCommand(query, myConnection);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read() && sdr.HasRows)
                {
                    respuesta respues = new respuesta();
                    respues = JsonConvert.DeserializeObject<respuesta>(sdr.GetValue(0).ToString());
                    int ans;
                    if (Int32.TryParse(respues.result.ToString(), out ans))
                    {

                        resultado = resultado + regresaFacturaPorID(respues.result.ToString()) + ",";//respues.result.ToString()+",";
                    }

                }

                */
                myConnection.Open();
                SqlCommand cmd = new SqlCommand(query, myConnection);
                resultado = "Timbrar" + cmd.ExecuteScalar().ToString();
                myConnection.Close();
            }
            return resultado;
        }

        public string regresaFacturaPorID(string id)
        {
            using (SqlConnection myConection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                myConection.Open();
                string query = @"select tranid from iws.dbo.invoices where internalid=" + id;
                SqlCommand cmd = new SqlCommand(query, myConection);
                var resultado = cmd.ExecuteScalar().ToString();
                if (!resultado.Equals(""))
                    return resultado;
                else return "##";
            }
        }


        public string regresaIDdeFactura(string tranid)
        {
            using (SqlConnection myConection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                myConection.Open();
                string query = @"select internalid from iws.dbo.invoices where tranid=" + tranid;
                SqlCommand cmd = new SqlCommand(query, myConection);
                var resultado = cmd.ExecuteScalar().ToString();
                if (!resultado.Equals(""))
                    return resultado;
                else return "##";
            }
        }


    }
}
