using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAI_NETSUITE
{
    public partial class Login : Form
    {

        string resultado = "";
        string conString, usuario,perfil,sucursal;
        public Login()
        {
            InitializeComponent();
           
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            /*
            conString = "Dsn=NetSuite;uid="+txtEmail.Text+";pwd="+txtPass.Text;//ConfigurationManager.ConnectionStrings["NetSuite"].ConnectionString;
            try
            {
                using (OdbcConnection con = new OdbcConnection(conString))
                {
                    
                    con.Open();
                    string query = "select email from Employees where email='" + txtEmail.Text + "'";
                    OdbcCommand cmd = new OdbcCommand(query, con);
                    var queryResult = cmd.ExecuteScalar().ToString();
                    Console.WriteLine(queryResult);
                    resultado = "OK";
                    con.Close();
                }
            }
            catch (OdbcException ex)
            {
                Console.WriteLine(ex.Message);
                resultado = "Error";
            }*/
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText = "select usuario,perfil,isnull(sucursal,'1')as sucursal from Indarneg.dbo.sai_usuario where  usuario=@usuario and pass=@pass";
                cmd.Parameters.AddWithValue("@usuario", txtEmail.Text);
                cmd.Parameters.AddWithValue("@pass", txtPass.Text);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows&& sdr.Read())
                {
                    usuario = sdr.GetValue(0).ToString();
                    perfil = sdr.GetValue(1).ToString();
                    sucursal = sdr.GetValue(2).ToString();
                    resultado = "OK";
                }
                else
                {
                    resultado = "Error";
                   // MessageBox.Show("Usuario y/o Contraseña incorrectos");
                }
            }
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            pictureLoading.Visible = true;
            labelError.Visible = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureLoading.Visible = false;
            switch (resultado)
            {
                case "OK":
                    this.Hide();
                    registraUltimoInicioSesion(usuario);
                    Principal p = new Principal(conString,usuario,perfil,sucursal);
                    p.Show();

                    break;
                case "Error": 
                    labelError.Visible = true;
                    break;
            }
        }

        private void registraUltimoInicioSesion(string usuario)
        {
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText = "update  Indarneg.dbo.sai_usuario  set ultimoInicioSesion=getdate() where  usuario=@usuario";
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.ExecuteNonQuery();

            }
        }

            private void Form1_Load(object sender, EventArgs e)
        {
            txtEmail.Focus();
        }



    }
}
