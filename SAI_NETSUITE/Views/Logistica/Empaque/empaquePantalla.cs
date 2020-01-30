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
using System.Diagnostics;

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

                if (!gridView1.GetRowCellValue(i, colPedido).ToString().Contains("Cons"))
                {
                    string pedido = gridView1.GetRowCellValue(i, colMovId).ToString();
                    gridView1.SetRowCellValue(i, colerror, epc.regresaErrorPedido(gridView1.GetRowCellValue(i, colPedido).ToString(), gridView1.GetRowCellValue(i, colMovId).ToString()));

                    /*REVISA SI YA  ESTA  FULL Y FACTURADA PARA INDICAR QUE SE TIMBRE DENTRO DE NETSUITE*/
                    if (gridView1.GetRowCellValue(i, colerror).Equals("TIMBRAR CFDI"))
                        gridView1.SetRowCellValue(i, colerror, epc.regresaNumFactura(gridView1.GetRowCellValue(i, colPedido).ToString(), gridView1.GetRowCellValue(i, colMovId).ToString()));
                    /*REVISA SI ESTA TIMBRADA LA FACTURA*/
                    string error = gridView1.GetRowCellValue(i, colerror).ToString();
                    if (gridView1.GetRowCellValue(i, colerror).ToString().Contains(":"))
                        gridView1.SetRowCellValue(i, colerror, epc.YaestaTimbrada(gridView1.GetRowCellValue(i, colPedido).ToString(), gridView1.GetRowCellValue(i, colMovId).ToString(), gridView1.GetRowCellValue(i, colerror).ToString()));
                    /***************************************/
                }
                else {
                    string numPedidos, numFacturas;
                    string cons = gridView1.GetRowCellValue(i, colMovId).ToString();
                    numPedidos = gridView1.GetRowCellValue(i, colPedidos).ToString();
                    numFacturas = gridView1.GetRowCellValue(i, colFacturas1).ToString();
                    if (gridView1.GetRowCellValue(i, colPedidos).ToString().Equals(gridView1.GetRowCellValue(i, colFacturas1).ToString()))
                        // gridView1.SetRowCellValue(i, colerror, epc.regresaInfoConsSinTimbrar(gridView1.GetRowCellValue(i, colMovId).ToString()));
                        gridView1.SetRowCellValue(i, colerror, "Timbra las Facturas");
                    if (gridView1.GetRowCellValue(i, colerror).ToString().Equals("Timbra las Facturas"))
                    {
                        //REVISA Si ya estan timbradas las facturas
                        gridView1.SetRowCellValue(i, colerror,epc.YaestaTimbradaCons(gridView1.GetRowCellValue(i,colMovId).ToString()));
                    }
                            

                }

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
            p.error = "";


            if (p.mov.Equals("Traspaso"))
            {

                pictureBox.Visible = true;
                labelStatus.Visible = true;
                simpleButton2.ImageOptions.Image = SAI_NETSUITE.Properties.Resources._835;
                List<pedidoFulfill> lista = new List<pedidoFulfill>();
                lista.Add(p);
                backgroundWorkerEventos.RunWorkerAsync(argument: lista);

            }
            else if (!backgroundWorker1.IsBusy) ///CUANDO ES UN PEDIDO NORMAL O  CONS
            {
                pictureBox.Visible = true;
                labelStatus.Visible = true;
                simpleButton2.ImageOptions.Image = SAI_NETSUITE.Properties.Resources._835;

                if (!p.mov.Contains("Cons") && !p.mov.Contains("Traspaso") ) //Cuando es un pedido normal
                {
                    List<pedidoFulfill> lista = new List<pedidoFulfill>();
                    lista.Add(p);
                    backgroundWorker1.RunWorkerAsync(argument: lista);
                }
                else if(!p.mov.Equals("salesorder") && !p.mov.Contains("Traspaso"))/// cuando es una CONS
                {
                    empaquePantallaController epc = new empaquePantallaController();
                    List<pedidoFulfill> lista = epc.listadoCons(p.movid);                  
                    backgroundWorker1.RunWorkerAsync(argument: lista);
                }
            }
            cargaInfo();
                
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            /*
            Controllers.Logistica.Empaque.empaquePantallaController emp = new Controllers.Logistica.Empaque.empaquePantallaController();
            pedidoFulfill pedido= emp.fulfillment((Models.Transaccion.pedidoFulfill)e.Argument);
            e.Result = pedido;
            Console.WriteLine("ya mero termina");*/
            List<pedidoFulfill> lista =(List<pedidoFulfill>)e.Argument;
            List<pedidoFulfill> regreso = new List<pedidoFulfill>();
            foreach (var pedido in lista)
            {
                backgroundWorker1.ReportProgress(1);
                Controllers.Logistica.Empaque.empaquePantallaController emp = new Controllers.Logistica.Empaque.empaquePantallaController();
                pedidoFulfill p = emp.fulfillment(pedido, sender as BackgroundWorker);
                regreso.Add(p);
            }
            e.Result = regreso;

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox.Visible = false;
            labelStatus.Text = "Inicio";
            labelStatus.Visible = false;
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

                List<pedidoFulfill> lista = (List<pedidoFulfill>)e.Result;
                foreach (var pedido in lista)
                {
                    pedidoFulfill respuestaPedido = pedido;
                    respuesta result = new respuesta();
                    result.result = respuestaPedido.error;  //PROBAR  DESERIALIZAR ERROR PARA OBTENER EL ID DE LA FACTURA.
                    empaquePantallaController epc = new empaquePantallaController();
                    epc.insertaErrorFulfilment(respuestaPedido);
                }
                if( lista[0].error.Contains("result"))
                    MessageBox.Show("PROCESO TERMINADO");
                else
                    MessageBox.Show("ERROR REVISAR CON SISTEMAS");
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
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
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
                    if (gridView1.GetRowCellValue(info.RowHandle, colPedido).ToString().Contains("Cons"))
                    {
                        List<pedidoFulfill> listado = new List<pedidoFulfill>();
                        listado = epc.listadoCons(gridView1.GetRowCellValue(info.RowHandle, colMovId).ToString());
                        foreach (var pedido in listado)
                        {
                            epc.ImprimirDirecto(pedido.movid, tipo,true,false);
                            
                        }
                        epc.ImprimirPackingCons(gridView1.GetRowCellValue(info.RowHandle, colMovId).ToString(), "2");
                        epc.ImprimirPackingCons(gridView1.GetRowCellValue(info.RowHandle, colMovId).ToString(), "1");
                    }
                    else epc.ImprimirDirecto(gridView1.GetRowCellValue(info.RowHandle, colMovId).ToString(),tipo,false,false);
                }
                if (gridView1.GetRowCellValue(info.RowHandle, colPedido).ToString().Contains("Cons")&& gridView1.GetRowCellValue(info.RowHandle, colerror).ToString().Contains("Timbra las Facturas"))
                {//INDICA LAS FACTURAS DE LA CONS QUE TIENE QUE TIMBRAR
                    empaquePantallaController epc = new empaquePantallaController();
                    MessageBox.Show( epc.regresaInfoConsSinTimbrar(gridView1.GetRowCellValue(info.RowHandle, colMovId).ToString()));
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage.ToString())
            {
                case "1":  labelStatus.Text = "Fulfillment";
                    break;
                case "2": labelStatus.Text = "Facturando";
                    break;
            }
        }

        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            switch (comboReimprmir.Text)
            {
                case "FACTURA":
                    empaquePantallaController epc = new empaquePantallaController();
                    string idfactura = epc.regresaIdFactura(txtReimprimir.Text);
                    if (idfactura.Equals("error"))
                        MessageBox.Show("No existe Factura");
                    else
                    {
                        pdfController pdfc = new pdfController();
                        pdfc.imprimePDFyPacking(idfactura, "2");
                        pdfc.imprimePDFyPacking(idfactura, "1");
                    }
                    break;
                case "CONS":
                    pdfController pc = new pdfController();
                    pc.imprimePDFyPackingCons(txtReimprimir.Text, "2");
                    pc.imprimePDFyPackingCons(txtReimprimir.Text, "1");
                    break;
            }

        }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            
        }

        private void backgroundWorkerEventos_DoWork(object sender, DoWorkEventArgs e)
        {
            List<pedidoFulfill> lista = (List<pedidoFulfill>)e.Argument;
            bool regreso=false;
            foreach (var pedido in lista)
            {
               
                Controllers.Logistica.Empaque.empaquePantallaController emp = new Controllers.Logistica.Empaque.empaquePantallaController();
                 regreso = emp.fulfillmentTraspaso(pedido, sender as BackgroundWorker);
               
            }
            e.Result = regreso;
        }

        private void backgroundWorkerEventos_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox.Visible = false;
            labelStatus.Text = "Inicio";
            labelStatus.Visible = false;
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
                bool resultado =(bool)e.Result;
                if (resultado)
                {
                    
                    MessageBox.Show("Proceso Terminado");
                }
                else MessageBox.Show("Error");
            }
        }
    }

    
}
