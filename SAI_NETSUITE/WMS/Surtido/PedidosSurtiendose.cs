using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace SAI_NETSUITE.WMS.Surtido
{
    public partial class PedidosSurtiendose : UserControl
    {

        string sqlstring;
        public PedidosSurtiendose(string sql)
       {
           sqlstring = sql;
            InitializeComponent();
        }

        public void cargaInfo()
        {

            SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString);
            string query = @"SELECT 
                            oe.FormaEnvio,DATEDIFF(MINUTE,Oe.FechaIngreso,GETDATE())as minutosTranscurridos,
                            oe.Mov,
                            oe.NumPedido,
                             CantSurtida2=(CASE WHEN ((SUM( NULLIF(PR.CantSurtida,0)))/NULLIF(OE.CantUnitarios,0)) > 0 THEN ((SUM( NULLIF(PR.CantSurtida,0)))/NULLIF(OE.CantUnitarios,0)) ELSE 0 END) ,
                             Partidas= convert(varchar(15),count( case when pr.CantSurtida is null then null else 1 end))+'/'+convert(varchar(15),count(  pr.CantUnitarios))
                        FROM INDGDLSQL01.INDAR_INACTIONWMS.dbo.OrdenEmbarque OE
                        left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.PedidoRenglon PR on oe.IdOrdenEmbarque=pr.IdOrdenEmbarque
                        left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Estilo E on pr.IdEstilo=e.IdEstilo
                        WHERE  oe.IdEstatusOrdenEmbarque in (4)
                        group by oe.formaenvio,OE.Mov,oe.NumPedido,oe.CantUnitarios,oe.FechaIngreso";
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];

               
        }

        private void PedidosSurtiendose_Load(object sender, EventArgs e)
        {
            cargaInfo();
        }

        private void tileView1_ItemCustomize(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventArgs e)
        {
       

           // if ((tileView1.GetRowCellValue(e.RowHandle, colFormaEnvio).ToString().Contains("CCI Cliente está en CCI")))
            if(EsClienteRecoge(tileView1.GetRowCellValue(e.RowHandle, colFormaEnvio).ToString()))
            {
               
                if ((int)tileView1.GetRowCellValue(e.RowHandle, colminutos) > 45 && (int)tileView1.GetRowCellValue(e.RowHandle, colminutos) < 60)
                    e.Item.Elements[1].Appearance.Normal.BackColor=Color.Khaki;
                if ((int)tileView1.GetRowCellValue(e.RowHandle, colminutos) < 45)
                    e.Item.Elements[1].Appearance.Normal.BackColor = Color.FromArgb(128, 128, 255);
                if((int)tileView1.GetRowCellValue(e.RowHandle,colminutos)>60)
                    e.Item.Elements[1].Appearance.Normal.BackColor = Color.Red;


            }
            if (tileView1.GetRowCellValue(e.RowHandle, colFormaEnvio).ToString().Contains("GDL-07"))
               /* e.Item.Elements[1].Appearance.Normal.BackColor = GDL_07(tileView1.GetRowCellValue(e.RowHandle, colNumPedido).ToString(), tileView1.GetRowCellValue(e.RowHandle, colMov).ToString());*/
            if(esOFicinas(tileView1.GetRowCellValue(e.RowHandle, colFormaEnvio).ToString()))
            {
               // e.Item.Elements[1].Appearance.Normal.BackColor = oficina(tileView1.GetRowCellValue(e.RowHandle, colNumPedido).ToString(), tileView1.GetRowCellValue(e.RowHandle, colMov).ToString());
            }
            //if ((double)tileView1.GetRowCellValue(e.RowHandle, colCantSurtida2) >= 100.00)
            //{
            //    e.Item.Elements[2].Appearance.Normal.BackColor = Color.Green;
            //}

            //if ((double)tileView1.GetRowCellValue(e.RowHandle, colCantSurtida2) >= 60 && (double)tileView1.GetRowCellValue(e.RowHandle, colCantSurtida2) <= 99.99)
            //{
            //    e.Item.Elements[2].Appearance.Normal.BackColor = Color.Orange;
            //}
          
        }

        private void tileView1_DoubleClick(object sender, EventArgs e)
        {
            infoPedidos ip = new infoPedidos(sqlstring, tileView1.GetFocusedRowCellValue(colMov).ToString(), tileView1.GetFocusedRowCellValue(colNumPedido).ToString());
            ip.ShowDialog();
        }



        public  bool EsClienteRecoge(string formaEnvio)
        {
            List<string> lista = new List<string>();
            lista.Add("CCI Cliente está en CCI");
            lista.Add("CCI Cliente Recoge");
            lista.Add("CDI Cliente esta en CDI");
            lista.Add("CDI Cliente Recoge");
            lista.Add("CCI Vendedor Entrega");
            foreach (var item in lista)
            {
                if(formaEnvio.Contains(item))
                    return true;
            }
        
        return false;
        }


        public Color oficina(string movid, string mov)
        {


            SqlConnection myConnection = new SqlConnection(sqlstring);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            cmd.CommandText = @"select fechacomenzo  from VerMovTiempo
                            where id=(select  id from venta where movid='" + movid + "' and mov='" + mov + "') and situacion='Por Surtir'";
            var hora = cmd.ExecuteScalar().ToString();

            DateTime fechaini = Convert.ToDateTime(hora);
          
       
           
            TimeSpan ts = Convert.ToDateTime(DateTime.Now.ToString("dd/MMM/yyyy") + " " + "06:00 PM").Subtract(fechaini);
       
            if (ts.TotalMinutes >= 570 || DateTime.Compare(DateTime.Now, Convert.ToDateTime(DateTime.Now.ToString("dd/MMM/yyyy") + " " + "06:00 PM")) > 0)
                return Color.Red;
           
            if (ts.TotalMinutes < 15)
            {
                return Color.Red;

              
            }
            if (ts.TotalMinutes > 15 && ts.TotalMinutes < 60)
                return Color.Orange;
          
            return Color.FromArgb(128, 128, 255);
        }



        public bool esOFicinas(string formaEnvio)
        {
            List<string> lista = new List<string>();
            lista.Add("AGS-01 Foraneo"); lista.Add("AGS-01 Ruta Local"); lista.Add("BJX-02 Cliente Recoge"); lista.Add("BJX-02 Foraneo"); lista.Add("BJX-02 Ruta Local"); lista.Add("CUL-04 Cliente Recoge"); lista.Add("CUL-04 Foraneo"); lista.Add("CUL-04 Ruta Local"); lista.Add("GDL-07 Cliente Recoge"); lista.Add("GDL-07 Vendedor Entrega"); lista.Add("MLM-05 Cliente Recoge"); lista.Add("MLM-05 Foraneo"); lista.Add("MLM-05 Ruta Local"); lista.Add("QRO-03 Cliente Recoge"); lista.Add("QRO-03 Foraneo"); lista.Add("QRO-03 Ruta Local"); lista.Add("TRC-06 Cliente Recoge"); lista.Add("TRC-06 Foraneo"); lista.Add("TRC-06 Ruta Local");
            foreach (var item in lista)
            {
                if (formaEnvio.Contains(item))
                    return true;
            }
            return false;
        
        }

        public Color GDL_07(string movid,string mov)
        {
            SqlConnection myConnection = new SqlConnection(sqlstring);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            cmd.CommandText = @"select fechacomenzo  from VerMovTiempo
                            where id=(select  id from venta where movid='"+movid+"' and mov='"+mov+"') and situacion='Por Surtir'";
            var hora = cmd.ExecuteScalar().ToString();

            DateTime fechaini = Convert.ToDateTime(hora);
        
            TimeSpan ts = Convert.ToDateTime(DateTime.Now.ToString("dd/MMM/yyyy") + " " + "12:00 PM").Subtract(DateTime.Now);
            Console.WriteLine("fecha gdl_007" + DateTime.Now + "+++TS"+ts.TotalMinutes);
            if (DateTime.Today - fechaini == TimeSpan.FromDays(1))
                return Color.Red;
            if (ts.TotalMinutes <= 30)
            {
                Console.WriteLine("entra rojogdl");
                return Color.Red;
               
            }


            if (ts.TotalMinutes > 30 && ts.TotalMinutes < 60)
                return Color.Khaki;
            
            //Console.WriteLine(fechaini);
            //Console.WriteLine(Convert.ToDateTime(DateTime.Now.ToString("dd/MMM/yyyy") + " " + "10:30 AM"));
            //if ((fechaini < Convert.ToDateTime(DateTime.Now.ToString("dd/MMM/yyyy") + " " + "10:30 AM")) && fechaini.ToShortDateString().Equals(DateTime.Now.ToShortDateString())) 
            //   Console.WriteLine("menor que 10");

            //if ((fechaini < Convert.ToDateTime(DateTime.Now.ToString("dd/MMM/yyyy") + " " + "01:30 PM")) && fechaini.ToShortDateString().Equals(DateTime.Now.ToShortDateString()))
            //    Console.WriteLine("menor que 10");
            return Color.FromArgb(128, 128, 255);
        }


    }
}
