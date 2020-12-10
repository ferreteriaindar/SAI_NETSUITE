using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SAI_NETSUITE.Views.Logistica.Distribucion
{
    public partial class GastoFleteras : UserControl
    {
        string xmlString;
        public GastoFleteras()
        {
            InitializeComponent();
        }

        private void GastoFleteras_Load(object sender, EventArgs e)
        {
            cargaVendors();
        }


        public void cargaVendors()
        {
            Controllers.Logistica.Distribucion.GastoFleterasController gfc = new Controllers.Logistica.Distribucion.GastoFleterasController();
            searchVendor.Properties.DataSource = gfc.regresaVendors();
            searchVendor.Properties.ValueMember = "ENTITY_ID";
            searchVendor.Properties.DisplayMember = "NAME";

        }

        private void searchVendor_EditValueChanged(object sender, EventArgs e)
        {
            gridControl1.DataSource = null;
            Controllers.Logistica.Distribucion.GastoFleterasController gfc = new Controllers.Logistica.Distribucion.GastoFleterasController();
            gridControl1.DataSource = gfc.regresaGuias(searchVendor.Properties.View.GetFocusedRowCellValue("PAQUETERIA_DISTRIBUCION_ID").ToString());
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            decimal importe = 0;
            txtImporteGuia.Text = "";
            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {


                importe += Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colImporteTotal).ToString());

            }
            txtImporteGuia.Text = importe.ToString();
            validadImportes();
        }


        public void validadImportes()
        {
            decimal guia,factura;
            if (Decimal.TryParse(txtImporteGuia.Text, out guia) && Decimal.TryParse(txtFactura.Text, out factura))
            {
                if (guia == factura)
                    btnRegistra.Enabled = true;
                else
                    btnRegistra.Enabled = false;
            }
            else
            {
                btnRegistra.Enabled = false;
            }

        }

        private void btnRegistra_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();

         //   doc.LoadXml(memoEdit1.Text);
            //doc.
            /*
            //cfdi: Emisor
            XmlNodeList nList=  doc.SelectNodes("/cfdi:emisor");
            foreach (XmlNode node in nList)
            {
                Console.WriteLine(node.Value);
            }*/
            /*   var nodes = doc.GetElementsByTagName("cfdi:Emisor");
               var href = nodes[0].Attributes["Nombre"];*/
            //cfdi:CfdiRelacionado
            var nodes = doc.GetElementsByTagName("cfdi:CfdiRelacionado");
            var href = nodes[0].Attributes["UUID"];
            string name = href.Value;
            string vendor = searchVendor.Properties.View.GetFocusedRowCellValue("NAME").ToString();
            if (vendor.Contains(name.ToUpper()))
                MessageBox.Show("Match");

        }

        private void btnCargaXml_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Title = "Busca Archivos XML",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "XML",
                Filter = "xml files (*.xml)|*.xml",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                xmlString = System.IO.File.ReadAllText(openFileDialog1.FileName);
                labelPath.Text = openFileDialog1.FileName;
            }

           
        }
    }
}
