using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAI_NETSUITE.WMS.WMS
{
    public partial class CodigoBarras : UserControl
    {
        string sqlString;
        public CodigoBarras(string sql)
        {
            sqlString = sql;
         
            InitializeComponent();
        }

        private void CodigoBarras_Load(object sender, EventArgs e)
        {
            cargaArticulo();
        }

        public void cargaArticulo()
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
          //  string query = "select articulo from  art where estatus='ALTA'";
            string query = "select clave as articulo from INDGDLSQL01.INDAR_INACTIONWMS.dbo.estilo";
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            searArticulo.Properties.DataSource = ds.Tables[0];
            searArticulo.Properties.DisplayMember = "articulo";
            searArticulo.Properties.ValueMember = "articulo";
            myConnection.Close();
        
        }

        private void searArticulo_EditValueChanged(object sender, EventArgs e)
        {

            SqlConnection myConnection = new SqlConnection(sqlString);
            string query = "select descripcion from  INDGDLSQL01.INDAR_INACTIONWMS.dbo.estilo where clave='" + searArticulo.EditValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query, myConnection);
            myConnection.Open();
            labelArticulo.Text = cmd.ExecuteScalar().ToString();
            myConnection.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                SqlConnection myConnection = new SqlConnection(sqlString);
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText = @"INSERT INTO INDGDLSQL01.INDAR_INACTIONWMS.int.ArticuloUPC (articulo,TipoEmpaque,Capacidad,UPC)
                              values ('"+searArticulo.EditValue.ToString()+"','"+comboEmpaque.Text+"',"+txtCapaciddad.Text+",'"+txtUPC.Text+"')";
                try
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Codigo de Barras \n registrado");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else
                MessageBox.Show("Ingresa todos los datos");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtUPC.Text = "";
            txtCapaciddad.Text = "";
            comboEmpaque.Text = "";
            labelArticulo.Text = "";
        }
    }
}
