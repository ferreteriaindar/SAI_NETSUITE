using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace SAI_NETSUITE.Views.PostVenta
{
    public partial class RegistrodeGuias : UserControl
    {
        string usuario;
        bool desdAlmacen;
        public TextBox TextBoxRegresa;
        public RegistrodeGuias(string user,bool desdAlmacen)
        {
            usuario = user;
            this.desdAlmacen = desdAlmacen;
            InitializeComponent();
        }

        private void RegistrodeGuias_Load(object sender, EventArgs e)
        {
            cargaVendors();
            cargaMunicipios();
            cargaDepartments();
            cargaClasificadores();
            TextBoxRegresa = new TextBox();
        }



        public void cargaVendors()
        {
            Controllers.Logistica.Distribucion.GastoFleterasController gfc = new Controllers.Logistica.Distribucion.GastoFleterasController();
            searchVendor.Properties.DataSource = gfc.regresaVendors();
            searchVendor.Properties.ValueMember = "ENTITY_ID";
            searchVendor.Properties.DisplayMember = "NAME";

        }

        public void cargaDepartments()
        {
            Controllers.PostVenta.RegistroGuiasController rgc = new Controllers.PostVenta.RegistroGuiasController();
            searchDepartment.Properties.DataSource = rgc.GetDepartments();
            searchDepartment.Properties.ValueMember = "DEPARTMENT_ID";
            searchDepartment.Properties.DisplayMember = "NAME";
        }

        public void cargaMunicipios()
        {
            Controllers.PostVenta.RegistroGuiasController rgc = new Controllers.PostVenta.RegistroGuiasController();
            searchMunicipio.Properties.DataSource = rgc.GetMunicipio_Estados();
            searchMunicipio.Properties.ValueMember = "municipio";
            searchMunicipio.Properties.DisplayMember = "municipio";

        }


        public void cargaClasificadores()
        {

            List<string> lista = new List<string>();
            lista.Add("Devolucion");
            lista.Add("Compras");
            lista.Add("Documentos");
            lista.Add("Venta");

            comboBoxEdit1.Properties.Items.AddRange(lista);

        }

        private void btnRegistra_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                Controllers.PostVenta.RegistroGuiasController rgc = new Controllers.PostVenta.RegistroGuiasController();
                if (!rgc.guiaRepetida(txtGuia.Text,desdAlmacen))
                {
                    GridView view = searchVendor.Properties.View;
                    int rowHandle = view.FocusedRowHandle;
                    string fieldName = "PAQUETERIA_DISTRIBUCION_ID"; // or other field name  
                    object value = view.GetRowCellValue(rowHandle, fieldName);

                    if (rgc.registrGuia(txtGuia.Text, txtImporte.Text, searchDepartment.EditValue.ToString(), searchDepartment.EditValue.ToString(), searchMunicipio.EditValue.ToString(), searchMunicipio.Properties.View.GetFocusedRowCellValue("estado").ToString(), comboBoxEdit1.Text, value.ToString(), usuario))
                    {
                        TextBoxRegresa.Text = txtGuia.Text;
                        MessageBox.Show("Registrado con Exito");
                    }
                    else MessageBox.Show("Hubo un problema al registrar el numero de guia");
                }
                else
                {
                    txtGuia.ErrorText = "Repetido";
                    MessageBox.Show("Ya existe esa Guia");
                }
            }
            else MessageBox.Show("Captura todos los datos");
        }
    }
}
