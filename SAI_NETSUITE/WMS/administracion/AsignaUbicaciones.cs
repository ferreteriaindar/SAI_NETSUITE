using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAI_NETSUITE.WMS.administracion
{
    public partial class AsignaUbicaciones : UserControl
    {
        string sqlString,sqlStringWms;
        public AsignaUbicaciones(string sql,string sqlWms)
        {
            sqlString = sql;
            sqlStringWms = sqlWms;
            InitializeComponent();
        }

        public void  cargaUsuarios()
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            string query = "select IdUsuario,nombre,Usuario from INDGDLSQL01.INDAR_InActionWMS.dbo.Usuario";

            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
       searchLookUpEdit1.Properties.DataSource = ds.Tables[0];
       searchLookUpEdit1.Properties.ValueMember = "IdUsuario";
        
        }

        private void AsignaUbicaciones_Load(object sender, EventArgs e)
        {
            cargaUsuarios();
            cargaPisos();
        }

        public void CargaLocalidadesUsuario(int id)
        {

            SqlConnection myConnection = new SqlConnection(sqlString);
            string query = @"SELECT u.Nombre,l.Codigo FROM  INDGDLSQL01.INDAR_InActionWMS.dbo.UsuarioLocalidad UL
                            left join INDGDLSQL01.INDAR_InActionWMS.dbo.Localidad L on ul.IdLocalidad=l.IdLocalidad
                            left join INDGDLSQL01.INDAR_InActionWMS.dbo.Usuario U on  ul.IdUsuario=u.IdUsuario  where ul.idUsuario=" + id.ToString();

            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            CargaLocalidadesUsuario(Convert.ToInt32(searchLookUpEdit1.EditValue.ToString()));
        }

        private void btnAsigna_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                DesAsigna();
            
            }
        }



        public void DesAsigna()
        {
            if(dxValidationProvider1.Validate())
            {
                int resultado = 0;
                string combo,idusuario;
              
                idusuario = searchLookUpEdit1.EditValue.ToString();
                string query = "DELETE FROM UsuarioLocalidad WHERE idusuario=" + idusuario;
                SqlConnection myConnection = new SqlConnection(sqlStringWms);
                myConnection.Open();

                SqlCommand cmd = new SqlCommand(query, myConnection);
                try
                {
                     resultado = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                if (resultado > 0)
                    MessageBox.Show("Usuario Liberado Correctamente");

            }

        }

        public void cargaPisos()
        {
            Console.WriteLine(sqlStringWms);
            SqlConnection myConnection = new SqlConnection(sqlStringWms);
            string query = "select IdArea,Nombre from Area where IdAlmacen=2 and IdArea>=32";

            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            searchLookUpEdit1.Properties.DataSource = ds.Tables[0];
            searchLookUpEdit1.Properties.ValueMember = "IdArea";
            searchLookUpEdit1.Properties.DisplayMember = "Nombre";
        
        
        }
    

    }
}
