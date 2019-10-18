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

namespace SAI_NETSUITE.Controllers.Logistica.Empaque
{
    class empaquePantallaController
    {

        public DataSet regresaInfo()
        {
            DataSet ds = new DataSet();
            SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString);
            string query = "exec  indarneg.dbo.spEmpaquePantallaNetsuite";
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            da.Fill(ds);

            return ds;

        }

        public List<pedidoFulfill> listadoCons(string consolidad0)
        {
            List<pedidoFulfill> listado = new List<pedidoFulfill>();
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString)) 
            {
                myConnection.Open();
                string query = @"select mov,NumPedido from indar_inactionwms.dbo.OrdenEmbarque where Consolidado='" + consolidad0 + "'";
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
            string query = @"if exists (select TranId from iws.dbo.Invoices where createdfrom =(select internalId from iws.dbo.SaleOrders where tranid=" + pedido+ @"))
                            select TranId from iws.dbo.Invoices where createdfrom = (select internalId from iws.dbo.SaleOrders where tranid = " + pedido+@")
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
            return "TIMBRAR CFDI";
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
            return "TIMBRAR CFDI";
        }

        public pedidoFulfill fulfillment(pedidoFulfill pedido)
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
                SaleOrderToInvoiceModel sotim = new SaleOrderToInvoiceModel();
                sotim.salesOrderInternalId = iffm.createdfrom.id.ToString();
                string jsonBill = JsonConvert.SerializeObject(sotim, Formatting.Indented);
                string resultadoBill = connection.POST("api/Invoice/CreateInvoice", jsonBill, SAI_NETSUITE.Properties.Resources.token,true);
                pedido.error = resultadoBill;
            }

                return pedido;
        }

        public void ImprimirDirecto(string pedido,string tipo)
        {
            int internalID=0;
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                myConnection.Open();
                string query = @"select internalid from iws.dbo.Invoices where createdfrom =(select internalId from iws.dbo.SaleOrders where tranid=" + pedido + @")";
                SqlCommand cmd = new SqlCommand(query, myConnection);
                internalID = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            };

             byte [] pdf=GetPDF(internalID);

            MemoryStream ms = new MemoryStream(pdf);
            var pdfViewer2 = new DevExpress.XtraPdfViewer.PdfViewer();
            pdfViewer2.LoadDocument(ms);
            pdfViewer2.Print();
            pdfController pdfc = new pdfController();
            pdfc.imprimePDFyPacking(internalID.ToString(), tipo);

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
               // cmd.CommandText = "select top 1 case when error='{\"result\":true}' then 'CFDI TIMBRAR' ELSE error END as error from iws.dbo.errorfulfillment where  mov='" + mov + "' and movid='" + movid + "' order by fecha desc";
               cmd.CommandText= "select top 1 error from iws.dbo.errorfulfillment where  mov='" + mov + "' and movid='" + movid + "' order by fecha desc";
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
