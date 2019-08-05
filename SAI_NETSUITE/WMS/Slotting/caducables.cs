using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAI_NETSUITE.WMS.Slotting
{
    public partial class caducables : UserControl
    {
        string sqlString;
        public caducables(string sql)
        {
            sqlString = sql;
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                ActualizaArticulo(searArticulo.EditValue.ToString());
                
            }
        }

        public void ActualizaArticulo(string articulo)
        {
            int tipo, tiene,diasvigencia;
            if ((bool)toggleSwitch1.EditValue == true)
                tiene = 1;
            else tiene = 0;
            if ((bool)toggleSwitch2.EditValue == true)
                tipo = 1;
            else tipo = 0;
            if (tipo == 0)
                diasvigencia = 0;
            else diasvigencia = Convert.ToInt32(textEdit1.Text);
            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("",myConnection);
            cmd.CommandText = "update  INDAR_INACTIONWMS.dbo.estilo set TieneCaducidad=" + tiene.ToString() + ",Tipo_Caducidad=" + tipo.ToString() + ", diasvigencia="+diasvigencia.ToString()+" where clave='" + articulo + "'";
            Console.WriteLine(cmd.CommandText);
            int resultado = cmd.ExecuteNonQuery();
            if(resultado>=1)
                MessageBox.Show("Actualizacion Realizada");
            else MessageBox.Show("Algo Sucedio favor de verificar");

        
        
        
        }
        public void cargaArticulo()
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            //  string query = "select articulo from  art where estatus='ALTA'";
            string query = "select clave as articulo from INDAR_INACTIONWMS.dbo.estilo";
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            searArticulo.Properties.DataSource = ds.Tables[0];
            searArticulo.Properties.DisplayMember = "articulo";
            searArticulo.Properties.ValueMember = "articulo";
            myConnection.Close();

        }

        private void caducables_Load(object sender, EventArgs e)
        {
            cargaArticulo();
            textEdit1.Text = "1";
        }

        private void searArticulo_EditValueChanged(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            string query = "select descripcion from  INDAR_INACTIONWMS.dbo.estilo where clave='" + searArticulo.EditValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query, myConnection);
            myConnection.Open();
            labelArticulo.Text = cmd.ExecuteScalar().ToString();
            myConnection.Close();
            cargaEstatus(searArticulo.EditValue.ToString());
        }

        public void cargaEstatus(string articulo)
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            cmd.CommandText = "select TieneCaducidad,Tipo_Caducidad  from INDAR_INACTIONWMS.dbo.estilo where Clave='" + searArticulo.EditValue.ToString() + "'";
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read() && sdr.HasRows)
            {
                Console.WriteLine(sdr.GetValue(0).ToString());
                if (sdr.GetValue(0).ToString().Equals("True"))
                    toggleSwitch1.EditValue = true;
                else toggleSwitch1.EditValue = false;
                if (sdr.GetValue(1).ToString().Equals("True"))
                    toggleSwitch2.EditValue = true;
                else
                    toggleSwitch2.EditValue = false;
            
            }
            sdr.Close();
            cmd.Dispose();
            myConnection.Close();
            myConnection.Dispose();
        
        }

        private void toggleSwitch1_DockChanged(object sender, EventArgs e)
        {
            Console.WriteLine((bool)toggleSwitch1.EditValue);
            if ((bool)toggleSwitch1.EditValue == false)
            {
                toggleSwitch2.EditValue = false;
                toggleSwitch2.Visible = false;
                Console.WriteLine((bool)toggleSwitch1.EditValue);
               
            }
            else
            {
                toggleSwitch2.Visible = true;
                textEdit1.Visible = true;
            }
        }

        private void toggleSwitch2_DockChanged(object sender, EventArgs e)
        {
            if ((bool)toggleSwitch2.EditValue == true)
                textEdit1.Visible = true;
            else
                textEdit1.Visible = false;
        }

        private void toggleSwitch1_EditValueChanged(object sender, EventArgs e)
        {
            Console.WriteLine((bool)toggleSwitch1.EditValue);
            if ((bool)toggleSwitch1.EditValue == false)
            {
                toggleSwitch2.EditValue = false;
                toggleSwitch2.Visible = false;
                Console.WriteLine((bool)toggleSwitch1.EditValue);
                labelVigencia.Visible = false;

            }
            else
            {
                toggleSwitch2.Visible = true;
                textEdit1.Visible = true;
                labelVigencia.Visible = true;
            }
        }

        private void toggleSwitch2_EditValueChanged(object sender, EventArgs e)
        {

            if ((bool)toggleSwitch2.EditValue == true)
            {
                textEdit1.Visible = true;
                labelVigencia.Visible = true;
            }
            else
            {
                textEdit1.Visible = false;
                labelVigencia.Visible = false;
            }
        }
    }
}
