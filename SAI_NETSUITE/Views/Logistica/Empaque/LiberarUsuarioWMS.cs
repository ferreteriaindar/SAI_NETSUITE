using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace SAI_NETSUITE.Views.Logistica.Empaque
{
    public partial class LiberarUsuarioWMS : UserControl
    {
        public LiberarUsuarioWMS()
        {
            InitializeComponent();
        }

        private void LiberarUsuarioWMS_Load(object sender, EventArgs e)
        {
            cargaUsuarios();
        }



        public void cargaUsuarios()
        {
            using (INDAR_INACTIONWMSEntities wms = new INDAR_INACTIONWMSEntities())
            {
                var lista = from u in wms.Usuario.Where(x => x.Activo == true) select new { name = u.Usuario1, nombre = u.Nombre };
                searchLookUpEdit1.Properties.DataSource = lista.ToList();
                searchLookUpEdit1.Properties.DisplayMember = "name";
                searchLookUpEdit1.Properties.ValueMember = "name"; 

            }



        }

        private void btnLibera_Click(object sender, EventArgs e)
        {/*
            try
            {
                using (IndarnegEntities ctx = new IndarnegEntities())
                {
                    var resultado = ctx.spLiberaUsuarioWMS(searchLookUpEdit1.EditValue.ToString());
                    MessageBox.Show("Liberado");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la transacción");
            }*/

            try
            {
                using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1))
                {
                    string query = "EXEC Indarneg.dbo.spLiberaUsuarioWMS '" + searchLookUpEdit1.EditValue.ToString() + "'";
                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand(query, myConnection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Liberado");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en liberar");
            }
        }
    }
}
