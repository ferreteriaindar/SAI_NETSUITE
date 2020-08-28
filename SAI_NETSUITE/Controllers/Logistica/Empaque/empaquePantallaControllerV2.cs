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
                      CASE WHEN ResponseCfdi LIKE '%Rfc%' THEN 'Error de RFC,LLAMAR A CREDITO Y COBRANZA'
                      WHEN ResponseCfdi LIKE '%CFDI33134%' THEN 'Error de RFC,LLAMAR A CREDITO Y COBRANZA'
                      WHEN ResponseCfdi LIKE '%CFDI33137%' THEN 'Error de RFC,LLAMAR A CREDITO Y COBRANZA'
                        WHEN ResponseCfdi LIKE '%ClaveProdServ%' THEN 'Error de Articulo, LLAMAR A COMPRAS'
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

        public bool tieneErrorImpresion(string v)
        {

            string query = "select COUNT(*) as contar from IWS.dbo.errorFulFillment where error = 'Error de Impresion' and movid ='" + v + "'";
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand(query, myConnection);
                var resultado = cmd.ExecuteScalar();
                if (resultado.ToString().Equals("0"))
                    return false;
                else return true;

               ;
            }
        }

        public string fulfillmentToInvoice(pedidoFulfill pedido)
        {

           
            
            ItemFullfilmentModel iffm = new ItemFullfilmentModel();
            if (pedido.lines==null)
            {
                string query = @"select SO.internalId,'' as transactionnumber,I.id,FO.CantidadesSurtidas from  IWS.dbo.SaleOrders SO
                        LEFT JOIN INDAR_INACTIONWMS.int.Facturar_Out  FO on Movimiento='salesorder' COLLATE Modern_Spanish_CI_AI and MovId=so.tranid
                        LEFT JOIN IWS.dbo.Items I on FO.Articulo=I.itemid COLLATE Modern_Spanish_CI_AI
                        WHERE FO.Movimiento='" + pedido.mov + "' and FO.MovId=" + pedido.movid;
                Console.WriteLine(query);
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
            }
            else
            {
                Createdfrom createdfrom = new Createdfrom();
                createdfrom.id = pedido.movid;
                createdfrom.recordType = "salesorder";
                iffm.createdfrom = createdfrom;
                iffm.shipcountry = "MX";
                Shipstatus shipstatus = new Shipstatus();
                shipstatus.value = "C";
                shipstatus.txt = "Shipped";
                iffm.shipstatus = shipstatus;
                List<Line> list = new List<Line>();
                foreach (var item in pedido.lines)
                {
                    Line line = new Line();
                    line.itemId = item.itemId;
                    line.location = "1";
                    line.quantity = item.quantity;
                    list.Add(line);
                }
                iffm.lines = list;
            }
            string json = JsonConvert.SerializeObject(iffm, Newtonsoft.Json.Formatting.Indented);
            Connection connection = new Connection();
            string resultado = connection.POST("api/Invoice/fulfillmentToInvoice", json, SAI_NETSUITE.Properties.Resources.token, true);
            return resultado;
        }

        public List<pedidoFulfill> regresaPedidosEnCotizacion(string cotizacion, string formaEnvio)
        {
            //  CONSULTO LO QUE SURTIO EL WMS COMPLETO Y LUEGO BAJO LOS PEDIDOS QUE VAN ESA COTIZACION Y VOY CREANDO LA LISTA DE P
            //   DE PEDIDOS INDIVIDUALES
            List<pedidoFulfill> listaCoti = new List<pedidoFulfill>();
            PedidoFulfillCotizacion pedidoSurtido = new PedidoFulfillCotizacion();
            pedidoSurtido.listaArt = new List<Articuloscotizacion>();
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                myConnection.Open();
                string query = @"select  FO.IdFacturar,I.id,I.itemid,FO.CantidadesSurtidas from  INDAR_INACTIONWMS.int.Facturar_Out  FO 
                        LEFT JOIN IWS.dbo.Items I on FO.Articulo=I.itemid COLLATE Modern_Spanish_CI_AI
                        WHERE FO.Movimiento='cotizacion' and FO.MovId=" + cotizacion;
                SqlCommand cmd = new SqlCommand(query, myConnection);
                SqlDataReader sdr = cmd.ExecuteReader();
                bool primeravez = true;
                List<Articuloscotizacion> ac = new List<Articuloscotizacion>();
                while (sdr.Read() && sdr.HasRows)
                {
                    if (primeravez)
                    {
                        pedidoSurtido.idpedido = sdr.GetValue(0).ToString();
                        primeravez = false;
                    }
                    
                    
                        Articuloscotizacion art = new Articuloscotizacion()
                        {
                            id = sdr.GetValue(1).ToString(),
                            itemid = sdr.GetValue(2).ToString(),
                            cantidad = Convert.ToInt32(sdr.GetValue(3).ToString())
                        };
                        ac.Add(art);
                    
                }
                pedidoSurtido.listaArt.AddRange(ac);
            }

            //AGARRO EN UN OBJECTO TODO LO QUE SURTI, Y  LUEGO AGARROS LOS PEDIDOS Y LOS VOY COMPARANDO ARTICULO POR ARTICULO Y 
            //Y  GENERO  LA LISTA  PEDIDOFULLFILL COMO SI FUERA UN CONSOLIDADO
            using (IWSEntities  ctx = new IWSEntities())
            {
                var pedidoIWS = (from SO in ctx.SaleOrders
                                 join SOD in ctx.SaleOrdersDetails on SO.internalId equals SOD.saleOrderId
                                 
                                 where SO.cotizacion.Equals(cotizacion)
                                 select new { SO.internalId, SOD.itemId, SOD.quantity}).ToList();
               
                foreach (var item in pedidoIWS.Select(x => x.internalId).Distinct())
                {
                    pedidoFulfill pf = new pedidoFulfill();
                    pf.lines = new List<Line>();
                    pf.movid = item.ToString();
                    pf.formaEnvio = formaEnvio;
                    pf.mov = "cotizacion";
                    List<Line> lineas = new List<Line>();
                    foreach (var pedidoInd in pedidoIWS.Where(x=>x.internalId.Equals( item)))
                    {
                        if (pedidoSurtido.listaArt.Any(x => x.id.Equals(pedidoInd.itemId)))  //.SingleOrDefault(x => x.itemid.Equals(pedidoInd.itemId)) != null)
                        {
                            int cantidad = pedidoSurtido.listaArt.Where(x => x.id.Equals(pedidoInd.itemId)).Select(x => x.cantidad).First();
                            int pide = pedidoInd.quantity.Value;
                            if (cantidad >= pide)
                            {
                                Line line = new Line()
                                {
                                    itemId = pedidoInd.itemId,
                                    location = "1",
                                    quantity = pide.ToString()
                                };
                                lineas.Add(line);
                                /* var pedidoSurtido. = pedidoSurtido.listaArt.Where(x => x.itemid == pedidoInd.itemId).
                                  Select(x => { x.cantidad = x.cantidad - pide; return x; }).ToList();*/
                               var x2= pedidoSurtido.listaArt.Select(x => {
                                    x.cantidad = x.id == pedidoInd.itemId ? x.cantidad - pide : x.cantidad;
                                    return x;
                                }).ToList();

                                                                
                            }
                        }
                    }
                    pf.lines.AddRange(lineas);
                    pf.cotizacion = cotizacion;
                    listaCoti.Add(pf);


                }
            }
            return listaCoti;
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

        public void registraErrorImpresion(string cons)
        {
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1))
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText = @"insert into iws.dbo.errorfulfillmentv2 (mov,movid,error,fecha)
                                    values (@mov,@movid,@error,getdate())";
                cmd.Parameters.AddWithValue("@mov", "Cons");
                cmd.Parameters.AddWithValue("@movid", cons);
                cmd.Parameters.AddWithValue("@error", "Error de Impresion");
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


        public void ReglasImprimirCotizacion(string cotizacion, List<pedidoFulfill> list)
        {
            string FORMAENVIO = list[0].formaEnvio;
            foreach (var pedido in list)  //PRIMERO  SE IMPRIMEN LAS FACTURAS QUE CONFORMAN  LA CONS
            {
                if (pedido.formaEnvio.ToUpper().Contains("OFICINA"))
                    ImprimeFactura(pedido.error, false, pedido, 3);
                else ImprimeFactura(pedido.error, false, pedido, 2);
            }
          
            pdfController pdc = new pdfController();
            if (!FORMAENVIO.ToUpper().Contains("CLIENTE") || !FORMAENVIO.ToUpper().Contains("EMPLEADO"))
                pdc.imprimePDFyPackingCotizacion(cotizacion, "2");
            if (FORMAENVIO.ToUpper().Contains("FLETERA") || FORMAENVIO.ToUpper().Contains("OFICINA"))
                pdc.imprimePDFyPackingCotizacion(cotizacion, "1");

        }




        public string EsTimbrada(string error, string numpedido,string mov)
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
                           if( (@TOTAL-@SUMA)=0  )
                                 begin 
							 update OE  set FacturaIndar=I.TranId,OE.FechaFactura=GETDATE()  FROM INDAR_INACTIONWMS.DBO.OrdenEmbarque OE
																INNER JOIN  IWS.DBO.SaleOrders SO ON OE.IdPedido=SO.internalId
																INNER JOIN IWS.DBO.Invoices I ON SO.internalId=I.createdfrom
																WHERE OE.Consolidado='" + numpedido+@"'
                                                select 'OK'
							 end
                            else 
                                begin 
                                select 'NOK'
                                 end
                            ";
            }
            if(mov.Equals("salesorder"))
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
            if (mov.Equals("cotizacion"))
            {
                query = @" DECLARE @SUMA INT
                              DECLARE @TOTAL INT
                              SELECT @SUMA=sum(UUID),@TOTAL=COUNT(TranId) FROM (
                              select TranId, case when UUID='0' then 0
                                                     when UUID='' then 0   else 1 end as uuid from (
      							select TranType,TranId,UUID from  IWS.dbo.Invoices where createdfrom in (SELECT  internalId FROM IWS.DBO.SaleOrders WHERE cotizacion="+numpedido+@") AND status NOT IN ('Voided') 
                               
                             ) as q) AS q2
                             if( (@TOTAL-@SUMA)=0  )
                                 begin 
										update INDAR_INACTIONWMS.DBO.OrdenEmbarque SET FacturaIndar=1 WHERE NumPedido="+numpedido+@" AND Mov='cotizacion'
                                        select  'OK'

								 end
							 else
								   begin
											select 'NOK'
								   end
							";
            }

            cmd.CommandText = query;
            resultado = cmd.ExecuteScalar().ToString();
            myConnection.Close();
            myConnection.Dispose();
            if (resultado.ToString().Equals("OK")|| resultado.ToString().Equals("0"))
                return  "TERMINADO";
            else return error;

        }

       

        public string regresaInfoConsSinTimbrar(string v,string mov)
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
            if (mov.Equals("cotizacion"))
            {
                query = @"	select  hola=stuff	(( select ','+CONVERT(NVARCHAR(15), i.TranId) FROM  IWS.DBO.SaleOrders SO
																INNER JOIN IWS.DBO.Invoices I ON SO.internalId=I.createdfrom
																WHERE SO.cotizacion='"+v+@"'
																FOR XML PATH ('')
																),1,1,'')";
            }
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

        internal class registrarErrorImpresion
        {
            private string cons;

            public registrarErrorImpresion(string cons)
            {
                this.cons = cons;
            }
        }
    }
}
