using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAI.Almacen.WMS.Surtido
{
    public partial class infoPedidos : Form
    {
        string sqlString, mov, movid;
        public infoPedidos(string sql,string movint,string movidInt)
        {
            sqlString = sql;
            mov = movint;
            movid = movidInt;
            InitializeComponent();
        }

        private void infoPedidos_Load(object sender, EventArgs e)
        {
            cargaInfo();
            cargaTiempos();
            labelMov.Text = mov;
            labelMovid.Text = movid;
        }

        public void cargaInfo()
        {

            SqlConnection myConnection = new SqlConnection(sqlString);
            string query = @"declare  @pedido int
                            set @pedido="+movid+ @"  
                            select oe.IdOrdenEmbarque, oe.Mov,
                            oe.NumPedido,
                            e.Clave,
                            pr.CantUnitarios as Cant_Pedido,
                            rd.Cantidad,
                            CASE WHEN RD.ubiFinal LIKE 'E-%' THEN 'EN CARRO'   ELSE  EOE.Nombre END ESTATUS,
                            caja= rd.caja,	 							
                             Ubicacion=  case when EOE.Nombre='En proceso' then  rd.ubiFinal else isnull(rd.ubiFinal,'') end,							
                            case when rd.ubiFinal like 'E-%' THEN RD.Usuario   ELSE rd.Usuario END AS SURTIDOR,
							RD.UbiCons
                            from INDGDLSQL01.INDAR_INACTIONWMS.dbo.OrdenEmbarque OE 
                            LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.PedidoRenglon PR on oe.IdOrdenEmbarque=pr.IdOrdenEmbarque
                            LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.EstatusOrdenEmbarque EOE on pr.IdEstatusOrdenEmbarque=EOE.IdEstatusOrdenEmbarque
                            LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.Estilo E on pr.IdEstilo=e.IdEstilo
                            LEFT JOIN     (select oe.IdOrdenEmbarque ,oe.Mov,oe.NumPedido,e.Clave,sum(rd.Cantidad) as Cantidad,l3.Codigo as caja,L2.Codigo ubiFinal,RD.FechaActualizado,Usr.Nombre,R.FechaHoraInicio,R.FechaHoraFin,Usr.Usuario,L4.Codigo AS UbiCons from  INDGDLSQL01.INDAR_INACTIONWMS.dbo.Recoleccion R
                            left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.RecoleccionDetalle RD on r.IdRecoleccion=rd.IdRecoleccion
                            left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Localidad L2 on RD.IdLocalidadDeposito=L2.IdLocalidad
                            left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Localidad L3 on rd.IdLocalidadTransito=L3.IdLocalidad
                            left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.OrdenEmbarque OE ON rd.IdOrdenEmbarque=oe.IdOrdenEmbarque
                            left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Unitario U on rd.IdUnitario=u.IdUnitario
                            left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Producto P on u.IdProducto=P.IdProducto
                            left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Estilo E on p.IdEstilo=e.IdEstilo
                            left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Usuario Usr on RD.IdUsuarioActualiza=Usr.IdUsuario 
							left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.ConsolidadoEmpaque CE on oe.IdOrdenEmbarque=CE.IdOrdenEmbarque
							left join INDGDLSQL01.INDAR_INACTIONWMS.DBO.ConsolidadoEmpaqueDetalle CED on ce.IdConsolidadoEmpaque=CED.IdConsolidadoEmpaque
							left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Localidad L4 ON CED.IdLocalidadConsolidado=L4.IdLocalidad							
                            group by OE.IdOrdenEmbarque,oe.Mov,oe.NumPedido,e.Clave,L3.Codigo,L2.Codigo,RD.FechaActualizado,Usr.Nombre,R.FechaHoraInicio,R.FechaHoraFin,Usr.Usuario,L4.Codigo) AS RD on oe.IdOrdenEmbarque=rd.IdOrdenEmbarque and  e.Clave=rd.Clave-- and rd.NumPedido=@pedido
                            where oe.NumPedido=@pedido";
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        
        }

        public void cargaTiempos()
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();


            SqlCommand cmd = new SqlCommand("", myConnection);
            cmd.CommandText = @"select top 1 fechacomenzo from vermovtiempo where situacion='Por Surtir' and id=(select id from venta where movid='" + movid + "' and mov='" + mov + "')     order by fechacomenzo desc";
            var resultado = cmd.ExecuteScalar().ToString();
            labelHora.Text = resultado.ToString();
        
        
        
        }
    }
}
