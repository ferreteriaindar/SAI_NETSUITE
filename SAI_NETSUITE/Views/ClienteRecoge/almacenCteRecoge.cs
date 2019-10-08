using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraBars.Alerter;
using System.Media;

namespace SAI_NETSUITE.Views.ClienteRecoge
{
    public partial class almacenCteRecoge : Form
    {

       
        string nombre, perfil,sucursal;

        public almacenCteRecoge( string nom,string profile,string suc)
        {
            //myConnection = conn;
            nombre = nom;
            perfil = profile;
            sucursal = suc;
            InitializeComponent();
            textBox1.Select();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            /*  string query="select movid,(importe+impuestos)as importe, fechaemision, formaenvio,cliente,agente  from venta where  mov='Factura Indar'   and "+
                             " formaenvio in ('CCI Pedido de Empleado','CDI Cliente esta en CDI','CCI Cliente Recoge','CCI Cliente está en CCI','CCI Vendedor Entrega','GDL-07 Cliente Recoge','CDI Cliente Recoge','CCI Cliente está en CCI','Cte Esta en CDI','Cte Esta en Suc1', 'Cte Mostrador','Cte Recoge CDI','Cte Recoge Suc 1','Cte Recoge Surtefacil','Vendedor Entrega','Vendedor Entrega CCI','Cte Esta en CCI','Cte Recoge en CCI','Cte Recoge en GDL 07','GDL-07 Vendedor Entrega','CCI CLIENTE ESTA AQUI','CCI PEDIDO DE EMPLEADO')  and movid='" + textBox1.Text + "'";*/
            string query = @"SELECT TranId as movid,AmountDue+TaxTotal as importe,SaleDate,f.LIST_ITEM_NAME as formaenvio,c.companyId,e.NAME from   IWS.DBO.Invoices I
                             inner join iws.dbo.FormaEnvio F on i.ShippingWay=f.LIST_ID
                             inner join iws.dbo.Customers c on i.Entity=c.internalid
                             inner join iws.dbo.ZonasIndar ZI on c.customerZone=zi.NSO___ZONAS_CLIENTES_ID
                             inner join iws.dbo.Entity E on zi.REPRESENTANTE_VENTAS_ID=e.ENTITY_ID
                            where ShippingWay in (4,5,10,11,13,14) and  TranId=" + textBox1.Text;
            SqlConnection myConnection2 = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString);

            SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand(query, myConnection);
           SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            if (!sdr.HasRows)
            {
                textBox1.Text = "";
                textBox1.Select();
                try
                {
                    //System.Media.SystemSounds.Beep.Play();
                    //System.Media.SoundPlayer player = new System.Media.SoundPlayer("S:\\alarma.mp3");
                    //player.Play();
                    /*SoundPlayer snd = new SoundPlayer(Properties.Resources.alarma);
                    snd.Play();*/
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                MessageBox.Show("Verifica el numero de factura \n O la factura no es para Cliente Recoge");
                
            }

            else
            {

                
                myConnection2.Close();
                myConnection2.Open();
                SqlCommand cmd2 = new SqlCommand("", myConnection2);

                cmd2.CommandText = "select factura from indarneg.dbo.almacencterecoge where factura=" + textBox1.Text;
                SqlDataReader sdr2 = cmd2.ExecuteReader();
                sdr2.Read();
                if (!sdr2.HasRows)
                {
                    myConnection2.Close();
                    cmd2.CommandText = " set dateformat dmy insert into  indarneg.dbo.almacencterecoge (factura,fechaentrada,importe,fechaemision,formaenvio,estatus,cliente,usuario,agente,sucursal)" +
                                   " values('" + sdr.GetValue(0).ToString() + "',getdate()," + sdr.GetValue(1).ToString() + ",'" + Convert.ToDateTime(sdr.GetValue(2).ToString()).ToShortDateString() + "','" + sdr.GetValue(3).ToString() + "','ALMACEN CTE REC','" + sdr.GetValue(4).ToString() + "','"+nombre+"','"+sdr.GetValue(5).ToString()+"','"+sucursal+"')";
                    myConnection2.Open();
                    Console.WriteLine(cmd2.CommandText);
                    cmd2.ExecuteNonQuery();
                    Image img = SAI_NETSUITE.Properties.Resources.Accept_icon;
                    AlertInfo info = new AlertInfo("MENSAJE", "Factura Registrada", img);

                    alertControl1.Images = img;
                    alertControl1.Show(this, info);
                    textBox1.Text = "";
                    textBox1.Select();
                    myConnection2.Close();
                }
                else MessageBox.Show("Ya esta registrada esa factura");
            }   
            myConnection.Close();
            myConnection2.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                simpleButton1_Click(null, null);
            
            }
        }
    }
}
