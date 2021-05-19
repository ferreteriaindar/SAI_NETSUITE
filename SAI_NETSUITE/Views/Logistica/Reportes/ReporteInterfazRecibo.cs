using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAI_NETSUITE.Controllers.Logistica.Reportes;
using SAI_NETSUITE.Models.Transaccion;
using System.Diagnostics;
using System.IO;

namespace SAI_NETSUITE.Views.Logistica.Reportes
{
    public partial class ReporteInterfazRecibo : UserControl
    {
        public ReporteInterfazRecibo()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {

            if (dxValidationProvider1.Validate())
            {
                if (backgroundWorker1.IsBusy)
                    MessageBox.Show("Espera a que termine -_-!");
                else
                {
                    btnCargar.ImageOptions.Image = SAI_NETSUITE.Properties.Resources.gear;
                    backgroundWorker1.RunWorkerAsync(argument: dateEdit1.EditValue.ToString());
                }
            }
            else MessageBox.Show("Ingresa la Fecha");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string FechaIni = (string)e.Argument;
            DateTime date = Convert.ToDateTime(FechaIni);
            ReporteInterfazReciboController rirc = new ReporteInterfazReciboController();

            e.Result = rirc.cargaDatos(date.ToShortDateString());
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<ReporteInterfazReciboMix> resultado = (List<ReporteInterfazReciboMix>)e.Result;
            gridControl1.DataSource = resultado;
            btnCargar.ImageOptions.Image = null;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string path = Path.GetTempPath()+ @"interfazRecibo.xlsx";
            gridControl1.ExportToXlsx(path);
            Process.Start(path);
        }
    }
}
