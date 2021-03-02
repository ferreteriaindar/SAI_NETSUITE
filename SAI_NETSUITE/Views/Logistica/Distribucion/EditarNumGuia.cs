using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAI_NETSUITE.Controllers.Ventas;
using System.Data.SqlClient;

namespace SAI_NETSUITE.Views.Logistica.Distribucion
{
    public partial class EditarNumGuia : UserControl
    {


        string idNumeroGuia;
        public EditarNumGuia()
        {
            InitializeComponent();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EditarNumGuia_Load(object sender, EventArgs e)
        {
            cargaFleteras();

        }

        private void cargaFleteras()
        {
            SaleOrderSentController sosc = new SaleOrderSentController();
            sosc.getCustomersList();
            searchFletera.Properties.DataSource = sosc.listaPaqueterias;
            searchFletera.Properties.ValueMember = "LIST_ID";
            searchFletera.Properties.DisplayMember = "LIST_ITEM_NAME";
        }

        private void btnBuscarGuia_Click(object sender, EventArgs e)
        {
            CargaGuia();
            
        }

        private void CargaGuia()
        {


            SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString);

            string query = @"select idNumeroGuia,NumeroGuia,idPaqueteria from Indarneg.dbo.NumeroGuiaNetsuite  NG
                            INNER JOIN IWS.dbo.Paqueteria P on NG.idPaqueteria=P.LIST_ID
                            where numeroguia LIKE '%" + txtGuia.Text + "%'";
            
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            da.Fill(ds);
            try
            {
                if (!ds.Tables[0].Rows[0][1].ToString().Equals(""))
                {
                    searchFletera.EditValue = ds.Tables[0].Rows[0][2].ToString();
                    labelGuia.Text= ds.Tables[0].Rows[0][1].ToString();
                    idNumeroGuia= ds.Tables[0].Rows[0][0].ToString();

                }
            
             } catch (Exception ex)
            {
                MessageBox.Show("No encontramos  esa guia");
                labelGuia.Text = "*";
            }
            



        }

        private void btnActualiza_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate() && !idNumeroGuia.Equals( ""))
            {
                SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1);
                myConnection.Open();
                string query = "update Indarneg.dbo.NumeroGuiaNetsuite set NumeroGuia='" + txtNewGuia.Text + "',idPaqueteria="+searchFletera.EditValue.ToString()+" where idNumeroGuia=" + idNumeroGuia;
                SqlCommand cmd = new SqlCommand(query, myConnection);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Actualizado");
                    idNumeroGuia = "";
                    txtGuia.Text = "";
                    txtNewGuia.Text = "";
                    labelGuia.Text = "*";

                }
                else
                    MessageBox.Show("Error al Actualizar");
            }
        }
    }
}
