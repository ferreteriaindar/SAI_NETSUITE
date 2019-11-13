using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
