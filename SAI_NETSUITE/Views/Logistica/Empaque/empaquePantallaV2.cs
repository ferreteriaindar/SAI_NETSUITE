﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAI_NETSUITE.Controllers.Logistica.Empaque;
using SAI_NETSUITE.Models.Transaccion;
using Newtonsoft.Json;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SAI_NETSUITE.Models.Catalogos;
using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;
using System.Diagnostics;
using System.Data.SqlClient;

namespace SAI_NETSUITE.Views.Logistica.Empaque
{
    public partial class empaquePantallaV2 : UserControl
    {
        string usuario;
        bool FinProceso = true;
        public empaquePantallaV2(string usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            labelAvance.Text = "0/0";
            btnFacturar.ImageOptions.Image = null;
        
            cargaDatos();

        }

        public void cargaDatos()
        {
            empaquePantallaControllerV2 epcv2 = new empaquePantallaControllerV2();
            gridControl1.DataSource=    epcv2.cargaDatos().Tables[0];

            // SE  HACE  RECORRIDO PARA VER  SI YA ESTAN TODAS LAS FACTURAS POR RENGLON E INDICARLE QUE TIMBRE SU CORRESPONDIENTE
            //en caso de que este impar  o desigual  poner un mensaje de revisar.
            //si encuentra que esta ya timbraba la tiene que desaparecer
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, colPedidos).ToString().Equals(gridView1.GetRowCellValue(i, colFACTURAS).ToString()))
                {
                    //EL NUMERO DE PEDIDOS ES IGUAL A FACTURAS ENTONCES BUSCA CUAL DEBE DE TIMBRAR
                    if (gridView1.GetRowCellValue(i, colMov).ToString().Equals("salesorder"))
                    {
                        gridView1.SetRowCellValue(i, colerror, epcv2.regresaNumFactura(gridView1.GetRowCellValue(i, colNumPedido).ToString()));
                    }
                    if (gridView1.GetRowCellValue(i, colMov).ToString().Equals("Cons") || gridView1.GetRowCellValue(i, colMov).ToString().Equals("cotizacion"))
                    {
                        //REVISA SI TIENE ERROR DE IMPRESION
                        if(TieneErrorDeImpresion(gridView1.GetRowCellValue(i,colNumPedido).ToString()))
                            gridView1.SetRowCellValue(i, colerror, "Error Impresion");
                        else 
                        gridView1.SetRowCellValue(i, colerror, "Timbra las Facturas");
                        // y si hacen doble click en el grid cuanto es cons  y dice "Timbra las facturas"  te las muestra.
                    }

                   
                                       
                }
            }
            //AHORA REVISA QUE SI ESTEN TIMBRADAS PARA BORRARLAS
            //TERCER LOOP PARA DETECTAR TIMBRADOS
            for (int i = 0; i < gridView1.RowCount; i++)
            {//SE HACE UN LOOP, si ya esta timbrada nomas la marca para que desaparezca , si no regresa el mismo error
                if (gridView1.GetRowCellValue(i, colerror).ToString().Contains("TIMBRA") || gridView1.GetRowCellValue(i, colerror).ToString().Contains("Timbra"))
                {
                    gridView1.SetRowCellValue(i, colerror, epcv2.EsTimbrada(gridView1.GetRowCellValue(i, colerror).ToString(), gridView1.GetRowCellValue(i, colNumPedido).ToString(), gridView1.GetRowCellValue(i, colMov).ToString()));
                }
            }
            labelRowCount.Text = gridView1.RowCount.ToString() + " renglones/" + contarPedidosPorfacturar() + " por facturar";
        }

        public bool TieneErrorDeImpresion(string v)
        {
            empaquePantallaControllerV2 epcv2 = new empaquePantallaControllerV2();
            return epcv2.tieneErrorImpresion(v);
        }

        public string contarPedidosPorfacturar()
        {
            string resultado = "n/a";
            int pedidos = 0, facturas = 0;
            try
            {
               
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    pedidos = pedidos + Convert.ToInt32(gridView1.GetRowCellValue(i, colPedidos).ToString());
                    facturas = facturas + Convert.ToInt32(gridView1.GetRowCellValue(i, colFACTURAS).ToString());
                }
                resultado = Math.Abs(pedidos - facturas).ToString();
            }
            catch (Exception ex)
            {
                return "n/a";
            }

            return resultado;
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            FinProceso = false;
            if (toggleSwitch1.IsOn)
                btnFacturar.ImageOptions.Image = SAI_NETSUITE.Properties.Resources.WedgesT;
            else btnFacturar.ImageOptions.Image = SAI_NETSUITE.Properties.Resources.gear;
           
            gridControl1.Enabled = false;
            bool banderaTraspaso = false;
            if (gridView1.SelectedRowsCount < 1) //POR SI NO SELECCIONAN NADA
                MessageBox.Show("Selecciona al menos un pedido");
            else  //GENERA EL LISTADO DE PEDIDOS Y LOS PEDIDOS QUE CONFORMAN UNA CONS
            {
                List<pedidoFulfill> listaPedidos = new List<pedidoFulfill>();
                for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                {
                    int rowHandle = gridView1.GetSelectedRows()[i];

                    if (gridView1.GetRowCellValue(rowHandle, colMov).ToString().Equals("salesorder"))
                    {
                        pedidoFulfill pf = new pedidoFulfill()
                        {
                            mov = gridView1.GetRowCellValue(rowHandle, colMov).ToString(),
                            movid = gridView1.GetRowCellValue(rowHandle, colNumPedido).ToString(),
                            formaEnvio = gridView1.GetRowCellValue(rowHandle,colForma).ToString()
                        };
                        listaPedidos.Add(pf);
                    }
                    if (gridView1.GetRowCellValue(rowHandle, colMov).ToString().Equals("Cons"))  //TIENE Que hacer un loop para insertar pedidos
                    {
                        empaquePantallaControllerV2 epcv2 = new empaquePantallaControllerV2();
                        listaPedidos.AddRange(epcv2.regresaPedidosEnCons(gridView1.GetRowCellValue(rowHandle, colNumPedido).ToString(), gridView1.GetRowCellValue(rowHandle, colForma).ToString()));
                    }

                    if (gridView1.GetRowCellValue(rowHandle, colMov).ToString().Equals("cotizacion"))
                    {

                        empaquePantallaControllerV2 epcv2 = new empaquePantallaControllerV2();
                        listaPedidos.AddRange(epcv2.regresaPedidosEnCotizacion(gridView1.GetRowCellValue(rowHandle, colNumPedido).ToString(), gridView1.GetRowCellValue(rowHandle, colForma).ToString()));

                    }
                    if (gridView1.GetRowCellValue(rowHandle, colMov).ToString().Equals("Traspaso"))  //VAS A TENER QUE HACER EL FULFILLMENT AHI
                    {
                        pedidoFulfill pf = new pedidoFulfill()
                        {
                            mov = gridView1.GetRowCellValue(rowHandle, colMov).ToString(),
                            movid = gridView1.GetRowCellValue(rowHandle, colNumPedido).ToString(),
                            formaEnvio = gridView1.GetRowCellValue(rowHandle, colForma).ToString()
                        };
                        listaPedidos.Add(pf);
                        banderaTraspaso = true;
                    }

                }
                //GENERAR EL HILO DE TIMBRADO PARA CADA PEDIDO/CONS 
                if (!backgroundWorker1.IsBusy || !backgroundWorkerEventos.IsBusy)
                {
                    guardaOleada(listaPedidos);
                    if (banderaTraspaso == false)
                        backgroundWorker1.RunWorkerAsync(argument: listaPedidos);
                    else backgroundWorkerEventos.RunWorkerAsync(argument: listaPedidos);
                }
                else MessageBox.Show("Espera a que termine el proceso actual (-_-)!");
            }


        }


        public void  guardaOleada(List<pedidoFulfill> lista)
        {
            List<OleadaFacturacion> listaOleada = new List<OleadaFacturacion>();
            DateTime dt = DateTime.Now;
            using (IWSEntities ctx = new IWSEntities())
            {
                foreach (var pedido in lista)
                {
                    OleadaFacturacion OF = new OleadaFacturacion()
                    {
                        fecha = dt,
                        movid=pedido.movid,
                        usuario=usuario
                       
                    };
                    listaOleada.Add(OF);
                }

                ctx.OleadaFacturacion.AddRange(listaOleada);
                ctx.SaveChanges();
            }
        }
        private void empaquePantallaV2_Load(object sender, EventArgs e)
        {
             btnFacturar.ImageOptions.Image = null;
          

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int avance = 0;
            List<pedidoFulfill> lista = (List<pedidoFulfill>)e.Argument;
              empaquePantallaControllerV2 epcv2 = new empaquePantallaControllerV2();
              for (int i = 0; i <lista.Count; i++)
              {

                string resultado = epcv2.fulfillmentToInvoice(lista[i]);
                  respuestaIWScs res = JsonConvert.DeserializeObject<respuestaIWScs>(resultado);
                  //responseJson rs = JsonConvert.DeserializeObject<responseJson>(res.result);
                  if (res.result.responseStructure.codeStatus.Equals("NOK"))
                  {
                      epcv2.registraError(lista[i], res.result.responseStructure.descriptionStatus);
                      lista[i].error = "NOK";
                  }
                  else lista[i].error = res.result.internalId.ToString();  //usamos este campo para poner el id de la factura
                  avance++;
                  backgroundWorker1.ReportProgress(avance);
              }
            //SE HACE UN SEGUNDO LOOP PARA DAR TIEMPO A NETSUITE QUE NOS MANDE LA INFORMACION DE LA FACTURA
            //SE IMPRIME PACKING LIST Y LUEGO LA FACTURA
            /*
            pdfController pdfc = new pdfController();  //ES LA CLASE QUE IMPRIME PACKING LIST

            for (int i = 0; i < lista.Count; i++)
            {
                if (!lista[i].error.Equals("NOK")) // solo agarra los que no dieron error en el webservice
                {
                    if (String.IsNullOrEmpty(lista[i].cons)) //PRIMERO IMPRIMIMOS  LOS PEDIDOS NORMALES
                    {
                        pdfc.imprimePDFyPacking(lista[i].error, "2");  //lista[i].error ahi ponemos el id de la factura
                        pdfc.imprimePDFyPacking(lista[i].error, "1");
                        epcv2.ImprimeFactura(lista[i].error, false,lista[i]); //mandamos false por que no tenemos el tranid de la factura , es el idinterno
                    }
                }

            }

          // AHORA SE IMPRIMEN LAS CONS
          List<string> listaCons = lista.Where(t => t.cons != null)
                                          .GroupBy(t2 => t2.cons).Select(x => x.FirstOrDefault().cons).ToList();
          //SE ITERA POR CADA DISTINCT DE CONS Y  DE AHI DE RECORRE CADA FACTURA PARA IMPRIMIRLE SU PACKING Y SU FACTURA
         pdfController pc = new pdfController();
          foreach (var cons in listaCons)
          {
              pc.imprimePDFyPackingCons(cons, "2");
              pc.imprimePDFyPackingCons(cons, "1");
              foreach (var pedido in lista.Where(t => t.cons == cons && t.error != "NOK").ToList())
              {
                  epcv2.ImprimeFactura(pedido.error, false,pedido);
              }

          }
          */

            for (int i = 0; i < lista.Count; i++)
            {
                if (!lista[i].error.Equals("NOK")) // solo agarra los que no dieron error en el webservice
                {
                    if (String.IsNullOrEmpty(lista[i].cons)&& String.IsNullOrEmpty(lista[i].cotizacion)) //PRIMERO IMPRIMIMOS  LOS PEDIDOS NORMALES
                    {
                        epcv2.ReglasImprimir(lista[i]);


                    }
                }

            }
            // AHORA SE IMPRIMEN LAS CONS
            List<string> listaCons = lista.Where(t => t.cons != null)
                                            .GroupBy(t2 => t2.cons).Select(x => x.FirstOrDefault().cons).ToList();
            foreach (var cons in listaCons)
            {/*
                pc.imprimePDFyPackingCons(cons, "2");
                pc.imprimePDFyPackingCons(cons, "1");
                foreach (var pedido in lista.Where(t => t.cons == cons && t.error != "NOK").ToList())
                {
                    epcv2.ImprimeFactura(pedido.error, false, pedido);
                }*/

                //POR PETICION DE ARTURO VALIDAR QUE EXISTAN LAS FACTURAS ANTES DE IMPRIMIR PACKING LIST
                if(YaestanlasFacturasenIWS(lista.Where(t => t.cons == cons && t.error != "NOK").ToList()))
                epcv2.ReglasImprimirCons(cons, lista.Where(t => t.cons == cons && t.error != "NOK").ToList());
                else
                {
                    registraErrorImpresion(cons);
                }

            }

            // AHORA SE IMPRIMEN LAS CONTIZACIONES
            List<string> listaCotizacion = lista.Where(t => t.cotizacion != null)
                                           .GroupBy(t2 => t2.cotizacion).Select(x => x.FirstOrDefault().cotizacion).ToList();
            foreach (var cotizacion in listaCotizacion)
            {
                epcv2.ReglasImprimirCotizacion(cotizacion, lista.Where(t => t.cotizacion == cotizacion && t.error != "NOK").ToList());
            }


        }

        private void registraErrorImpresion(string cons)
        {
            empaquePantallaControllerV2 epcv2 = new empaquePantallaControllerV2();
            epcv2.registraErrorImpresion(cons);
        }

        public bool YaestanlasFacturasenIWS(List<pedidoFulfill> list)
        {
            bool completo = true;
            using (IWSEntities ctx =new IWSEntities())
            {
                foreach (var pedido in list)  //PRIMERO  SE IMPRIMEN LAS FACTURAS QUE CONFORMAN  LA CONS
                {
                    if (!ctx.Invoices.Any(o => o.internalId.ToString().Equals(pedido.error)))
                    {
                        completo = false;
                    }
                    
                   

                }
            }

            return completo;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
              btnFacturar.ImageOptions.Image = null;
           
            if(FinProceso==true)
            MessageBox.Show("¡Terminado! \n Espera a que vuelva a carga la pantalla");
            labelAvance.Text = "0/0";
            cargaDatos();
            gridControl1.Enabled = true;
            FinProceso = true;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (gridView1.GetRowCellValue(info.RowHandle, colMov).ToString().Contains("cotizacion") && gridView1.GetRowCellValue(info.RowHandle, colerror).ToString().Contains("Timbra las Facturas"))
            {
                empaquePantallaControllerV2 epcV2 = new empaquePantallaControllerV2();
                MessageBox.Show(epcV2.regresaInfoConsSinTimbrar(gridView1.GetRowCellValue(info.RowHandle, colNumPedido).ToString(), "cotizacion"));

            }
            if (gridView1.GetRowCellValue(info.RowHandle, colMov).ToString().Contains("Cons") && gridView1.GetRowCellValue(info.RowHandle, colerror).ToString().Contains("Timbra las Facturas"))
            {//INDICA LAS FACTURAS DE LA CONS QUE TIENE QUE TIMBRAR
                empaquePantallaControllerV2 epcV2 = new empaquePantallaControllerV2();
                MessageBox.Show(epcV2.regresaInfoConsSinTimbrar(gridView1.GetRowCellValue(info.RowHandle, colNumPedido).ToString(), "Cons"));
            }
            else
            {
                DetallePedido dp = new DetallePedido(gridView1.GetRowCellValue(info.RowHandle, colMov).ToString(), gridView1.GetRowCellValue(info.RowHandle, colNumPedido).ToString());
                dp.ShowDialog();
            }
            gridView1.UnselectRow(info.RowHandle);
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
        
            GridView view = sender as GridView;
            bool Traspaso = false,pedido=false;
            for (int i=0;i<gridView1.SelectedRowsCount;i++)
            {
                int r = view.GetSelectedRows()[i];
                if (view.GetRowCellValue(r, colMov).ToString().Equals("Traspaso"))
                    Traspaso = true;
                else pedido = true;
                if (!view.GetRowCellValue(r, colFACTURAS).ToString().Equals("0"))
                    gridView1.UnselectRow(r);
                if (Traspaso == true && pedido==true)
                {
                    MessageBox.Show("No se puede mezclar  Traspaso con pedido");
                    gridView1.UnselectRow(r);
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelAvance.Text = e.ProgressPercentage.ToString() + "/" + gridView1.SelectedRowsCount.ToString();
        }

        private void btnReimprimir_Click(object sender, EventArgs e)
        {
           // if (!txtReimprimir.Text.ToUpper().Contains("CONS"))
           if(radioGroup1.EditValue.ToString().Equals("1"))
            {
                Controllers.Logistica.Empaque.FacturaIndarController fic = new Controllers.Logistica.Empaque.FacturaIndarController();
                DataSet ds = fic.regresaDatosCabecera(Convert.ToInt32(txtReimprimir.Text));
               // ds.WriteXmlSchema(@"S:\XML\Almacen\FacturaIndarSinTimbrar.xml");
                Views.Logistica.Empaque.FacturaIndar fi = new FacturaIndar();
                fi.DataSource = ds;
                using (ReportPrintTool printTool = new ReportPrintTool(fi))
                {
                    // Invoke the Ribbon Print Preview form modally, 
                    // and load the report document into it.
                    printTool.ShowRibbonPreviewDialog();

                    // Invoke the Ribbon Print Preview form
                    // with the specified look and feel setting.
                    printTool.ShowRibbonPreview(UserLookAndFeel.Default);
                    //printTool.Print(); System.Windows.Forms.MessageBox.Show("Impreso");

                }

                empaquePantallaControllerV2 epcv2 = new empaquePantallaControllerV2();
                pdfController pdfc = new pdfController();
                pdfc.imprimePDFyPacking(epcv2.regresaIDdeFactura(txtReimprimir.Text), "2");
                pdfc.imprimePDFyPacking(epcv2.regresaIDdeFactura(txtReimprimir.Text), "1");
            }
            if(radioGroup1.EditValue.ToString().Equals("2")) //REIMPRIME CONS
            {
                reimprimircons(txtReimprimir.Text);
            }
            //REIMPRIMIR   COTIZACION
            if (radioGroup1.EditValue.ToString().Equals("3"))
                reimprimirCotizacion(txtReimprimir.Text);

        }


        public void reimprimirCotizacion(string cotizacion)
        {
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1))
            {
                List<pedidoFulfill> lista = new List<pedidoFulfill>();
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText = @"select 'cotizacion' as mov,"+cotizacion+@" as NumPedido,internalid as FacturaIndar,'' as Consolidado,FO.LIST_ITEM_NAME AS FormaEnvio
                                     from IWS.dbo.Invoices I
                                     inner join IWS.dbo.FormaEnvio  FO ON I.ShippingWay=FO.LIST_ID															
                                     where  createdfrom in (select internalId from IWS.dbo.SaleOrders where cotizacion="+cotizacion+" and  syncWMS is not null)";
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read() && sdr.HasRows)
                {
                    pedidoFulfill pf = new pedidoFulfill()
                    {
                        cons = (string)sdr["Consolidado"],
                        error = (string)sdr["FacturaIndar"].ToString(),
                        formaEnvio = (string)sdr["FormaEnvio"]/*,
                        mov = (string)sdr["mov"],
                        movid = (string)sdr["NumPedido"]*/
                    };
                    lista.Add(pf);
                }
                if (lista.Count > 0)
                    new empaquePantallaControllerV2().ReglasImprimirCotizacion(cotizacion,lista);

            }
        }


        public void reimprimircons(string cons)
        {
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1))
            {
                List<pedidoFulfill> lista = new List<pedidoFulfill>();
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText = @"select mov,NumPedido,(select CONVERT(nvarchar(10), internalid) from iws.dbo.invoices where tranid=facturaindar) as FacturaIndar,Consolidado,FormaEnvio from INDAR_INACTIONWMS.dbo.OrdenEmbarque where Consolidado='" + cons + "' and  IdEstatusOrdenEmbarque<>3";
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read() && sdr.HasRows)
                {
                        pedidoFulfill pf = new pedidoFulfill()
                    {
                        cons = (string)sdr["Consolidado"],
                        error =(string) sdr["FacturaIndar"],
                        formaEnvio = (string)sdr["FormaEnvio"],
                        mov = (string)sdr["mov"],
                        movid = (string)sdr["NumPedido"]
                    };
                    lista.Add(pf);
                }
                if (lista.Count > 0)
                   new empaquePantallaControllerV2().ReglasImprimirCons(cons, lista);
            }
        }

        private void backgroundWorkerEventos_DoWork(object sender, DoWorkEventArgs e)
        {
            List<pedidoFulfill> lista = (List<pedidoFulfill>)e.Argument;
            bool regreso = false;
            foreach (var pedido in lista)
            {

                Controllers.Logistica.Empaque.empaquePantallaController emp = new Controllers.Logistica.Empaque.empaquePantallaController();
                regreso = emp.fulfillmentTraspaso(pedido, sender as BackgroundWorker);

            }
        }

        private void backgroundWorkerEventos_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnFacturar.ImageOptions.Image = null;
         
            MessageBox.Show("¡Terminado! \n Espera a que vuelva a carga la pantalla");
            labelAvance.Text = "0/0";
            cargaDatos();
            gridControl1.Enabled = true;
        }

        private void btnOleada_Click(object sender, EventArgs e)
        {
            HistoriaOleadas ho = new HistoriaOleadas();
            ho.Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            string carpeta = string.Empty;
            carpeta = System.IO.Path.GetTempPath();

            gridControl1.ExportToXlsx(carpeta + "\\timbrar.xlsx");
            Process pdfexport = new Process();
            pdfexport.StartInfo.FileName = "EXCEL.exe";
            pdfexport.StartInfo.Arguments = carpeta + "\\timbrar.xlsx";
            pdfexport.Start();
        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            /*
            if(!backgroundWorker1.IsBusy && FinProceso==true)
            timerAutomatico.Start();*/
        }

        private void timerAutomatico_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy && FinProceso == true)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, colerror).ToString().Equals("") && !gridView1.GetRowCellValue(i, colMov).ToString().Equals("Traspaso"))
                        gridView1.SelectRow(i);
                }
                btnFacturar_Click(null, null);
            }
        }

        private void btnPedidoFactura_Click(object sender, EventArgs e)
        {
            sendGetSalesInvoiceWMSModel lista = new sendGetSalesInvoiceWMSModel();
            lista.ids = new List<string>();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
             
            }

            Empaque.PedidoFacturaWMS pfwms = new PedidoFacturaWMS();
            pfwms.Show();
        }
    }
}
