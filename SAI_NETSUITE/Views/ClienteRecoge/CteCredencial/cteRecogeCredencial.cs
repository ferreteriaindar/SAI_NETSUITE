using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Camera;
using System.Data.SqlClient;
using System.IO;

namespace  SAI_NETSUITE.Views.ClienteRecoge.CteCredencial  //SAI_NETSUITE.Procesos.CteRecoge.Credencial
{
    public partial class cteRecogeCredencial : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        string sqlString;
        public cteRecogeCredencial(string sql)
        {
            sqlString = sql;
            InitializeComponent();
        }
        public cteRecogeCredencial(string sql,string cliente)
        {
            sqlString = sql;
            
            InitializeComponent();
            barEditClienteTxt.EditValue = cliente;
            barButtonBuscar_ItemClick(null, null);
        }

        private void Btn1Crear_Click(object sender, EventArgs e)
        {
            string id = "";
            if (validador1.Validate())
            {
                SqlConnection myConnection2 = new SqlConnection(sqlString);
                myConnection2.Open();
                SqlCommand cmd2 = new SqlCommand("", myConnection2);
                cmd2.CommandText = "insert into indarneg.dbo.credencialcliente (cliente,nombre,tarjeta,ocupacion) values('" +
                                barEditClienteTxt.EditValue.ToString() + "','" + txt1Nombre.Text + "',1,'" + txt1Ocupacion.Text + "') SELECT SCOPE_IDENTITY()";
                MessageBox.Show("si entra");
                id = cmd2.ExecuteScalar().ToString();
                myConnection2.Close();
                TakePictureDialog d = new TakePictureDialog();

                if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    Image i = d.Image;
                    i.Save(@"C:\foto\foto.jpg");
                    picture1.Image = i;
                    picture1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                    SqlConnection myConnection = new SqlConnection(sqlString);
                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand("", myConnection);
                    byte[] arr;
                    ImageConverter converter = new ImageConverter();
                    arr = (byte[])converter.ConvertTo(i, typeof(byte[]));
                    cmd.CommandText = "update indarneg.dbo.credencialcliente set foto=@foto,fechafoto=getdate() where id='" + id + "'";
                    cmd.Parameters.AddWithValue("@foto", arr);
                    cmd.ExecuteNonQuery();
                    myConnection.Close();

                }
                busca1(barEditClienteTxt.EditValue.ToString());
            }
        }

        public void limpiaTodo()
        {
            txt1Contacto.Text = "";
            txt1FechaFoto.Text = "";
            txt1Nombre.Text = "";
            txt1Ocupacion.Text = "";
            txt1Tarjeta.Text = "";
            picture1.Image = null;
            //2
            txt2Contacto.Text = "";
            txt2FechaFoto.Text = "";
            txt2Nombre.Text = "";
            txt2Ocupacion.Text = "";
            txt2Tarjeta.Text = "";
            picture2.Image = null;
            //3
            txt3Contacto.Text = "";
            txt3FechaFoto.Text = "";
            txt3Nombre.Text = "";
            txt3Ocupacion.Text = "";
            txt3Tarjeta.Text = "";
            picture3.Image = null;
            //4
            txt4Contacto.Text = "";
            txt4FechaFoto.Text = "";
            txt4Nombre.Text = "";
            txt4Ocupacion.Text = "";
            txt4Tarjeta.Text = "";
            picture4.Image = null;




        }
        private void barButtonBuscar_ItemClick(object sender, ItemClickEventArgs e)
        {

            limpiaTodo();

            layoutControlGroup1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            busca1(barEditClienteTxt.EditValue.ToString());
            busca2(barEditClienteTxt.EditValue.ToString());
            busca3(barEditClienteTxt.EditValue.ToString());
            busca4(barEditClienteTxt.EditValue.ToString());
        }


        public bool permisos1(string cliente)
        {
            btn1Imprimir.Enabled = false;
            txt1Nombre.ReadOnly = true;
            txt1Tarjeta.ReadOnly = true;
            txt1FechaFoto.ReadOnly = true;
            txt1Contacto.ReadOnly = true;
            txt1Ocupacion.ReadOnly = true;
            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            cmd.CommandText = "SELECT count(tarjeta) FROM indarneg.dbo.credencialcliente where cliente ='" + barEditClienteTxt.EditValue.ToString() + "' and tarjeta=1";
            var result = cmd.ExecuteScalar().ToString();
            switch ((string)result)
            {
                case "0": btn1Modificar.Enabled = false;
                    btn1Imprimir.Enabled = false;
                    txt1Nombre.ReadOnly = false;
                    txt1Tarjeta.ReadOnly = true;

                    txt1FechaFoto.ReadOnly = true;
                    txt1Contacto.ReadOnly = true;
                    txt1Ocupacion.ReadOnly = false;
                    txt1Nombre.ReadOnly = false;
                    Btn1Crear.Visible = true;
                    return false;

                case "1":
                case "2":
                case "3":
                case "4":
                    btn1Modificar.Enabled = true;
                    btn1Imprimir.Enabled = true;

                    Btn1Crear.Enabled = false;
                    return true;



            }
            return false;
        }
        public bool permisos2(string cliente)
        {
            btn2Imprimir.Enabled = false;
            txt2Nombre.ReadOnly = true;
            txt2Tarjeta.ReadOnly = true;
            txt2FechaFoto.ReadOnly = true;
            txt2Contacto.ReadOnly = true;
            txt2Ocupacion.ReadOnly = true;
            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            cmd.CommandText = "SELECT count(tarjeta) FROM indarneg.dbo.credencialcliente where cliente ='" + barEditClienteTxt.EditValue.ToString() + "' and tarjeta=2";
            var result = cmd.ExecuteScalar().ToString();
            switch ((string)result)
            {
                case "0": btn2Modificar.Enabled = false;
                    btn2Imprimir.Enabled = false;
                    txt2Nombre.ReadOnly = false;
                    txt2Tarjeta.ReadOnly = true;

                    txt2FechaFoto.ReadOnly = true;
                    txt2Contacto.ReadOnly = true;
                    txt2Ocupacion.ReadOnly = false;
                    txt2Nombre.ReadOnly = false;
                    btn2Crear.Visible = true;
                    return false;

                case "1":
                case "2":
                case "3":
                case "4":
                    btn2Modificar.Enabled = true;
                    btn2Imprimir.Enabled = true;

                    btn2Crear.Enabled = false;
                    return true;



            }
            return false;
        }

        public bool permisos3(string cliente)
        {
            btn3Imprimir.Enabled = false;
            txt3Nombre.ReadOnly = true;
            txt3Tarjeta.ReadOnly = true;
            txt3FechaFoto.ReadOnly = true;
            txt3Contacto.ReadOnly = true;
            txt3Ocupacion.ReadOnly = true;
            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            cmd.CommandText = "SELECT count(tarjeta) FROM indarneg.dbo.credencialcliente where cliente ='" + barEditClienteTxt.EditValue.ToString() + "' and tarjeta=3";
            var result = cmd.ExecuteScalar().ToString();
            switch ((string)result)
            {
                case "0": btn3Modificar.Enabled = false;
                    btn3Imprimir.Enabled = false;
                    txt3Nombre.ReadOnly = false;
                    txt3Tarjeta.ReadOnly = true;

                    txt3FechaFoto.ReadOnly = true;
                    txt3Contacto.ReadOnly = true;
                    txt3Ocupacion.ReadOnly = false;
                    txt3Nombre.ReadOnly = false;
                    btn3Crear.Visible = true;
                    return false;

                case "1":
                case "2":
                case "3":
                case "4":
                    btn3Modificar.Enabled = true;
                    btn3Imprimir.Enabled = true;

                    btn3Crear.Enabled = false;
                    return true;



            }
            return false;
        }
        public bool permisos4(string cliente)
        {
            btn4Imprimir.Enabled = false;
            txt4Nombre.ReadOnly = true;
            txt4Tarjeta.ReadOnly = true;
            txt4FechaFoto.ReadOnly = true;
            txt4Contacto.ReadOnly = true;
            txt4Ocupacion.ReadOnly = true;
            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            cmd.CommandText = "SELECT count(tarjeta) FROM indarneg.dbo.credencialcliente where cliente ='" + barEditClienteTxt.EditValue.ToString() + "' and tarjeta=4";
            var result = cmd.ExecuteScalar().ToString();
            switch ((string)result)
            {
                case "0": btn4Modificar.Enabled = false;
                    btn4Imprimir.Enabled = false;
                    txt4Nombre.ReadOnly = false;
                    txt4Tarjeta.ReadOnly = true;

                    txt4FechaFoto.ReadOnly = true;
                    txt4Contacto.ReadOnly = true;
                    txt4Ocupacion.ReadOnly = false;
                    txt4Nombre.ReadOnly = false;
                    btn4Crear.Visible = true;
                    return false;

                case "1":
                case "2":
                case "3":
                case "4":
                    btn4Modificar.Enabled = true;
                    btn4Imprimir.Enabled = true;

                    btn4Crear.Enabled = false;
                    return true;



            }
            return false;
        }
        public void busca1(string cliente)
        {
            if (permisos1(cliente))
            {
                byte[] receivedBytes;
                SqlConnection myConnection = new SqlConnection(sqlString);
                myConnection.Open();
                string query = "select * from indarneg.dbo.credencialcliente where cliente='" + cliente + "' and tarjeta=1";
                SqlCommand cmd = new SqlCommand(query, myConnection);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                receivedBytes = (byte[])sdr[5];
                Bitmap image;
                using (MemoryStream stream = new MemoryStream(receivedBytes))
                {
                    image = new Bitmap(stream);
                }
                picture1.Image = image;
                picture1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;

                txt1Nombre.EditValue = (string)sdr[1];
                txt1FechaFoto.EditValue = sdr.GetValue(3).ToString();
                txt1Tarjeta.EditValue = "Tarjeta Numero: " + sdr[2].ToString();
                txt1Ocupacion.EditValue = (string)sdr[7];
                myConnection.Close();
                myConnection.Open();
                SqlCommand cmd2 = new SqlCommand("", myConnection);
                cmd2.CommandText = "SELECT isnull( TELEFONOS,'0')  FROM indar.dbo.cte where cliente='" + barEditClienteTxt.EditValue.ToString() + "'";
                txt1Contacto.EditValue = cmd2.ExecuteNonQuery();
            }

        }


        public void busca2(string cliente)
        {
            if (permisos2(cliente))
            {
                byte[] receivedBytes;
                SqlConnection myConnection = new SqlConnection(sqlString);
                myConnection.Open();
                string query = "select * from indarneg.dbo.credencialcliente where cliente='" + cliente + "' and tarjeta=2";
                SqlCommand cmd = new SqlCommand(query, myConnection);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                receivedBytes = (byte[])sdr[5];
                Bitmap image;
                using (MemoryStream stream = new MemoryStream(receivedBytes))
                {
                    image = new Bitmap(stream);
                }
                picture2.Image = image;
                picture2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;

                txt2Nombre.EditValue = (string)sdr[1];
                txt2FechaFoto.EditValue = sdr.GetValue(3).ToString();
                txt2Tarjeta.EditValue = "Tarjeta Numero: " + sdr[2].ToString();
                txt2Ocupacion.EditValue = (string)sdr[7];
                myConnection.Close();
                myConnection.Open();
                SqlCommand cmd2 = new SqlCommand("", myConnection);
                cmd2.CommandText = "SELECT isnull( TELEFONOS,'0')  FROM indar.dbo.cte where cliente='" + barEditClienteTxt.EditValue.ToString() + "'";
                txt2Contacto.EditValue = cmd2.ExecuteNonQuery();
            }

        }


        public void busca3(string cliente)
        {
            if (permisos3(cliente))
            {
                byte[] receivedBytes;
                SqlConnection myConnection = new SqlConnection(sqlString);
                myConnection.Open();
                string query = "select * from indarneg.dbo.credencialcliente where cliente='" + cliente + "' and tarjeta=3";
                SqlCommand cmd = new SqlCommand(query, myConnection);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                receivedBytes = (byte[])sdr[5];
                Bitmap image;
                using (MemoryStream stream = new MemoryStream(receivedBytes))
                {
                    image = new Bitmap(stream);
                }
                picture3.Image = image;
                picture3.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;

                txt3Nombre.EditValue = (string)sdr[1];
                txt3FechaFoto.EditValue = sdr.GetValue(3).ToString();
                txt3Tarjeta.EditValue = "Tarjeta Numero: " + sdr[2].ToString();
                txt3Ocupacion.EditValue = (string)sdr[7];
                myConnection.Close();
                myConnection.Open();
                SqlCommand cmd2 = new SqlCommand("", myConnection);
                cmd2.CommandText = "SELECT isnull( TELEFONOS,'0')  FROM cte where cliente='" + barEditClienteTxt.EditValue.ToString() + "'";
                txt3Contacto.EditValue = cmd2.ExecuteNonQuery();
            }

        }
        public void busca4(string cliente)
        {
            if (permisos4(cliente))
            {
                byte[] receivedBytes;
                SqlConnection myConnection = new SqlConnection(sqlString);
                myConnection.Open();
                string query = "select * from indarneg.dbo.credencialcliente where cliente='" + cliente + "' and tarjeta=4";
                SqlCommand cmd = new SqlCommand(query, myConnection);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                receivedBytes = (byte[])sdr[5];
                Bitmap image;
                using (MemoryStream stream = new MemoryStream(receivedBytes))
                {
                    image = new Bitmap(stream);
                }
                picture4.Image = image;
                picture4.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;

                txt4Nombre.EditValue = (string)sdr[1];
                txt4FechaFoto.EditValue = sdr.GetValue(3).ToString();
                txt4Tarjeta.EditValue = "Tarjeta Numero: " + sdr[2].ToString();
                txt4Ocupacion.EditValue = (string)sdr[7];
                myConnection.Close();
                myConnection.Open();
                SqlCommand cmd2 = new SqlCommand("", myConnection);
                cmd2.CommandText = "SELECT isnull( TELEFONOS,'0')  FROM cte where cliente='" + barEditClienteTxt.EditValue.ToString() + "'";
                txt4Contacto.EditValue = cmd2.ExecuteNonQuery();
            }

        }

        private void btn1Modificar_Click(object sender, EventArgs e)
        {
            if (btn1Modificar.Text.Equals("Modificar Credencial"))
            {
                txt1Nombre.ReadOnly = false;
                // txt1Tarjeta.Enabled = true;
                //  txt1FechaFoto.Enabled = true;
                // txt1Contacto.Enabled = true;
                txt1Ocupacion.ReadOnly = false;
                btn1Modificar.Text = "Guardar Modificacion";
            }
            else
            {
                SqlConnection myConnection = new SqlConnection(sqlString);
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText = "update indarneg.dbo.credencialcliente  set nombre=@nombre,ocupacion=@Ocupacion  where cliente='" + barEditClienteTxt.EditValue.ToString() + "' and tarjeta='1'";
                cmd.Parameters.AddWithValue("@nombre", txt1Nombre.Text);
                cmd.Parameters.AddWithValue("@Ocupacion", txt1Ocupacion.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Actualizado");
                busca1(barEditClienteTxt.EditValue.ToString());
                btn1Modificar.Text = "Modificar Credencial";

            }
        }

        private void picture1_DoubleClick(object sender, EventArgs e)
        {
            if (btn1Modificar.Text.Equals("Guardar Modificacion"))
            {
                TakePictureDialog d = new TakePictureDialog();

                if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    Image i = d.Image;
                    i.Save(@"C:\foto\foto.jpg");
                    picture1.Image = i;
                    picture1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                    SqlConnection myConnection = new SqlConnection(sqlString);
                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand("", myConnection);
                    byte[] arr;
                    ImageConverter converter = new ImageConverter();
                    arr = (byte[])converter.ConvertTo(i, typeof(byte[]));
                    cmd.CommandText = "update indarneg.dbo.credencialcliente set foto=@foto, fechafoto=getdate() where cliente='" + barEditClienteTxt.EditValue.ToString() + "' and tarjeta=1";
                    cmd.Parameters.AddWithValue("@foto", arr);
                    cmd.ExecuteNonQuery();
                    myConnection.Close();

                }
            }
        }

        private void picture2_DoubleClick(object sender, EventArgs e)
        {
            if (btn2Modificar.Text.Equals("Guardar Modificacion"))
            {
                TakePictureDialog d = new TakePictureDialog();

                if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    Image i = d.Image;
                    i.Save(@"C:\foto\foto.jpg");
                    picture2.Image = i;
                    picture2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                    SqlConnection myConnection = new SqlConnection(sqlString);
                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand("", myConnection);
                    byte[] arr;
                    ImageConverter converter = new ImageConverter();
                    arr = (byte[])converter.ConvertTo(i, typeof(byte[]));
                    cmd.CommandText = "update indarneg.dbo.credencialcliente set foto=@foto, fechafoto=getdate() where cliente='" + barEditClienteTxt.EditValue.ToString() + "' and tarjeta=2";
                    cmd.Parameters.AddWithValue("@foto", arr);
                    cmd.ExecuteNonQuery();
                    myConnection.Close();

                }
            }
        }

        private void btn2Crear_Click(object sender, EventArgs e)
        {
            string id = "";
            if (validador2.Validate())
            {
                SqlConnection myConnection2 = new SqlConnection(sqlString);
                myConnection2.Open();
                SqlCommand cmd2 = new SqlCommand("", myConnection2);
                cmd2.CommandText = "insert into indarneg.dbo.credencialcliente (cliente,nombre,tarjeta,ocupacion) values('" +
                                barEditClienteTxt.EditValue.ToString() + "','" + txt2Nombre.Text + "',2,'" + txt2Ocupacion.Text + "') SELECT SCOPE_IDENTITY()";
                MessageBox.Show("si entra");
                id = cmd2.ExecuteScalar().ToString();
                myConnection2.Close();
                TakePictureDialog d = new TakePictureDialog();

                if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    Image i = d.Image;
                    i.Save(@"C:\foto\foto.jpg");
                    picture2.Image = i;
                    picture2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                    SqlConnection myConnection = new SqlConnection(sqlString);
                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand("", myConnection);
                    byte[] arr;
                    ImageConverter converter = new ImageConverter();
                    arr = (byte[])converter.ConvertTo(i, typeof(byte[]));
                    cmd.CommandText = "update indarneg.dbo.credencialcliente set foto=@foto,fechafoto=getdate() where id='" + id + "'";
                    cmd.Parameters.AddWithValue("@foto", arr);
                    cmd.ExecuteNonQuery();
                    myConnection.Close();

                }
                busca2(barEditClienteTxt.EditValue.ToString());
            }
        }

        private void btn2Modificar_Click(object sender, EventArgs e)
        {
            if (btn2Modificar.Text.Equals("Modificar Credencial"))
            {
                txt2Nombre.ReadOnly = false;
                // txt1Tarjeta.Enabled = true;
                //  txt1FechaFoto.Enabled = true;
                // txt1Contacto.Enabled = true;
                txt2Ocupacion.ReadOnly = false;
                btn2Modificar.Text = "Guardar Modificacion";
            }
            else
            {
                SqlConnection myConnection = new SqlConnection(sqlString);
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText = "update indarneg.dbo.credencialcliente  set nombre=@nombre,ocupacion=@Ocupacion  where cliente='" + barEditClienteTxt.EditValue.ToString() + "' and tarjeta='1'";
                cmd.Parameters.AddWithValue("@nombre", txt2Nombre.Text);
                cmd.Parameters.AddWithValue("@Ocupacion", txt2Ocupacion.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Actualizado");
                busca2(barEditClienteTxt.EditValue.ToString());
                btn2Modificar.Text = "Modificar Credencial";

            }
        }

        private void btn3Crear_Click(object sender, EventArgs e)
        {
            string id = "";
            if (validador3.Validate())
            {
                SqlConnection myConnection2 = new SqlConnection(sqlString);
                myConnection2.Open();
                SqlCommand cmd2 = new SqlCommand("", myConnection2);
                cmd2.CommandText = "insert into indarneg.dbo.credencialcliente (cliente,nombre,tarjeta,ocupacion) values('" +
                                barEditClienteTxt.EditValue.ToString() + "','" + txt3Nombre.Text + "',3,'" + txt3Ocupacion.Text + "') SELECT SCOPE_IDENTITY()";
                MessageBox.Show("si entra");
                id = cmd2.ExecuteScalar().ToString();
                myConnection2.Close();
                TakePictureDialog d = new TakePictureDialog();

                if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    Image i = d.Image;
                    i.Save(@"C:\foto\foto.jpg");
                    picture3.Image = i;
                    picture3.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                    SqlConnection myConnection = new SqlConnection(sqlString);
                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand("", myConnection);
                    byte[] arr;
                    ImageConverter converter = new ImageConverter();
                    arr = (byte[])converter.ConvertTo(i, typeof(byte[]));
                    cmd.CommandText = "update indarneg.dbo.credencialcliente set foto=@foto,fechafoto=getdate() where id='" + id + "'";
                    cmd.Parameters.AddWithValue("@foto", arr);
                    cmd.ExecuteNonQuery();
                    myConnection.Close();

                }
                busca3(barEditClienteTxt.EditValue.ToString());
            }
        }

        private void btn4Crear_Click(object sender, EventArgs e)
        {
            string id = "";
            if (validador4.Validate())
            {
                SqlConnection myConnection2 = new SqlConnection(sqlString);
                myConnection2.Open();
                SqlCommand cmd2 = new SqlCommand("", myConnection2);
                cmd2.CommandText = "insert into indarneg.dbo.credencialcliente (cliente,nombre,tarjeta,ocupacion) values('" +
                                barEditClienteTxt.EditValue.ToString() + "','" + txt4Nombre.Text + "',4,'" + txt4Ocupacion.Text + "') SELECT SCOPE_IDENTITY()";
                MessageBox.Show("si entra");
                id = cmd2.ExecuteScalar().ToString();
                myConnection2.Close();
                TakePictureDialog d = new TakePictureDialog();

                if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    Image i = d.Image;
                    i.Save(@"C:\foto\foto.jpg");
                    picture4.Image = i;
                    picture4.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                    SqlConnection myConnection = new SqlConnection(sqlString);
                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand("", myConnection);
                    byte[] arr;
                    ImageConverter converter = new ImageConverter();
                    arr = (byte[])converter.ConvertTo(i, typeof(byte[]));
                    cmd.CommandText = "update indarneg.dbo.credencialcliente set foto=@foto,fechafoto=getdate() where id='" + id + "'";
                    cmd.Parameters.AddWithValue("@foto", arr);
                    cmd.ExecuteNonQuery();
                    myConnection.Close();

                }
                busca4(barEditClienteTxt.EditValue.ToString());
            }
        }

        private void btn3Modificar_Click(object sender, EventArgs e)
        {
            if (btn3Modificar.Text.Equals("Modificar Credencial"))
            {
                txt3Nombre.ReadOnly = false;
                // txt1Tarjeta.Enabled = true;
                //  txt1FechaFoto.Enabled = true;
                // txt1Contacto.Enabled = true;
                txt3Ocupacion.ReadOnly = false;
                btn3Modificar.Text = "Guardar Modificacion";
            }
            else
            {
                SqlConnection myConnection = new SqlConnection(sqlString);
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText = "update indarneg.dbo.credencialcliente  set nombre=@nombre,ocupacion=@Ocupacion  where cliente='" + barEditClienteTxt.EditValue.ToString() + "' and tarjeta='1'";
                cmd.Parameters.AddWithValue("@nombre", txt3Nombre.Text);
                cmd.Parameters.AddWithValue("@Ocupacion", txt3Ocupacion.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Actualizado");
                busca3(barEditClienteTxt.EditValue.ToString());
                btn3Modificar.Text = "Modificar Credencial";

            }
        }

        private void btn4Modificar_Click(object sender, EventArgs e)
        {
            if (btn4Modificar.Text.Equals("Modificar Credencial"))
            {
                txt4Nombre.ReadOnly = false;
                // txt1Tarjeta.Enabled = true;
                //  txt1FechaFoto.Enabled = true;
                // txt1Contacto.Enabled = true;
                txt4Ocupacion.ReadOnly = false;
                btn4Modificar.Text = "Guardar Modificacion";
            }
            else
            {
                SqlConnection myConnection = new SqlConnection(sqlString);
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText = "update indarneg.dbo.credencialcliente  set nombre=@nombre,ocupacion=@Ocupacion  where cliente='" + barEditClienteTxt.EditValue.ToString() + "' and tarjeta='1'";
                cmd.Parameters.AddWithValue("@nombre", txt4Nombre.Text);
                cmd.Parameters.AddWithValue("@Ocupacion", txt4Ocupacion.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Actualizado");
                busca4(barEditClienteTxt.EditValue.ToString());
                btn4Modificar.Text = "Modificar Credencial";

            }
        }

        private void picture3_DoubleClick(object sender, EventArgs e)
        {
            if (btn3Modificar.Text.Equals("Guardar Modificacion"))
            {
                TakePictureDialog d = new TakePictureDialog();

                if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    Image i = d.Image;
                    i.Save(@"C:\foto\foto.jpg");
                    picture3.Image = i;
                    picture3.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                    SqlConnection myConnection = new SqlConnection(sqlString);
                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand("", myConnection);
                    byte[] arr;
                    ImageConverter converter = new ImageConverter();
                    arr = (byte[])converter.ConvertTo(i, typeof(byte[]));
                    cmd.CommandText = "update indarneg.dbo.credencialcliente set foto=@foto, fechafoto=getdate() where cliente='" + barEditClienteTxt.EditValue.ToString() + "' and tarjeta=3";
                    cmd.Parameters.AddWithValue("@foto", arr);
                    cmd.ExecuteNonQuery();
                    myConnection.Close();

                }
            }
        }

        private void picture4_DoubleClick(object sender, EventArgs e)
        {
            if (btn4Modificar.Text.Equals("Guardar Modificacion"))
            {
                TakePictureDialog d = new TakePictureDialog();

                if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    Image i = d.Image;
                    i.Save(@"C:\foto\foto.jpg");
                    picture4.Image = i;
                    picture4.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                    SqlConnection myConnection = new SqlConnection(sqlString);
                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand("", myConnection);
                    byte[] arr;
                    ImageConverter converter = new ImageConverter();
                    arr = (byte[])converter.ConvertTo(i, typeof(byte[]));
                    cmd.CommandText = "update indarneg.dbo.credencialcliente set foto=@foto, fechafoto=getdate() where cliente='" + barEditClienteTxt.EditValue.ToString() + "' and tarjeta=4";
                    cmd.Parameters.AddWithValue("@foto", arr);
                    cmd.ExecuteNonQuery();
                    myConnection.Close();

                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            CteCredencial.cteRecogeCredencial cc = new CteCredencial.cteRecogeCredencial(sqlString);
            cc.Show();
        }
    }
}