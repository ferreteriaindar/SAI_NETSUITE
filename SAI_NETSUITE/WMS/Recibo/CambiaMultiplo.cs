using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAI_NETSUITE.WMS.Recibo
{
    public partial class CambiaMultiplo : UserControl
    {
        string sqlString;
        public CambiaMultiplo(string sql)
        {
            sqlString = sql;
            InitializeComponent();
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

        private void CambiaMultiplo_Load(object sender, EventArgs e)
        {
            cargaArticulo();
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

        private void btmGuardar_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                SqlConnection myConnection = new SqlConnection(sqlString);
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText = "update INDGDLSQL01.INDAR_INACTIONWMS.dbo.estilo set multiplorecibo=" + txtMultiplo.Text + " where  clave='" + searArticulo.EditValue.ToString() + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Actualizado");
                txtMultiplo.Text = "";
 
                
            
            }
        }
    }
}
