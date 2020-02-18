using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;

namespace SAI_NETSUITE.Views.Logistica.Empaque
{
    public partial class ReimprimirFactura : UserControl
    {
        public ReimprimirFactura()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Controllers.Logistica.Empaque.empaquePantallaController epc = new Controllers.Logistica.Empaque.empaquePantallaController();
                string tipo = txtFactura.Text == "Local" ? "1" : "2";
                epc.ImprimirDirecto(txtFactura.Text, tipo, false,true);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al obtener el PDF \n Ingresa a Netsuite e Imprimela");
            }
        }

        private void btnPacking_Click(object sender, EventArgs e)
        {
            try
            {
                Controllers.Logistica.Empaque.pdfController pdf = new Controllers.Logistica.Empaque.pdfController();
                string tipo = combotipo.Text.Contains("Local") ? "1" : "2";
                if (txtPedido.Text.ToUpper().Contains("CONS"))
                    pdf.imprimePDFyPackingCons(txtPedido.Text, tipo);
                else pdf.imprimePDFyPacking(txtPedido.Text, tipo);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al obtener el PDF \n Ingresa a Netsuite e Imprimela");
            }
        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {
            Controllers.Logistica.Empaque.FacturaIndarController fic = new Controllers.Logistica.Empaque.FacturaIndarController();
            DataSet ds = fic.regresaDatosCabecera(50530);
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

        }
    }
}
