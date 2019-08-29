using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace SAI_NETSUITE.Views.Logistica.Distribucion
{
    public partial class AutorizacionJefe : Form
    {
        public  static TextBox t = new TextBox(),t2 = new TextBox();
        public static ComboBox combo = new ComboBox();
        public static ListView list = new ListView();
        string sqlString,embarque,guia,tipo,factura,cliente;
        public DialogResult dr = DialogResult.Cancel;
        bool faltantes = false;
        public AutorizacionJefe(string sql,string emb,string numeroguia,string errotipo,string fac,bool faltante,string factFaltantes,string cte)
        {
           
            sqlString = sql;
            embarque = emb;
            guia = numeroguia;
            tipo = errotipo;
            factura = fac;
            cliente = cte;
            InitializeComponent();
            t = txtError;
            t2 = txtSolucion;
            combo = ComboJefe;
            list = lista;
            faltantes = faltante;
            if (faltantes == true)
            {
                labelFaltantes.Visible = true;
                lista.Visible = true;
                cargaFaltantes(factFaltantes);
            }
            LabelTitulo.Text = "AUTORIZAR DOCUMENTOS";

        }
        public AutorizacionJefe(string sql, string emb, string numeroguia, string errotipo, string fac)
        {

            sqlString = sql;
            embarque = emb;
            guia = numeroguia;
            tipo = errotipo;
            factura = fac;

            InitializeComponent();
            t = txtError;
            t2 = txtSolucion;
            combo = ComboJefe;
       

        }


        public void cargaFaltantes(string facturas)
        {
            string concatena = "";
            string[] lines = Regex.Split(facturas, "@");
            Console.WriteLine(lines.Length-1);
            for (int i = 0; i < lines.Length-1; i++)
            {
                concatena = concatena + lines[i];
                if (( lines.Length-1)-i!=1)
                    concatena = concatena + "','";

            }

            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            //cmd.CommandText = "select EM.MOVID  from  EmbarqueD ed   "+
            //                   "   JOIN EmbarqueMov em ON ED.EmbarqueMov=EM.ID    "+
            //                   "   where  em.modulo='VTAS'  "+
            //                   "   and em.asignadoid=(select id from embarque where movid='"+embarque+"' and mov='Embarque')  "+
            //                   "  and em.cliente='"+cliente+"'  AND EM.MOVID NOT IN('"+concatena+"')";
            cmd.CommandText = " select movid from embarquemov where asignadoid=(select id from embarque where movid='" + embarque + "' and mov='Embarque') " +
                              "   and cliente='"+cliente+"'  and MOVID NOT IN('"+concatena+"')";
            Console.WriteLine(cmd.CommandText);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
              
                lista.Items.Add(sdr.GetValue(0).ToString());
            }
            myConnection.Close();
           
                
        }

        public void cargaJefes()

        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            string query = " select nombre from indarneg.dbo.sai_usuario  where perfil='Jefe Almacen' or usuario='Mvillalvazo'";
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ComboJefe.DataSource = ds.Tables[0];
            ComboJefe.ValueMember = "nombre";
            ComboJefe.DisplayMember = "nombre";
        }

        private void AutorizacionJefe_Load(object sender, EventArgs e)
        {
            cargaJefes();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.dr = DialogResult.Cancel;
            this.Close();
        }

        private void btnAutorizar_Click(object sender, EventArgs e)
        {
            if (ValidaContrasena())
            {
                if (!txtError.Text.Equals("") && !txtSolucion.Text.Equals(""))
                {

                    registraElErrro();
                    enviaEmail(ComboJefe.Text, factura, txtError.Text, txtSolucion.Text);


                    this.dr = DialogResult.OK;
                    this.Close();
                }
                else MessageBox.Show("Todos los campos son Obligatorios");
            }
            else MessageBox.Show("Usuario Y/O contraseña Invalidos");
        }




        public void enviaEmail(string autoriza, string factura, string error, string solucion)
        {
            MailMessage mail = new MailMessage();
            //mail.Attachments.Add(att);
            mail.From = new MailAddress("alertas@indar.com.mx", "Numero de Guia Indar");
            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            string query = " select email from indarneg.dbo.sai_usuario  where perfil='Jefe Almacen' or usuario='Mvillalvazo'";
            SqlCommand cmd = new SqlCommand(query, myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                mail.To.Add(new MailAddress(sdr.GetValue(0).ToString()));
            }
          //  mail.To.Add(new MailAddress("rvelasco@indar.com.mx"));
            mail.Subject = "Autorizacion de Registro de Numero de Guia";
            if (faltantes == true)
            { 
                factura="";
                for (int i = 0; i < list.Items.Count; i++)
                    factura = factura + list.Items[i].SubItems[0].Text + ",";
            }
            mail.Body = autoriza + " Autorizó el registro del numero de guia: "+guia+" en la factura " + factura + " \n ERROR: " + error + " \n  SOLUCION: " + solucion + " \n \n \n \n Mensaje Generado desde el SAI";
            SmtpClient smtp = new SmtpClient("mail.indar.com.mx");
           // smtp.Send(mail); HABILILTAR DE NUEVO SI LO PIDEN, 20/08/2019  ACTUALIZAR EL SERVIDOR Y EL EMAIL DE ENVIO YA NO SIRVEN

        }

        public void registraElErrro()
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            if (faltantes==false)
            {
                cmd.CommandText = "insert into indarneg.dbo.autorizacionnumeroguia (embarque,autoriza,error,solucion,tipo,fecha,guia,factura) values (" +
                                " '" + embarque + "','" + ComboJefe.Text + "','" + txtError.Text + "','" + txtSolucion.Text + "','" + tipo + "',getdate(),'" + guia + "','"+factura+"')";
                cmd.ExecuteNonQuery();
            }
            else
            {
                Console.WriteLine("si entro");
                for (int i = 0; i < lista.Items.Count; i++)
                {
                    cmd.CommandText = "insert into indarneg.dbo.autorizacionnumeroguia (embarque,autoriza,error,solucion,tipo,fecha,guia,factura) values (" +
                                " '" + embarque + "','" + ComboJefe.Text + "','" + txtError.Text + "','" + txtSolucion.Text + "','" + tipo + "',getdate(),'" + guia + "','" + lista.Items[i].SubItems[0].Text + "')";
                    cmd.ExecuteNonQuery();
                }
            }
            myConnection.Close();
        }


        public bool ValidaContrasena()
        {
            string query = "  SELECT count(usuario) FROM indarneg.dbo.sai_usuario WHERE nombre='"+ComboJefe.Text+"' AND pass='"+txtpass.Text+"'";
            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand(query, myConnection);
            var resultado = cmd.ExecuteScalar().ToString();
            if (resultado.ToString().Equals("1"))
                return true;
            else return false;

        }


        public void desembarca()
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
             for (int i = 0; i < lista.Items.Count; i++)
             {
                 cmd.CommandText = "update embarqued set estado= 'Desembarque Distribucion'  wh";
             }

        
        }
        private void btnDesembarcar_Click(object sender, EventArgs e)
        {
            if (ValidaContrasena())
            {
                if (!txtError.Text.Equals("") && !txtSolucion.Text.Equals(""))
                {
                    registraElErrro();
                    enviaEmail(ComboJefe.Text, factura, txtError.Text, txtSolucion.Text);


                    this.dr = DialogResult.Cancel;
                    this.Close();
                }
                else MessageBox.Show("Todos los campos son Obligatorios");
            }
            else MessageBox.Show("Usuario Y/O contraseña Invalidos");
        }
        
    }
}
