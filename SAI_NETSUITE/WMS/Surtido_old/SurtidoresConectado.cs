using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAI.Almacen.WMS.Surtido
{
    public partial class SurtidoresConectado : UserControl
    {
        string sqlString;
        public SurtidoresConectado(string sql)
        {
            sqlString = sql;
            InitializeComponent();
        }



        public void cargaInfo()
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            string query = @"select U.Usuario,
                                U.Nombre,
                                LL.Nombre as Area 
                                FROM INDAR_INACTIONWMS.dbo.Sesion S
                                LEFT JOIN INDAR_INACTIONWMS.dbo.Usuario U ON  S.IdUsuarioActualiza=U.IdUsuario
                                LEFT JOIN   (
			                                SELECT distinct IdUsuario,a.Nombre FROM INDAR_INACTIONWMS.dbo.UsuarioLocalidad  UL
			                                LEFT JOIN INDAR_INACTIONWMS.dbo.Localidad  L ON UL.IdLocalidad=L.IdLocalidad
			                                LEFT JOIN INDAR_INACTIONWMS.dbo.Area A ON l.IdArea=a.IdArea
			                                where a.IdAlmacen=2
                                ) LL on S.IdUsuarioActualiza=LL.IdUsuario 
	                                WHERE S.FechaHoraFin IS NULL 
	                                AND DATEADD(DAY,0, DATEDIFF(DAY,0, S.FechaHoraInicio)) = DATEADD(DAY,0, DATEDIFF(DAY,0, GETDATE()))
	                                AND S.Modulo = 'SURTIDO'";
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }
        private void SurtidoresConectado_Load(object sender, EventArgs e)
        {
            cargaInfo();
        }

        private void tileView1_ItemCustomize(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventArgs e)
        {

            
               switch(tileView1.GetRowCellValue(e.RowHandle,colArea).ToString())
               {
                   case "SECTOR 1": e.Item.Elements[1].Appearance.Normal.BackColor = Color.Blue;
                       break;
                   case "SECTOR 2": e.Item.Elements[1].Appearance.Normal.BackColor = Color.LawnGreen;
                       break;
                   case "SECTOR 3": e.Item.Elements[1].Appearance.Normal.BackColor = Color.Orange;
                       break;
                }


        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //String path = @"S:\numeros\pin.png";
            //Image image = Image.FromFile(path);
            //PictureBox pictureBox = new PictureBox();
            //pictureBox.Image = image;
            //pictureBox.Width = image.Width;
            //pictureBox.Height = image.Height;
            //pictureBox.Visible = true;
            //pictureBox.Parent = P1_25;
            //ToolTip toolTip1 = new ToolTip();
            //toolTip1.SetToolTip(pictureBox, "SURTIENDO");
            cargaInfoMapa();



        }


        public void cargaInfoMapa()
        {

            SqlConnection myConnection = new SqlConnection(sqlString);
            string query = @"select U.Usuario,
                            U.Nombre,
                            LL.Nombre as Area,
                             cc.pedido ,
                            Ubicacion=CASE WHEN  cc.Codigo IS NULL THEN (
												                            select TOP 1 L.Codigo FROM INDAR_INACTIONWMS.dbo.RecoleccionDetalle RD
												                            LEFT JOIN INDAR_INACTIONWMS.dbo.Localidad L ON RD.IdLocalidad=L.IdLocalidad
												                            LEFT JOIN INDAR_INACTIONWMS.dbo.OrdenEmbarque OE ON RD.IdOrdenEmbarque=OE.IdOrdenEmbarque
												                            where RD.IdUsuarioActualiza=U.IdUsuario AND RD.FechaActualizado>=DATEADD(HOUR,-2,GETDATE())
												                            ORDER BY IdRecoleccionDetalle DESC
											                            )
											                            else cc.Codigo end
                             ,cc.Articulo,CASE WHEN CC.Articulo is null and cc.Codigo is not null then 'VA A LA UBICACION' ELSE 'ULTIMA UBICACION' END AS ACCION
                            FROM INDAR_INACTIONWMS.dbo.Sesion S
                            LEFT JOIN INDAR_INACTIONWMS.dbo.Usuario U ON  S.IdUsuarioActualiza=U.IdUsuario
                            LEFT JOIN   (
			                            SELECT distinct IdUsuario,a.Nombre FROM INDAR_INACTIONWMS.dbo.UsuarioLocalidad  UL
			                            LEFT JOIN INDAR_INACTIONWMS.dbo.Localidad  L ON UL.IdLocalidad=L.IdLocalidad
			                            LEFT JOIN INDAR_INACTIONWMS.dbo.Area A ON l.IdArea=a.IdArea
			                            where a.IdAlmacen=2
			                            ) LL on S.IdUsuarioActualiza=LL.IdUsuario 
                            LEFT JOIN	(
				                            select rpl.IdUsuarioActualiza as IdUsuario,oe.Mov+' '+oe.NumPedido as pedido,L.Codigo ,
				                             (SELECT  CLAVE FROM INDAR_INACTIONWMS.dbo.Estilo WHERE IdEstilo=RPL.IdEstilo) as Articulo
				                            FROM INDAR_INACTIONWMS.dbo.RecoleccionProcesoUsuarioLocalidad  RPL
				                            LEFT JOIN INDAR_INACTIONWMS.dbo.Localidad L ON RPL.IdLocalidad=L.IdLocalidad
				                            LEFT JOIN INDAR_INACTIONWMS.dbo.OrdenEmbarque OE ON RPL.IdOrdenEmbarque=OE.IdOrdenEmbarque
			                            ) CC  on s.IdUsuarioActualiza=cc.IdUsuario
                            WHERE S.FechaHoraFin IS NULL 
                            AND DATEADD(DAY,0, DATEDIFF(DAY,0, S.FechaHoraInicio)) = DATEADD(DAY,0, DATEDIFF(DAY,0, GETDATE()))
                            AND S.Modulo = 'SURTIDO'";

            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string path = @"S:\numeros\pin.png";
                if (ds.Tables[0].Rows[i][4].ToString().StartsWith("P1"))
                    path = @"S:\numeros\azul.png";
                if(ds.Tables[0].Rows[i][4].ToString().StartsWith("P2"))
                    path = @"S:\numeros\verde.png";
                if (ds.Tables[0].Rows[i][4].ToString().StartsWith("P3"))
                    path=@"S:\numeros\rojo.png";

                Console.WriteLine(ds.Tables[0].Rows[i][4].ToString() + "*");
                if (ds.Tables[0].Rows[i][4].ToString().StartsWith("P")) // COLOR ROJO    PONER UN SWITCH CASE
                {
                 
                    Image image = Image.FromFile(path);
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = image;
                    pictureBox.Width = image.Width;
                    pictureBox.Height = image.Height;
                    pictureBox.Visible = true;
                    
                    foreach (Control c in groupControl2.Controls) //here is the minor change
                    {

                        if (c is DevExpress.XtraEditors.SimpleButton)
                        {
                            Console.WriteLine(regresaNombreBoton(ds.Tables[0].Rows[i][4].ToString()));
                            if (c.Name.ToString().Equals(regresaNombreBoton(ds.Tables[0].Rows[i][4].ToString())))
                            {
                                pictureBox.Parent = c;
                                pictureBox.Location = new Point(7, Convert.ToInt32(ds.Tables[0].Rows[i][4].ToString().Substring(9, 1)) * 24+8);
                                Console.WriteLine(c.Name+"COLOCA");
                            }
                        }

                    }
                   
                    ToolTip toolTip1 = new ToolTip();
                    toolTip1.SetToolTip(pictureBox, "SURTIENDO");
                }

              
            }       
        
        
        
        
        
        
        
        }



        public string regresaNombreBoton(string ubicacion)
        {
            int hilera;
            int division;
            hilera = Convert.ToInt32(ubicacion.Substring(2, 2));
            division=Convert.ToInt32(ubicacion.Substring(4,2));
            if (division >= 10 && division <= 14)
                return "P1_" + hilera.ToString();
            else return "P2_" + hilera.ToString();
           

        
        }



    }
}
