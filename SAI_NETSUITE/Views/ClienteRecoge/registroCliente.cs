using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAI_NETSUITE.Views.ClienteRecoge
{
    public partial class registroCliente : Form
    {
        SqlConnection myConnection;
        string nombre, perfil,sqlString;
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        SqlConnection myConnection2 = new SqlConnection("Data Source=192.168.87.100;" + "Initial Catalog=Indarneg;" + "User id=sa;" + "Password=7Ind4r7;");

        public registroCliente(SqlConnection conn, string nom,string profile,string sql)
        {
            myConnection=conn;
            nombre=nom;
            perfil=profile;
            sqlString = sql;
            InitializeComponent();
        }

        private void registroCliente_Load(object sender, EventArgs e)
        {

            myConnection.Open();

            string querry = @" select nombre from cte";
            // make connection to databse and get data using datareader
            SqlCommand cmd = new SqlCommand(querry, myConnection);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows == true)
            {
                while (dr.Read())
                    namesCollection.Add(dr[0].ToString());

            }

            dr.Close();

            txtEmpresa.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
       txtEmpresa.AutoCompleteSource = AutoCompleteSource.CustomSource;
       txtEmpresa.AutoCompleteCustomSource = namesCollection;

            myConnection.Close();
        }


        public string regresaCodigo(string nombre)
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            string query = "select cliente from cte where nombre='" + txtEmpresa.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, myConnection);
           var  resultaldo ="";
              resultaldo = cmd.ExecuteScalar().ToString();
            myConnection.Close();
            return resultaldo;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            string cliente = "";
            if (checkVendedor.Checked == true)
            {
                if (txtCodigo.Text.Equals(""))
                {
                    myConnection.Close();
                    myConnection.Open();
                    string query = "select cliente from cte where nombre='" + txtEmpresa.Text + "' and estatus in ('ALTA','BLOQUEADO')";
                    SqlCommand cmd = new SqlCommand(query, myConnection);
                    cliente = cmd.ExecuteScalar().ToString();
                    myConnection.Close();
                }
                else cliente = txtCodigo.Text;
                myConnection2.Close();
                myConnection2.Open();
                SqlCommand cmd2 = new SqlCommand("", myConnection2);
                cmd2.CommandText=" set dateformat dmy insert into indarneg.dbo.cterecogeclientes(cliente,nombre,hora) select agente,nombre,getdate() from agente where agente='" + txtCodigo.Text + "'";
              //  cmd2.CommandText = " set dateformat dmy insert into cterecogeclientes (cliente,nombre,hora) values('" + cliente + "','" + textBox1.Text + "',getdate())";
                cmd2.ExecuteNonQuery();
                myConnection2.Close();
                MessageBox.Show("Registrado con Exito\n Bienvenido");
                textBox1.Text = "";
                txtEmpresa.Text = "";
                txtCodigo.Text = "";
            }
            else 
            {
                SqlConnection myConnectionInt = new SqlConnection(sqlString);
                myConnectionInt.Open();
                SqlCommand cmdInt = new SqlCommand("", myConnectionInt);
                if (checkGDL.Checked)
                {
                    if(!txtCodigo.Text.Equals(""))
                    cmdInt.CommandText = "set dateformat dmy insert into indarneg.dbo.cterecogeclientes(cliente,nombre,hora,sucursal) select cliente,nombre,getdate(),'7' as sucursal from cte where cliente='" + txtCodigo.Text + "'";
                    else cmdInt.CommandText = "set dateformat dmy insert into indarneg.dbo.cterecogeclientes(cliente,nombre,hora,sucursal) select cliente,nombre,getdate(),'7' as sucursal from cte where cliente='" +regresaCodigo(txtEmpresa.Text) + "'";

                    Console.WriteLine("SI REGISTRA EL 7");
                }
                else
                {
                    if (!txtCodigo.Text.Equals(""))
                    cmdInt.CommandText = " set dateformat dmy insert into indarneg.dbo.cterecogeclientes (cliente,nombre,hora) values('" + txtCodigo.Text + "','" + textBox1.Text + "',getdate())";
                    else cmdInt.CommandText = "set dateformat dmy insert into indarneg.dbo.cterecogeclientes(cliente,nombre,hora) select cliente,nombre,getdate() as sucursal from cte where cliente='" + regresaCodigo(txtEmpresa.Text) + "'";

                    Console.WriteLine("NORMAL");
                }

                cmdInt.ExecuteNonQuery();
                myConnectionInt.Close();
                MessageBox.Show("Registrado con Exito\n Bienvenido");
                textBox1.Text = "";
                txtEmpresa.Text = "";
                txtCodigo.Text = "";
                checkVendedor.Checked = false;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            txtEmpresa.Text = "";
            txtCodigo.Text = "";
        }
    }
}
