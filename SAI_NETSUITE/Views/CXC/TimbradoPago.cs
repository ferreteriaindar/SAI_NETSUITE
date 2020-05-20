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
using Newtonsoft.Json;
using System.Diagnostics;

namespace SAI_NETSUITE.Views.CXC
{
    public partial class TimbradoPago : UserControl
    {
        public TimbradoPago()
        {
            InitializeComponent();
        }

        private void btnCargaInfo_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerCarga.IsBusy)
            {
                MessageBox.Show("Espera a que terminer (-_-)!");
            }
            else
            {
                btnCargaInfo.ImageOptions.Image = SAI_NETSUITE.Properties.Resources.gear;
                backgroundWorkerCarga.RunWorkerAsync();
            }
        }

        private void backgroundWorkerCarga_DoWork(object sender, DoWorkEventArgs e)
        {
            Controllers.CXC.TimbrarPagoController tpc = new Controllers.CXC.TimbrarPagoController();
            NonCertifiedPaymentSearchModel ncps = tpc.cargaInfo();
            foreach (var item in ncps.result.Resultados.Documentos)
            {
                item.error = tpc.tieneErrorPago(item.internalId);
            }
            e.Result = ncps;
        }

        private void backgroundWorkerCarga_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            NonCertifiedPaymentSearchModel ncps = (NonCertifiedPaymentSearchModel)e.Result;                    
            gridControl1.DataSource = ncps.result.Resultados.Documentos.ToList();
            btnCargaInfo.ImageOptions.Image = null;
        }

        private void btnTimbrar_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount < 1)
                MessageBox.Show("Seleciona al menos un pago (-_-)!");
            else
            {
                label1.Text = "0/" + gridView1.SelectedRowsCount.ToString();
               btnTimbrar.ImageOptions.Image = SAI_NETSUITE.Properties.Resources.gear;
                List<DocumentosPaymentInvoice> lista = new List<DocumentosPaymentInvoice>();
                for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                {
                    int internalPAgo = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], "internalId").ToString());
                    string tranidPago = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], "NumDoc").ToString();
                    DocumentosPaymentInvoice dpi = new DocumentosPaymentInvoice()
                    {
                        internalId = internalPAgo,
                        NumDoc =tranidPago

                    };
                lista.Add(dpi);
                }
                backgroundWorkerTimbra.RunWorkerAsync(argument: lista);
            }
        }

        private void backgroundWorkerTimbra_DoWork(object sender, DoWorkEventArgs e)
        {
            List<DocumentosPaymentInvoice> lista = e.Argument as List<DocumentosPaymentInvoice>;
            int avance = 0;
            foreach (var item in lista)
            {
                System.Threading.Thread.Sleep(2000);
                IWS.Connection con = new IWS.Connection();
                string json = JsonConvert.SerializeObject(item);
               string resultado= con.POST("api/Timbrado/CustomerPaymentCFDI", json, SAI_NETSUITE.Properties.Resources.token);
                using (IWSEntities context = new IWSEntities())
                {
                    errorTimbradoPago errorTimbradoPago = new errorTimbradoPago()
                    {
                        error = resultado.Contains("org.mozilla.javascript.")?"Reintentar":resultado,
                        fecha = DateTime.Now,
                        internalId = item.internalId,
                        tranid = item.NumDoc
                    };
                    context.errorTimbradoPago.Add(errorTimbradoPago);
                    context.SaveChanges();
                }
                avance++;
                backgroundWorkerTimbra.ReportProgress(avance);
            }
        }

        private void backgroundWorkerTimbra_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnTimbrar.ImageOptions.Image = null;
            MessageBox.Show("Proceso Terminado \n Revisa si hay errores actualizando");
            label1.Text = "0/0";
        }

        private void backgroundWorkerTimbra_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
          label1.Text=  e.ProgressPercentage.ToString() + "/" + gridView1.SelectedRowsCount.ToString();
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
    }
}
