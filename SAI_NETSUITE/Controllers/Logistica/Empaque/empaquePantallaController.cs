using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using SAI_NETSUITE.Models.Transaccion;
using Newtonsoft.Json;
using SAI_NETSUITE.Controllers.IWS;
using SAI_NETSUITE.Models.Catalogos;
using System.IO;
using System.ComponentModel;

namespace SAI_NETSUITE.Controllers.Logistica.Empaque
{
    class empaquePantallaController
    {

        public DataSet regresaInfo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString);
                string query = "exec  indarneg.dbo.spEmpaquePantallaNetsuite";
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al cargar pantalla principal");
                DataSet ds = new DataSet();
                return ds;
            }

        }

        public List<pedidoFulfill> listadoCons(string consolidad0)
        {
            List<pedidoFulfill> listado = new List<pedidoFulfill>();
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString)) 
            {
                myConnection.Open();
                string query = @"select mov,NumPedido from indar_inactionwms.dbo.OrdenEmbarque where  IdEstatusOrdenEmbarque=6 and   Consolidado='" + consolidad0 + "'";
                SqlCommand cmd = new SqlCommand(query, myConnection);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read() && sdr.HasRows)
                {
                    pedidoFulfill pf = new pedidoFulfill();
                    pf.mov = sdr.GetValue(0).ToString();
                    pf.movid = sdr.GetValue(1).ToString();
                    listado.Add(pf);
                }
            }

            return listado;
        }

        public string regresaNumFactura(string mov, string pedido)
        {
            string query = @"if exists (select TranId from iws.dbo.Invoices where createdfrom =(select internalId from iws.dbo.SaleOrders where tranid=" + pedido+ @")) --and (status='Open' or status is null))
                            select TranId from iws.dbo.Invoices where createdfrom = (select internalId from iws.dbo.SaleOrders where tranid = " + pedido+ @") --and (status='Open' or status is null)
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

        public string  regresaInfoConsSinTimbrar(string v)
        {
            string resultado = "TIMBRAR: ";
            string query = @"select error = isnull((select top 1 error from iws.dbo.errorFulFillment where error like '%result%' and  movid = NumPedido collate Modern_Spanish_CI_AS order by fecha desc),'Hablar a Sistemas 400')
                              from indar_inactionwms.dbo.OrdenEmbarque where   IdEstatusOrdenEmbarque=6 and Consolidado = '" + v+"'";
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
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
        public string  YaestaTimbradaCons(string cons)
        {
            string query = @"  DECLARE @SUMA INT
                              DECLARE @TOTAL INT
                              SELECT @SUMA=sum(UUID),@TOTAL=COUNT(NumPedido) FROM (
                              select NumPedido, case when UUID='0' then 0
                                                     when UUID='' then 0   else 1 end as uuid from (
                              select 
                              MOV,
                              NumPedido,
                              UUID= isnull((SELECT top 1 UUID FROM IWS.DBO.Invoices WHERE createdfrom =(SELECT  internalId FROM IWS.DBO.SaleOrders WHERE tranId=NumPedido) AND status NOT IN ('Voided') order by internalId desc),'0')
  
                                from INDAR_INACTIONWMS.dbo.OrdenEmbarque  where  IdEstatusOrdenEmbarque=6 and Consolidado='" + cons+@"'
                             ) as q) AS q2
                             SELECT @TOTAL-@SUMA";
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand(query, myConnection);
                var resultado = cmd.ExecuteScalar().ToString();
                myConnection.Close();
                if (resultado.ToString().Equals("0"))
                    return "Imprime " + cons;
                else return "Timbra las Facturas";
            };
        }

        public string YaestaTimbrada(string mov, string pedido,string valorArterior)
        {
            string query = @"if exists (select internalid from iws.dbo.Invoices where createdfrom =(select internalId from iws.dbo.SaleOrders where tranid=" + pedido + @") and LEN(uuid) >5 )
                            select tranid from iws.dbo.Invoices where createdfrom = (select internalId from iws.dbo.SaleOrders where tranid = " + pedido + @")
                            ELSE PRINT 'NO'";
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand(query, myConnection);
                var resultado = cmd.ExecuteScalar();
                if (resultado != null && !resultado.ToString().Equals("NO"))
                    return "Imprime factura" + resultado.ToString();
                else return valorArterior;
            }
           
        }

        public pedidoFulfill fulfillment(pedidoFulfill pedido, System.ComponentModel.BackgroundWorker bw)
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
                if (iffm.lines.Count <1)
                {
                    pedido.error = "No esta en FacturarOut";
                    return pedido;
                }
                  
            }
             string  json = JsonConvert.SerializeObject(iffm, Formatting.Indented);
            Connection connection = new Connection();
            string resultado = connection.POST("api/Inventory/ItemFullfilment", json, SAI_NETSUITE.Properties.Resources.token,true);
                      
            pedido.error = resultado;

            respuesta result = new respuesta();
            result.result = pedido.error;
            if (result.result.Contains("true"))
            {
                bw.ReportProgress(2);
                SaleOrderToInvoiceModel sotim = new SaleOrderToInvoiceModel();
                sotim.salesOrderInternalId = iffm.createdfrom.id.ToString();
                string jsonBill = JsonConvert.SerializeObject(sotim, Formatting.Indented);
                string resultadoBill = connection.POST("api/Invoice/CreateInvoice", jsonBill, SAI_NETSUITE.Properties.Resources.token,true);
                pedido.error = resultadoBill;
            }

                return pedido;
        }

        public string regresaIdFactura(string text)
        {
            int n;
            if (int.TryParse(text, out n))
            {
                using (IWSEntities ctx = new IWSEntities())
                {
                    var idFactura = (from i in ctx.Invoices
                                     where i.TranId.Equals(n)
                                     select i.internalId).FirstOrDefault();
                    if (idFactura != null)
                        return idFactura.ToString();
                    else return "error";

                };
            }
            else return "error";
        }

        public void ImprimirPackingCons(string cons, string tipo)
        {
            pdfController pc = new pdfController();
            pc.imprimePDFyPackingCons(cons, tipo);
        }

        public void ImprimirDirecto(string pedido,string tipo, bool CONS,bool reimprimir)
        {
            int internalID=0;
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                myConnection.Open();
                string query = @"select internalid from iws.dbo.Invoices where createdfrom =(select internalId from iws.dbo.SaleOrders where tranid=" + pedido + @") --and (status='Open' or status is null)";
                if (reimprimir)
                    query = @"select internalid from iws.dbo.Invoices where tranid=" + pedido;
                SqlCommand cmd = new SqlCommand(query, myConnection);
                internalID = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            };

             byte [] pdf=GetPDF(internalID);

            MemoryStream ms = new MemoryStream(pdf);
            var pdfViewer2 = new DevExpress.XtraPdfViewer.PdfViewer();
            pdfViewer2.LoadDocument(ms);
            pdfViewer2.Print();
            pdfController pdfc = new pdfController();
            if (!CONS && !reimprimir)
            {
                pdfc.imprimePDFyPacking(internalID.ToString(), "2");
                pdfc.imprimePDFyPacking(internalID.ToString(), "1");
            }
            

           
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                myConnection.Open();
                string query = @" update INDAR_INACTIONWMS.dbo.OrdenEmbarque
                                      set FacturaIndar=( select TranId from iws.dbo.Invoices where createdfrom =(select internalId from iws.dbo.SaleOrders where tranid="+pedido+@"))
                                      ,FechaFactura=GETDATE()
                                        where NumPedido="+pedido;
                SqlCommand cmd = new SqlCommand(query, myConnection);
                //internalID = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                cmd.ExecuteScalar();

            };
            

        }

        public bool fulfillmentTraspaso(pedidoFulfill pedido, BackgroundWorker backgroundWorker)
        {
            string query = @"    SELECT (select top 1 IdPedido from INDAR_INACTIONWMS.dbo.OrdenEmbarque where mov='Traspaso' and NumPedido=" + pedido.movid + @" order by IdOrdenEmbarque desc),
	                            I.id,fo.CantidadesSurtidas	
	                             FROM INDAR_INACTIONWMS.INT.Facturar_Out  FO
	                            INNER JOIN IWS.DBO.Items I  on fo.Articulo=i.itemid collate Modern_Spanish_CI_AI
	                             where FO.Movimiento='" + pedido.mov + "' and fo.MovId=" + pedido.movid;
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
                        createdfrom.recordType = "transferorder";
                        iffm.createdfrom = createdfrom;
                        iffm.shipcountry = "MX";
                        Shipstatus shipstatus = new Shipstatus();
                        shipstatus.value = "C";
                        shipstatus.txt = "Shipped";
                        iffm.shipstatus = shipstatus;
                        primeravez = false;
                    }
                    Line line = new Line();
                    line.itemId = sdr.GetValue(1).ToString();
                    line.location = "1";
                    line.quantity = sdr.GetValue(2).ToString();
                    list.Add(line);

                }
                iffm.lines = list;
                if (iffm.lines.Count < 1)
                {
                    pedido.error = "No esta en FacturarOut";
                    return false;
                }

            }
            string json = JsonConvert.SerializeObject(iffm, Formatting.Indented);
            Connection connection = new Connection();
            string resultado = connection.POST("api/Inventory/ItemFullfilment", json, SAI_NETSUITE.Properties.Resources.token, true);

            pedido.error = resultado;

            respuesta result = new respuesta();
            result.result = pedido.error;
            if (result.result.Contains("true"))
            {
                SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1);
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText = "	 update  INDAR_INACTIONWMS.dbo.OrdenEmbarque set FacturaIndar=1 where Mov='Traspaso' and NumPedido=" + pedido.movid;
                cmd.ExecuteNonQuery();
                return true;
            }
            else return false;
        }

        public byte[] GetPDF(int v)
        {
            Connection connection = new Connection();
            UpdateInvoiceModel UIM = new UpdateInvoiceModel();
            UIM.internalId = v;
        
            string json = JsonConvert.SerializeObject(UIM, Formatting.Indented);
            string resultado = connection.POST("api/Invoice/GetPDF", json, SAI_NETSUITE.Properties.Resources.token, true);
            respuesta r = JsonConvert.DeserializeObject<respuesta>(resultado);
            
            byte[] sPDFDecoded = Convert.FromBase64String(r.result);
            return sPDFDecoded;

        }

        public void insertaErrorFulfilment(pedidoFulfill pedido)
        {
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText = @"insert into iws.dbo.errorfulfillment (mov,movid,error,fecha)
                                    values (@mov,@movid,@error,@fecha)";
                cmd.Parameters.AddWithValue("@mov", pedido.mov);
                cmd.Parameters.AddWithValue("@movid", pedido.movid);
                if (pedido.error.Contains("400"))
                    cmd.Parameters.AddWithValue("@error", "Hablar a Sistemas 400");
                else if (pedido.error.Contains("-1"))
                    cmd.Parameters.AddWithValue("@error", "Error crear Factura");
                else
                {
                    respuesta result = new respuesta();
                    result.result = pedido.error;
                    cmd.Parameters.AddWithValue("@error", result.result);
                }
                cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
//values(@" + pedido.mov + "," + pedido.movid.ToString() + ",'" + pedido.error + "',getdate())";
                cmd.ExecuteNonQuery();

            }
        }

        public string regresaErrorPedido(string mov, string movid)
        {
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                Models.Catalogos.respuesta respues = new respuesta();
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);

                // cmd.CommandText= "select top 1 error from iws.dbo.errorfulfillment where  mov='" + mov + "' and movid='" + movid + "' order by fecha desc";
                cmd.CommandText = @"if exists(select error  from iws.dbo.errorfulfillment where  mov='" + mov + "' and movid='" + movid + @"' and error like '%result%')
                                            select top 1 error from iws.dbo.errorfulfillment where  mov='"+mov+@"' and movid='"+movid+@"'   and error like '%result%' order by fecha desc
                                            else  select 'HABLAR CON SISTEMAS'";
                var resultado = cmd.ExecuteScalar();
                try
                {
                   respues = JsonConvert.DeserializeObject<respuesta>(resultado.ToString());
                    int ans;
                    if (Int32.TryParse(respues.result.ToString(), out ans))
                    {
                        return "TIMBRAR CFDI";
                    }
                    else if (respues.result.Equals("true"))
                    {
                        return "No Generó Factura";
                    }
                    else return respues.result;
                }
                catch (Exception ex)
                {
                    return respues.result;
                }
                
            }
        }
    }
}
