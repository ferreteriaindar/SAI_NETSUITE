using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAI_NETSUITE.WMS.Reportes
{
    public partial class pickingDetalle : Form
    {
        string sqlString, movid, ct;
        public pickingDetalle(string sql,string numpedido,string cte)
        {
            sqlString = sql;
            movid = numpedido;
            ct = cte;
            InitializeComponent();
        }

        private void pickingDetalle_Load(object sender, EventArgs e)
        {
            Console.WriteLine(sqlString+"****");
            cargaDatos();
            CargaGrid();
        }

        public void cargaDatos()
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            cmd.CommandText = @"

                            select oe.Mov,oe.NumPedido,cte.Clave,oe.FormaEnvio,p.FechaIngreso from INDGDLSQL01.Indar_InActionWMS.dbo.OrdenEmbarque oe
                            left join INDGDLSQL01.Indar_InActionWMS.dbo.Cliente  cte on oe.IdCliente=cte.IdCliente
                            left join INDGDLSQL01.Indar_InActionWMS.int.Pedido P on oe.NumPedido=p.MovId and oe.Mov=p.Mov
                            where oe.NumPedido='" + movid+"' ";
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.HasRows && sdr.Read())
            {
                labelCliente.Text = sdr.GetValue(2).ToString();
                labelPedido.Text = sdr.GetValue(1).ToString();
                labelFecha.Text = sdr.GetValue(4).ToString();
            
            }
        }


        public void CargaGrid()
        {

            SqlConnection myConnection = new SqlConnection(sqlString);


            string query = @"
	                        SELECT E.Clave AS Articulo
		                        ,E.Descripcion
		                        ,PR.CantUnitarios AS Unidades
		                        ,(CASE WHEN PR.CantSurtida > 0 THEN PR.CantSurtida ELSE 0 END) AS CantSurtida
		                        ,E.Unidad
	
		                        ,EOE.Nombre AS Estatus
	                        FROM INDGDLSQL01.Indar_InActionWMS.dbo.PedidoRenglon PR INNER JOIN INDGDLSQL01.Indar_InActionWMS.dbo.Estilo E ON PR.IdEstilo = E.IdEstilo
	                        INNER JOIN INDGDLSQL01.Indar_InActionWMS.dbo.EstatusOrdenEmbarque EOE ON EOE.IdEstatusOrdenEmbarque = PR.IdEstatusOrdenEmbarque
	                        WHERE PR.NumPedido='" + movid+"'  and EOE.IdEstatusOrdenEmbarque in (0,1,2,3)";

            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
         
        }


        public void cargaDisponibles(string articulo)
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            string query = @"
                            select Almacen,Ubicacion,Area,Cantidad from INDGDLSQL01.Indar_InActionWMS.dbo.vExistenciasAlmacen
                            where Articulo='" + articulo + "' and IdArea  in (32,33,34,35,36,37,38,39,40,41)";
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            da.SelectCommand.CommandTimeout = 0;
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl2.DataSource = ds.Tables[0];
        
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            string articulo = gridView1.GetFocusedRowCellValue(colArticulo).ToString();
            cargaDisponibles(articulo);
        }
    }
}
