using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAI_NETSUITE.Models.Transaccion;
using SAI_NETSUITE.Models.Catalogos;
using SAI_NETSUITE.Controllers.Logistica.Empaque;
using System.IO;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Threading;

namespace SAI_NETSUITE.Views.Logistica.Empaque
{
    public partial class empaquePantalla : UserControl
    {
        public empaquePantalla()
        {
            InitializeComponent();
        }


        public void cargaInfo()
        {
            Controllers.Logistica.Empaque.empaquePantallaController epc = new Controllers.Logistica.Empaque.empaquePantallaController();
            gridControl1.DataSource = epc.regresaInfo().Tables[0];
            for (int i = 0; i < gridView1.RowCount; i++) //REGRESA INFO SI SE SURTIO Y SE FACTURÓ  ENCONTRO ERROR y si encontro estado TIMBRAR CFDI buscar que factura
            {



                gridView1.SetRowCellValue(i, colerror, epc.regresaErrorPedido(gridView1.GetRowCellValue(i, colPedido).ToString(), gridView1.GetRowCellValue(i, colMovId).ToString()));
                
                /*REVISA SI YA  ESTA  FULL Y FACTURADA PARA INDICAR QUE SE TIMBRE DENTRO DE NETSUITE*/
                if (gridView1.GetRowCellValue(i,colerror).Equals("TIMBRAR CFDI"))
                gridView1.SetRowCellValue(i, colerror, epc.regresaNumFactura(gridView1.GetRowCellValue(i, colPedido).ToString(), gridView1.GetRowCellValue(i, colMovId).ToString()));
                /*REVISA SI ESTA TIMBRADA LA FACTURA*/
                string error = gridView1.GetRowCellValue(i, colerror).ToString();
                if (gridView1.GetRowCellValue(i, colerror).ToString().Contains(":"))
                    gridView1.SetRowCellValue(i, colerror, epc.YaestaTimbrada(gridView1.GetRowCellValue(i, colPedido).ToString(), gridView1.GetRowCellValue(i, colMovId).ToString(), gridView1.GetRowCellValue(i, colerror).ToString()));
                /***************************************/

            }




        }

        private void empaquePantalla_Load(object sender, EventArgs e)
        {
            cargaInfo();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            pedidoFulfill p = new pedidoFulfill();
            p.mov = gridView1.GetFocusedRowCellValue(colPedido).ToString();
            p.movid = gridView1.GetFocusedRowCellValue(colMovId).ToString();


            if (!backgroundWorker1.IsBusy)
            {
                pictureBox.Visible = true;
                simpleButton2.ImageOptions.Image = SAI_NETSUITE.Properties.Resources._835;
              
                if (!p.mov.Contains("Cons"))
                    backgroundWorker1.RunWorkerAsync(argument: p);
                else
                {
                    empaquePantallaController epc = new empaquePantallaController();
                   List<pedidoFulfill> lista= epc.listadoCons(p.movid);
                    foreach (var pedido in lista )
                    {
                        while (backgroundWorker1.IsBusy)
                        {
                            Thread.Sleep(2000);
                        }
                        backgroundWorker1.RunWorkerAsync(argument: pedido);
                    }
                }
            }
            cargaInfo();
                
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Controllers.Logistica.Empaque.empaquePantallaController emp = new Controllers.Logistica.Empaque.empaquePantallaController();
            pedidoFulfill pedido= emp.fulfillment((Models.Transaccion.pedidoFulfill)e.Argument);
            e.Result = pedido;
            Console.WriteLine("ya mero termina");
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox.Visible = false;
            simpleButton2.ImageOptions.Image = null;
            if (e.Error != null)
            {
                MessageBox.Show("Error reintentar");
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Proceso Cancelado");

            }
            else
            {
                pedidoFulfill respuestaPedido =(pedidoFulfill) e.Result;
                respuesta result = new respuesta();
                result.result = respuestaPedido.error;  //PROBAR  DESERIALIZAR ERROR PARA OBTENER EL ID DE LA FACTURA.
                empaquePantallaController epc = new empaquePantallaController();
                epc.insertaErrorFulfilment(respuestaPedido);
           
                if(result.result.Contains("result"))
                    MessageBox.Show("PROCESO TERMINADO");
                else
                    MessageBox.Show("ERROR REVISAR");
                cargaInfo();

                Console.WriteLine("terminar");
            }
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cargaInfo();
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            PDFEmpaque pdf = new PDFEmpaque();
            pdf.Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            empaquePantallaController epc = new empaquePantallaController();

            byte[] pdf= epc.GetPDF(49781);
            MemoryStream ms = new MemoryStream(pdf);
            var pdfViewer2 = new DevExpress.XtraPdfViewer.PdfViewer();
            pdfViewer2.LoadDocument(ms);
            pdfViewer2.Print();
            
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                if ( gridView1.GetRowCellValue(info.RowHandle, colerror).ToString().Contains("Imprime"))
                {
                    empaquePantallaController epc = new empaquePantallaController();
                    string tipo = gridView1.GetRowCellValue(info.RowHandle, colFORMA).ToString().Contains("LOCAL") ? "2" : "1";
                    epc.ImprimirDirecto(gridView1.GetRowCellValue(info.RowHandle, colMovId).ToString(),tipo);
                }
            }
        }
    }

    
}
