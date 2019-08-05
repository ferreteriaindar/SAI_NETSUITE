using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraBars;
//using SAI.Almacen.WMS.Reportes;

namespace SAI_NETSUITE.WMS
{
    public partial class menuWMS : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        string sqlString,perfil, usuario;
        int idusuariowms;
       // public menuWMS(string sql,string profile,string user,string sqlWms)
             public menuWMS(string sql,string profile,string user)
        {
            sqlString = sql;
         //   sqlString = sqlWms;
            perfil = profile;
            usuario=user;
            idusuariowms = -1;
            InitializeComponent();
        }

        private void btnOE_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ribbonPageOE.Visible == true)
                ribbonPageOE.Visible = false;
            else
                ribbonPageOE.Visible = true;
        }

        private void btnBuscarOe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!txtBuscarOE.EditValue.ToString().Equals(""))
            {
                string query = @"SELECT Ordenentrada,Articulo FROM (
                            SELECT      OrdenEntrada, Articulo, sum(isnull(Cantidad,0))cantIntelisis,
                            (select sum(isnull(rd.Cantidad,0)) from INDGDLSQL01.INDAR_INACTIONWMS.dbo.RecepcionDetalle rd
                             inner join INDGDLSQL01.INDAR_INACTIONWMS.dbo.OrdenFabricacion ofa on ofa.IdOrdenFabricacion = rd.IdOrdenFabricacion
                             inner join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Producto p on p.IdProducto = rd.IdProducto
                             inner join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Estilo es on es.IdEstilo = p.IdEstilo
                             where ofa.numOrden=" + txtBuscarOE.EditValue.ToString() + @" and  es.clave=hj.articulo collate Modern_Spanish_CI_AS)AS cantWMS
                            FROM         OrdenEntrada_HJ hj
                           WHERE     OrdenEntrada = 'OE" +txtBuscarOE.EditValue.ToString()+"'  group by ordenentrada,articulo) AS Q    where  cantIntelisis<>isnull(cantwms,0)";
                Console.WriteLine(query);
                sencilloGrid sg = new sencilloGrid(query, sqlString, "OE"+txtBuscarOE.EditValue.ToString());
                sg.Parent = panelControl1;
                sg.Dock = DockStyle.Fill;
                sg.BringToFront();
            }
            else MessageBox.Show("Ingresa el numero de la OE");

        }

        private void btnPREC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(ribbonPagePREC.Visible==false)
            {
            llenaListaPrec();
            ribbonPagePREC.Visible=true;
            }
            else ribbonPagePREC.Visible=false;

        }

        public void llenaListaPrec()
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            string query = @"select Codigo from  INDGDLSQL01.INDAR_INACTIONWMS.dbo.Localidad where Codigo like 'PREC%'";
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            repositoryPREC.DataSource = ds.Tables[0];
            repositoryPREC.DisplayMember = "Codigo";
            repositoryPREC.ValueMember = "Codigo";
        }


        public void llenaListaMovil()
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            string query = @"select Codigo from  INDGDLSQL01.INDAR_INACTIONWMS.dbo.Localidad where Codigo like 'MOVIL%'";
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
          repositoryMovil.DataSource = ds.Tables[0];
          repositoryMovil.DisplayMember = "Codigo";
          repositoryMovil.ValueMember = "Codigo";
        
        
        
        }

        private void checkPrec_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkPrec.Checked == true)
                barEditItem1.Enabled = false;
            else barEditItem1.Enabled = true;
        }

        private void btnBuscarPrec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //PRUEBA DE  MENSAJES EN EL SVN
            string query;
            if (checkPrec.Checked == false && !barEditItem1.EditValue.ToString().Equals(""))
            {
                query = @"SELECT Ubicacion,Articulo,DescArticulo,Cantidad FROM  INDGDLSQL01.INDAR_INACTIONWMS.dbo.vExistenciasAlmacen where Ubicacion='" + barEditItem1.EditValue.ToString() + "'";
                sencilloGrid sg = new sencilloGrid(query, sqlString, barEditItem1.EditValue.ToString());
                sg.Parent = panelControl1;
                sg.Dock = DockStyle.Fill;
                sg.BringToFront();
            }
            else
            {
                query = @"SELECT Ubicacion,Articulo,DescArticulo,Cantidad FROM  INDGDLSQL01.INDAR_INACTIONWMS.dbo.vExistenciasAlmacen where Ubicacion  like 'PREC%'";
                sencilloGrid sg = new sencilloGrid(query, sqlString, "TODOS LOS PRECS");
                sg.Parent = panelControl1;
                sg.Dock = DockStyle.Fill;
                sg.BringToFront();
            }
           
        }

        private void btnReportesReciboPartidas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        
        }

        private void btnReportesRecibo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string query="",mensaje="";
            if (checkExistenciaTotal.Checked || btnCaducables.Checked ||btnAdminOrdenesSalida.Checked)
            {
                barFechafin.EditValue = DateTime.Now.ToShortDateString();
                barFechaInicio.EditValue = DateTime.Now.ToShortDateString();
            }
            if (!barFechaInicio.EditValue.ToString().Equals("") && !barFechafin.EditValue.ToString().Equals(""))
            {
                if (checkHistoricoAcomodo.Checked)
                {
//                    query = @"select u.Usuario,e.Clave,ad.Cantidad ,(select codigo from INDGDLSQL01.INDAR_INACTIONWMS.dbo.Localidad lol where lol.IdLocalidad=alm.IdLocalidad) as origen,l.Codigo as destino,ad.FechaActualizado from  INDGDLSQL01.INDAR_INACTIONWMS.dbo.AlmacenadoDetalle ad
//                                    left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Almacenado alm on ad.IdAlmacenado=alm.IdAlmacenado
//                                    left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Usuario  u ON ad.IdUsuarioActualiza=u.IdUsuario
//                                    left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Estilo  e ON ad.IdProducto=e.IdEstilo
//                                    left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Localidad l ON ad.IdLocalidadDestino=l.IdLocalidad
//                                    where ad.FechaActualizado>='" + Convert.ToDateTime(barFechaInicio.EditValue.ToString()).ToString("yyyyMMdd") + @"' AND ad.FechaActualizado<='" + Convert.ToDateTime(barFechafin.EditValue.ToString()).ToString("yyyyMMdd") + @"'" +
                    query = @"SELECT U.Usuario,E.Clave,AD.Cantidad,(select localidad.Codigo from INDGDLSQL01.INDAR_INACTIONWMS.dbo.Localidad where IdLocalidad=alm.IdLocalidad) as Origen, L.Codigo AS destino,ad.FechaActualizado FROM INDGDLSQL01.INDAR_INACTIONWMS.dbo.AlmacenadoDetalle AD
                                        LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.Localidad L ON AD.IdLocalidadDestino=L.IdLocalidad
                                        left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Usuario U on ad.IdUsuarioActualiza=u.IdUsuario
                                        left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Almacenado alm on ad.IdAlmacenado=alm.IdAlmacenado
                                        left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Producto P ON  ad.IdProducto= p.IdProducto
                                        left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Estilo E	 ON  p.IdEstilo=E.IdEstilo
                                        where AD.FechaActualizado>='" + Convert.ToDateTime(barFechaInicio.EditValue.ToString()).ToString("yyyyMMdd") + @"' AND AD.FechaActualizado<='" + Convert.ToDateTime(barFechafin.EditValue.ToString()).ToString("yyyyMMdd") + @"'" +            
                                  @"UNION
                                    select usr.Usuario,
                                            e.Clave,
                                            td.Cantidad,
                                            (select codigo from  INDGDLSQL01.INDAR_INACTIONWMS.dbo.Localidad where IdLocalidad=( select idlocalidadorigen from INDGDLSQL01.INDAR_INACTIONWMS.dbo.Transferencia where IdTransferencia=td.Idtransferencia)) AS origen,
                                            (select codigo from INDGDLSQL01.INDAR_INACTIONWMS.dbo. Localidad where IdLocalidad=( select IdLocalidadDestino from INDGDLSQL01.INDAR_INACTIONWMS.dbo.Transferencia where IdTransferencia=td.Idtransferencia)) as destino,
                                            td.fechaactualizado
                                            from INDGDLSQL01.INDAR_INACTIONWMS.dbo.TransferenciaDetalle td
                                            left join  INDGDLSQL01.INDAR_INACTIONWMS.dbo.Unitario  U on td.IdUnitario=u.IdUnitario
                                            left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Estilo  E on u.IdProducto=e.IdEstilo
                                            left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Usuario usr on td.IdUsuarioActualiza=usr.IdUsuario
                                            where td.FechaActualizado>='" + Convert.ToDateTime(barFechaInicio.EditValue.ToString()).ToString("yyyyMMdd") + "' and  td.FechaActualizado<='" + Convert.ToDateTime(barFechafin.EditValue.ToString()).ToString("yyyyMMdd") + "'";

                    Console.WriteLine(query);
                     mensaje = "Historico Acomodo";
                }

                if (checkReporteRecibo.Checked)
                {
                    query = @"select u.Nombre,u.usuario,count(IdProducto) as partidas,convert(nvarchar(10),rd.FechaActualizado,103),datepart(HOUR,rd.fechaactualizado) as hora from INDGDLSQL01.INDAR_INACTIONWMS.dbo.RecepcionDetalle rd
                            left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Usuario  u ON rd.IdUsuarioActualiza=u.IdUsuario
                            where  rd.FechaActualizado>='" + Convert.ToDateTime(barFechaInicio.EditValue.ToString()).ToString("yyyyMMdd") + @"' AND rd.FechaActualizado<='" + Convert.ToDateTime(barFechafin.EditValue.ToString()).ToString("yyyyMMdd") + @"'
                            group by  u.Nombre,u.usuario,convert(nvarchar(10),rd.FechaActualizado,103),DATEPART(hour,rd.fechaactualizado)";
                    Console.WriteLine(query);
                    mensaje = "Productividad Recibo";
                }

                if (checkProdcutividadAcomodo.Checked)
                {

                    query = @"select u.Usuario,u.Nombre,count(ad.IdProducto)as partidas,convert(nvarchar(10),ad.FechaActualizado,103) as fecha,datepart(HOUR,ad.fechaactualizado) as Hora from INDGDLSQL01.INDAR_INACTIONWMS.dbo.AlmacenadoDetalle ad
                            left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Usuario  u ON ad.IdUsuarioActualiza=u.IdUsuario
                            where ad.FechaActualizado>='" + Convert.ToDateTime(barFechaInicio.EditValue.ToString()).ToString("yyyyMMdd") + @"' AND ad.FechaActualizado<='" + Convert.ToDateTime(barFechafin.EditValue.ToString()).ToString("yyyyMMdd") +
                            "' group by  u.Usuario,u.Nombre,convert(nvarchar(10),ad.FechaActualizado,103),datepart(HOUR,ad.fechaactualizado)" +
                            @"UNION 
                            select usr.Usuario,usr.nombre,
                            count(td.IdUnitario) as partidas,
                            convert(nvarchar(10),td.fechaactualizado,103) as fecha,
                            datepart(HOUR,td.fechaactualizado) as Hora
                            from INDGDLSQL01.INDAR_INACTIONWMS.dbo.TransferenciaDetalle td
                                         
                            left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Usuario usr  on td.IdUsuarioActualiza=usr.IdUsuario
                            where td.FechaActualizado>='" + Convert.ToDateTime(barFechaInicio.EditValue.ToString()).ToString("yyyyMMdd") + @"' and  td.FechaActualizado<='"+Convert.ToDateTime(barFechafin.EditValue.ToString()).ToString("yyyyMMdd")+@"'
			                group by  usr.Usuario,usr.nombre,convert(nvarchar(10),td.fechaactualizado,103),datepart(HOUR,td.fechaactualizado)";

                  mensaje = "Productividad Acomodo";
                  Console.WriteLine(query);
                }

                if (checkHistoricoREcibo.Checked)
                {
                    query = @"select O.Mov+' '+O.NumOrden,rd.FechaActualizado, L.Codigo,e.Clave,rd.Cantidad,U.Usuario,u.Nombre from INDGDLSQL01.INDAR_INACTIONWMS.dbo.recepcionDetalle rd
                            LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.Localidad l on rd.IdLocalidad=l.IdLocalidad
                            left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.OrdenFabricacion O on rd.IdOrdenFabricacion=o.IdOrdenFabricacion
                            left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Producto P on rd.IdProducto=p.IdProducto
                            left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Estilo E on p.IdEstilo=e.IdEstilo
                            left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Usuario U on rd.IdUsuarioActualiza=u.IdUsuario
                            where rd.FechaActualizado>='" + Convert.ToDateTime(barFechaInicio.EditValue.ToString()).ToString("yyyyMMdd")+@"' and rd.FechaActualizado<='" + Convert.ToDateTime(barFechafin.EditValue.ToString()).ToString("yyyyMMdd")+"'";
                    mensaje = "HISTORICO RECIBO";
                }

                if (checkExistenciaTotal.Checked)
                {
                    query = @"select Articulo,sum(cantidad) as existencia,Ubicacion from INDGDLSQL01.INDAR_INACTIONWMS.dbo.vExistenciasAlmacen
                                group by Articulo,Ubicacion  order by Articulo asc";
                    mensaje = "TOTAL DE INVENTARIO";
                
                }

                if (checkHistoricoLocalidad.Checked)
                {
                    query = @"SELECT	L.Codigo AS origen,E.Clave,AD.Cantidad,
			                                (SELECT Codigo
				                                FROM INDGDLSQL01.INDAR_INACTIONWMS.dbo.Localidad
				                                WHERE	IdLocalidad=AD.IdLocalidadDestino) AS DESTINO,
			                                AD.FechaActualizado,'ACOMODO' AS MODULO,KT.NombreTransaccion AS TRANSACCION,
			                                U.Nombre
		                                FROM INDGDLSQL01.INDAR_INACTIONWMS.dbo.Almacenado  A
                                            LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.AlmacenadoDetalle AD
				                                ON a.IdAlmacenado = AD.IdAlmacenado
                                            LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.Localidad L
				                                ON A.IdLocalidad = L.IdLocalidad
                                            LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.Producto  P
				                                ON AD.IdProducto = P.IdProducto
                                            LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.Estilo  E 
				                                ON P.IdEstilo = E.IdEstilo
                                            LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.Usuario U
				                                ON AD.IdUsuarioActualiza=U.IdUsuario
			                                LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.KardexTransacciones KT
				                                ON KT.IdTransaccion = AD.AlmacenadoDetalle AND AD.FechaActualizado = KT.FechaTransaccion
	                                WHERE AD.FechaActualizado>='" + Convert.ToDateTime(barFechaInicio.EditValue.ToString()).ToString("yyyyMMdd") + @"' and ad.FechaActualizado<='" + Convert.ToDateTime(barFechafin.EditValue.ToString()).ToString("yyyyMMdd") + @"'
                                UNION
                                    SELECT	L.Codigo AS ORIGEN, E.Clave, TD.Cantidad,
			                                (SELECT Codigo
				                                FROM INDGDLSQL01.INDAR_INACTIONWMS.dbo.Localidad
			                                WHERE IdLocalidad = T.IdLocalidadDestino) AS DESTINO,
			                                TD.FechaActualizado,'ACOMODO' AS MODULO, KT.NombreTransaccion AS TRANSACCION,
			                                US.NOMBRE
		                                FROM INDGDLSQL01.INDAR_INACTIONWMS.dbo.Transferencia T
			                                LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.TransferenciaDetalle TD
				                                ON T.IdTransferencia = TD.IdTransferencia
			                                LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.Localidad L
				                                ON T.IdLocalidadOrigen = L.IdLocalidad
			                                LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.Unitario U
				                                ON TD.IdUnitario = U.IdUnitario
			                                LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.Producto P
				                                ON U.IdProducto = P.IdProducto
			                                LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.Estilo  E
				                                ON P.IdEstilo = E.IdEstilo
			                                LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.Usuario US
				                                ON TD.IdUsuarioActualiza = US.IdUsuario
			                                LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.KardexTransacciones KT
				                                ON KT.IdTransaccion = TD.IdTransferenciaDetalle AND TD.FechaActualizado = KT.FechaTransaccion
	                                WHERE TD.FechaActualizado>='" + Convert.ToDateTime(barFechaInicio.EditValue.ToString()).ToString("yyyyMMdd") + @"' AND TD.FechaActualizado<='" + Convert.ToDateTime(barFechafin.EditValue.ToString()).ToString("yyyyMMdd") + @"'
                                UNION
                                    SELECT	L.Codigo AS ORIGEN, E.Clave, RD.Cantidad,
			                                (SELECT Codigo
				                                FROM INDGDLSQL01.INDAR_INACTIONWMS.dbo.Localidad
			                                WHERE IdLocalidad = RD.IdLocalidadDestino) AS DESTINO,
			                                RD.FechaActualizado,'REABASTO' AS MODULO, KT.NombreTransaccion AS TRANSACCION,
			                                U.NOMBRE
		                                FROM INDGDLSQL01.INDAR_INACTIONWMS.dbo.Reabasto R
			                                LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.ReabastoDetalle RD
				                                ON R.IdReabasto=RD.IdReabasto
			                                LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.Localidad L
				                                ON RD.IdLocalidadOrigen = L.IdLocalidad
			                                LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.Estilo  E
				                                ON RD.IdEstilo = E.IdEstilo
			                                LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.Usuario U
				                                ON RD.IdUsuarioActualiza = U.IdUsuario
			                                LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.KardexTransacciones KT
				                                ON KT.IdTransaccion = RD.IdReabastoDetalle AND RD.FechaActualizado = KT.FechaTransaccion
                                    WHERE RD.FechaActualizado>='" + Convert.ToDateTime(barFechaInicio.EditValue.ToString()).ToString("yyyyMMdd") + @"' AND RD.FechaActualizado<='" + Convert.ToDateTime(barFechafin.EditValue.ToString()).ToString("yyyyMMdd") + @"'
                                UNION
                                    SELECT	L.Codigo AS ORIGEN, E.Clave, RD.Cantidad,
			                                (SELECT Codigo
				                                FROM INDGDLSQL01.INDAR_INACTIONWMS.dbo.Localidad
			                                WHERE IdLocalidad = RD.IdLocalidadTransito) AS DESTINO,
			                                RD.FechaActualizado,'SURTIDO', KT.NombreTransaccion AS TRANSACCION,
			                                US.Nombre
		                                FROM INDGDLSQL01.INDAR_INACTIONWMS.dbo.RecoleccionDetalle RD
			                                LEFT JOIN  INDGDLSQL01.INDAR_INACTIONWMS.dbo.Localidad L
				                                ON RD.IdLocalidad=L.IdLocalidad
			                                LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.Unitario U
				                                ON RD.IdUnitario=u.IdUnitario
			                                LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.Producto P
				                                ON U.IdProducto=P.IdProducto
			                                LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.Estilo  E
				                                ON P.IdEstilo=E.IdEstilo
			                                LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.Usuario US
				                                ON RD.IdUsuarioActualiza=Us.IdUsuario
			                                LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.KardexTransacciones KT
				                                ON KT.IdTransaccion = RD.IdRecoleccionDetalle AND RD.FechaActualizado = KT.FechaTransaccion
                                    WHERE RD.FechaActualizado>='" + Convert.ToDateTime(barFechaInicio.EditValue.ToString()).ToString("yyyyMMdd") + @"' AND RD.FechaActualizado<='" + Convert.ToDateTime(barFechafin.EditValue.ToString()).ToString("yyyyMMdd") + "'" + @"
                                UNION 
                                    SELECT	L.Codigo AS ORIGEN, E.Clave, AD.Cantidad, '' AS DESTINO, AD.FechaActualizado, 'AJUSTE' AS MODULO,
			                                KT.NombreTransaccion AS TRANSACCION, U.Nombre
		                                FROM INDGDLSQL01.INDAR_INACTIONWMS.dbo.AjusteDetalle  AD
			                                LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.Localidad L 
				                                ON AD.IdLocalidad = L.IdLocalidad
			                                LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.Producto  P 
				                                ON AD.IdProducto = P.IdProducto
			                                LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.Estilo  E
				                                ON P.IdEstilo = E.IdEstilo
			                                LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.Usuario U
				                                ON AD.IdUsuarioActualiza = U.IdUsuario
			                                LEFT JOIN INDGDLSQL01.INDAR_INACTIONWMS.dbo.KardexTransacciones KT
				                                ON KT.IdTransaccion = AD.IdAjusteDetalle AND AD.FechaActualizado = KT.FechaTransaccion
                                    where ad.FechaActualizado>='" + Convert.ToDateTime(barFechaInicio.EditValue.ToString()).ToString("yyyyMMdd") + @"' AND AD.FechaActualizado<='" + Convert.ToDateTime(barFechafin.EditValue.ToString()).ToString("yyyyMMdd") + "'";
                                                    Console.WriteLine(query);

                
                
                }

                if (checkTiempos.Checked)
                {
                    query = "exec  INDGDLSQL01.INDARWMS.dbo.spReporteTiempoWMS  '" + Convert.ToDateTime(barFechaInicio.EditValue.ToString()).ToString("yyyyMMdd") + "', '" + Convert.ToDateTime(barFechafin.EditValue.ToString()).ToString("yyyyMMdd")+"'";
                    Console.WriteLine(query);
                    mensaje = "Reporte de tiempos de un pedido";
                }
                if (btnCaducables.Checked)
                {
                    query = @"SELECT PAGINA = CASE WHEN (FILA % 20) = 0 THEN (FILA/20) ELSE (FILA/20)+1 END,*
                             FROM ( SELECT Row_Number()Over (Order By TOPPZA) As FILA, * FROM 
                             ( SELECT R.ARTICULO,A.DESCRIPCION1,R.CANTIDAD,R.IMPORTE, TOPPZA=ISNULL(A.IndarRankingPza,0),TOPIMP=ISNULL(A.IndarRankingImp,0), TIPO=CASE WHEN A.ALTA > '02/03/2017'  THEN 'Nuevo' ELSE '' END, A.ABC,RAMA=AC.DESCRIPCION1, CAJAMASTER=ISNULL(A.INDARCAJAMASTER,0),EMPAQUEMINIMO=ISNULL(A.INDAREMPAQUEMINIMO,0), PRECIOLISTA=ROUND(A.PRECIOLISTA*(1+(ISNULL(CPD.MONTO,0)/100)),2), PROMOART=APD.MONTO, PROMOCLI=CPD.MONTO FROM 
                             ( SELECT VD.ARTICULO, CANTIDAD=SUM(VD.CANTIDAD), IMPORTE=SUM(ROUND((ISNULL(VD.PRECIO,0)*ISNULL(VD.CANTIDAD,0))-ISNULL(VD.DESCUENTOIMPORTE,0),2)) FROM SERVERWEB.INDARWEB.DBO.VENTAD VD LEFT JOIN VENTA V ON V.ID = VD.ID LEFT JOIN CTE CT ON CT.CLIENTE = V.CLIENTE LEFT JOIN ART A ON A.ARTICULO = VD.ARTICULO  WHERE V.FECHAEMISION BETWEEN '01/02/2017' AND '31/01/2018'  AND VD.ARTICULO NOT IN 
                             (SELECT VDx.ARTICULO FROM SERVERWEB.INDARWEB.DBO.VENTAD VDx LEFT JOIN VENTA Vx ON Vx.ID = VDx.ID LEFT JOIN CTE CTx ON CTx.CLIENTE = Vx.CLIENTE LEFT JOIN ART Ax ON Ax.ARTICULO = VDx.ARTICULO 
                             WHERE Vx.FECHAEMISION BETWEEN '01/11/2017' AND '31/01/2018'  AND ((Vx.MOV = 'Factura Indar' AND ISNULL(Vx.ORIGENTIPO,'')<>'VMOS') OR Vx.MOV = 'Nota' ) AND Vx.EMPRESA = 'FIN' AND Vx.ESTATUS = 'CONCLUIDO' AND Vx.CLIENTE NOT IN ('FSF','D002','D057') AND Vx.CLIENTE NOT LIKE 'P%' AND Ax.CATEGORIA = 'LINEA' AND Vx.CLIENTE = 'C009445' GROUP BY VDx.ARTICULO ) AND ((V.MOV = 'Factura Indar' AND ISNULL(ORIGENTIPO,'')<>'VMOS') OR V.MOV = 'Nota' ) AND V.EMPRESA = 'FIN' AND V.ESTATUS = 'CONCLUIDO' AND V.CLIENTE NOT IN ('FSF','D002','D057') AND V.CLIENTE NOT LIKE 'P%' AND A.CATEGORIA = 'LINEA' AND V.CLIENTE = 'C009445' GROUP BY VD.ARTICULO ) AS R LEFT JOIN ART A ON A.ARTICULO = R.ARTICULO LEFT JOIN SERVERWEB.INDARWEB.DBO.ARTCATEGORIAS AC ON AC.ARTICULO = A.RAMA LEFT JOIN PRECIO AP ON AP.ARTICULO = R.ARTICULO LEFT JOIN PRECIOD APD ON APD.ID = AP.ID AND APD.CANTIDAD = 1 LEFT JOIN PRECIO CP ON CP.CLIENTE = 'C009445' LEFT JOIN PRECIOD CPD ON CPD.ID = CP.ID ) AS X ) AS Y";
                    Console.WriteLine(query);
                
                
                }
                if (btnCaducables.Checked)
                {

                    query = "exec IndarWms.dbo.spcaducables";
                    Console.WriteLine(query);
                
                }
                if(btnTiempoEmpaque.Checked)
                {
                    query = "exec IndarWms.dbo.sptiempoempaque  '" + Convert.ToDateTime(barFechaInicio.EditValue.ToString()).ToString("yyyyMMdd") + "','" + Convert.ToDateTime(barFechafin.EditValue.ToString()).ToString("yyyyMMdd") + "'";
                    Console.WriteLine(query);
                    mensaje = "Facturas wms/Intelisis";
                }
                if (btnAdminOrdenesSalida.Checked)
                {
                    query = "exec  IndarWms.dbo.spAdminOrdenes";
                    mensaje = "Admin Ordenes de Salida";
                }


                sencilloGrid sg = new sencilloGrid(query, sqlString, mensaje);
                
                sg.Parent = panelControl1;
                sg.Dock = DockStyle.Fill;
                sg.BringToFront();

            }
            else MessageBox.Show("Ingresa la fecha inicio y fecha fin");
        }

        private void btnUsuarios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            wms_usuarios wu = new wms_usuarios(sqlString);
            panelControl1.Controls.Clear();
            wu.Parent = panelControl1;
            wu.Dock = DockStyle.Fill;
            wu.BringToFront();
        }

        private void checkReporteRecibo_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkReporteRecibo.Checked == true)
            {
                quitaChecks(checkReporteRecibo.Caption);
        
            }

        }

        private void checkHistoricoAcomodo_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkHistoricoAcomodo.Checked == true)
            {
                quitaChecks(checkHistoricoAcomodo.Caption);
            }
        }

        private void checkProdcutividadAcomodo_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkProdcutividadAcomodo.Checked == true)
            {
                quitaChecks(checkProdcutividadAcomodo.Caption);
            }
        }

        private void checkHistoricoREcibo_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(checkHistoricoREcibo.Checked==true)
            quitaChecks(checkHistoricoREcibo.Caption);
        }

        private void btnMovil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ribbonPageGroup5.Visible = true;
            llenaListaMovil();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string query;
            if ( checkTodosMovil.Checked == false && !barItemfechaMovil.EditValue.ToString().Equals(""))
            {
                query = @"SELECT Ubicacion,Articulo,DescArticulo,Cantidad FROM  INDGDLSQL01.INDAR_INACTIONWMS.dbo.vExistenciasAlmacen where Ubicacion='" + barItemfechaMovil.EditValue.ToString() + "'";
                sencilloGrid sg = new sencilloGrid(query, sqlString, barItemfechaMovil.EditValue.ToString());
                sg.Parent = panelControl1;
                sg.Dock = DockStyle.Fill;
                sg.BringToFront();
            }
            else
            {
                query = @"SELECT Ubicacion,Articulo,DescArticulo,Cantidad FROM  INDGDLSQL01.INDAR_INACTIONWMS.dbo.vExistenciasAlmacen where Ubicacion  like 'MOVIL%'";
                sencilloGrid sg = new sencilloGrid(query, sqlString, "TODOS LOS MOVIL");
                sg.Parent = panelControl1;
                sg.Dock = DockStyle.Fill;
                sg.BringToFront();
            }
           
        }

        private void checkTodosMovil_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkTodosMovil.Checked)
                barItemfechaMovil.Enabled = false;
            else barItemfechaMovil.Enabled = false;
        }

        private void menuWMS_Load(object sender, EventArgs e)
        {
            if (perfil.Equals("Jefe Almacen") || usuario.Equals("administrador"))
            {
                ribbonPageAdministracion.Visible = true;
                ribbonSlotting.Visible = true;
            }
            else
            {
                ribbonPageAdministracion.Visible = false;
                ribbonSlotting.Visible = false;

            }

        }

        private void checkExistenciaTotal_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkExistenciaTotal.Checked)
            {
                barFechaInicio.Enabled = false;
                barFechafin.Enabled = false;
                quitaChecks(checkExistenciaTotal.Caption);

            }
            else
            {
                barFechaInicio.Enabled = true;
                barFechafin.Enabled = true;
            }
            
        }

        private void btnBarras_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            WMS.CodigoBarras cb = new  WMS.CodigoBarras (sqlString);
            cb.Parent = panelControl1;
            cb.Dock = DockStyle.Fill;
            cb.BringToFront();
        }

        private void btnSurtidoPicking_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Reportes.ReporteSurtidoPicking rsp = new Reportes.ReporteSurtidoPicking();
            panelControl1.Controls.Clear();
            rsp.Parent = panelControl1;
            rsp.Dock = DockStyle.Fill;
            rsp.BringToFront();
        }

        private void btnBloquear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            administracion.bloquearPedido    bp = new administracion.bloquearPedido(sqlString);
            panelControl1.Controls.Clear();
            bp.Parent = panelControl1;
            bp.Dock = DockStyle.Fill;
            bp.BringToFront();
        }

        private void btnPickingPivot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*if(!panelControl1.Controls.Contains(SAI.Almacen.WMS.Reportes.reporteSurtidoPickingCR.Instance))
            {
                panelControl1.Controls.Add(SAI.Almacen.WMS.Reportes.reporteSurtidoPickingCR.Instance);
                reporteSurtidoPickingCR.Instance.Dock = DockStyle.Fill;
                reporteSurtidoPickingCR.Instance.BringToFront();
             }
            reporteSurtidoPickingCR.Instance.BringToFront();
            */
            /*
            reporteSurtidoPickingCR cr = new reporteSurtidoPickingCR();
            panelControl1.Controls.Clear();
            cr.Parent = panelControl1;
            cr.Dock = DockStyle.Fill;
            cr.BringToFront();
            */


            //   ANTES DE AGREGAR LO DE CLIENTE RECOGE
             
            Reportes.reporteSurtipickingPIVOT rsp = new Reportes.reporteSurtipickingPIVOT(sqlString);
            panelControl1.Controls.Clear();
            rsp.Parent = panelControl1;
            rsp.Dock = DockStyle.Fill;
            rsp.BringToFront();
             
        }

        private void btnAsignaUbicaciones_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          
        }


        public void quitaChecks(string titulo)
        {
            foreach (BarItemLink itemLink in ribbonPageGroup3.ItemLinks)
            {
                BarItem item = itemLink.Item;
                if (item.GetType() == typeof( DevExpress.XtraBars.BarCheckItem))
                {
                    if(!item.Caption.Equals(titulo))
                    ((DevExpress.XtraBars.BarCheckItem)item).Checked = false;
                }
            
            
            }
        
    }
        

        private void checkHistoricoLocalidad_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            
            if(checkHistoricoLocalidad.Checked==true)
                quitaChecks(checkHistoricoLocalidad.Caption);
        }

        private void btnAsignarPiso_ItemClick(object sender, ItemClickEventArgs e)
        {
            Surtido.asignaPiso ap = new Surtido.asignaPiso(sqlString);
            ap.Parent = panelControl1;
            ap.Dock = DockStyle.Fill;
            ap.BringToFront();
        }

        private void btnPedidosSurtiendose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Surtido.PedidosSurtiendose PS = new Surtido.PedidosSurtiendose(sqlString);

            PS.Parent = panelControl1;
            PS.Dock = DockStyle.Fill;
            PS.BringToFront();
        }

        private void checkTiempos_CheckedChanged(object sender, ItemClickEventArgs e)
        {

            if (checkTiempos.Checked==true)
                quitaChecks(checkTiempos.Caption);
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnPlaneador_ItemClick(object sender, ItemClickEventArgs e)
        {

           

        }

        private void btnEmpaque_ItemClick(object sender, ItemClickEventArgs e)
        {
          /*  WMS.Empaque.empaque emp = new Empaque.empaque(sqlString);
            emp.Parent = panelControl1;
            emp.Dock = DockStyle.Fill;
            emp.BringToFront();
           * */
            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            cmd.CommandText = @"exec INDAR_INACTIONWMS.dbo.spIniciarSesion N'"+txtLlogin.EditValue.ToString()+"',N'"+txtPass.EditValue.ToString()+"'";
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read() && sdr.HasRows)
            {
                idusuariowms = Convert.ToInt32(sdr.GetValue(0).ToString());
               Empaque.empaque emp = new Empaque.empaque(sqlString,idusuariowms);
                emp.Parent = panelControl1;
                emp.Dock = DockStyle.Fill;
                emp.BringToFront();
                labelSession.EditValue = sdr.GetValue(1).ToString();
                btnIniciaSession.Visibility = BarItemVisibility.Never;
         
            }
            else MessageBox.Show("Usuario y/o Contraseña Incorrecta");


        }

        private void btnCerrarSession_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (idusuariowms == -1)
                MessageBox.Show("No puedes Cerrar Sesion \n Por que aun no haz Iniciado");
            else
            {
                SqlConnection myConnection = new SqlConnection(sqlString);
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText = @"exec INDAR_INACTIONWMS.dbo.spSesionAgregar N'SISTEMA',N'SALIDA'," + idusuariowms.ToString();
                int salida = cmd.ExecuteNonQuery();
               
                    btnIniciaSession.Visibility = BarItemVisibility.Always;
                    labelSession.EditValue = "";
                    txtLlogin.EditValue = "";
                    txtPass.EditValue = "";
                    panelControl1.Controls.Clear();

                
            }
        }

        private void PRUEBA_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (btnCaducables.Checked == true)
            {
                quitaChecks(btnCaducables.Caption);
                barFechaInicio.Enabled = false;
                barFechafin.Enabled = false;

            }
            else
            {
                barFechaInicio.Enabled = true;
                barFechafin.Enabled = true;
            }
        }

        private void btnTiempoEmpaque_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (btnTiempoEmpaque.Checked == true)
            {

                quitaChecks(btnTiempoEmpaque.Caption);
            }
        }

        private void barSlotting_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelControl1.Controls.Clear();
           Slotting.caducables ca = new Slotting.caducables(sqlString);
            ca.Parent = panelControl1;
            ca.Dock = DockStyle.Fill;
            ca.BringToFront();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelControl1.Controls.Clear();
            WMS.CodigoBarras cb = new WMS.CodigoBarras(sqlString);
            cb.Parent = panelControl1;
            cb.Dock = DockStyle.Fill;
            cb.BringToFront();
        }

        private void btnAreas_ItemClick(object sender, ItemClickEventArgs e)
        {
            Surtido.SurtidoresConectado sc = new Surtido.SurtidoresConectado(sqlString);
            panelControl1.Controls.Clear();
            sc.Parent = panelControl1;
            sc.Dock = DockStyle.Fill;
            sc.BringToFront();
        }

        private void btnsku_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void btnAdminOrdenesSalida_CheckedChanged(object sender, ItemClickEventArgs e)
        {

            if (checkTiempos.Checked == true)
                quitaChecks(btnAdminOrdenesSalida.Caption);
        }

        private void btnPendientes_ItemClick(object sender, ItemClickEventArgs e)
        {
            Recibo.SobrePedidoPendientes spp = new Recibo.SobrePedidoPendientes(sqlString);
            panelControl1.Controls.Clear();
            spp.Parent = panelControl1;
            spp.Dock = DockStyle.Fill;
            spp.BringToFront();
        }

        private void btnCancelarPartida_ItemClick(object sender, ItemClickEventArgs e)
        {
           //ESTA YA NO SIRVE POR QUE CANCELA PARTIDAS EN INTELISIS

           /* administracion.CancelarPartida cp = new administracion.CancelarPartida();
            panelControl1.Controls.Clear();
            cp.Parent = panelControl1;
            cp.Dock = DockStyle.Fill;
            cp.BringToFront();*/
        }

        private void btnMultiplo_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void btnCumpleaños1_ItemClick(object sender, ItemClickEventArgs e)
        {
            /*Exploradores.Proveedores.consulta_Proveedor cp = new Exploradores.Proveedores.consulta_Proveedor(sqlString);
            cp.Show();*/
        }

        private void btnMultiplos_ItemClick(object sender, ItemClickEventArgs e)
        {
            Recibo.CambiaMultiplo cm = new Recibo.CambiaMultiplo(sqlString);
            panelControl1.Controls.Clear();
            cm.Parent = panelControl1;
            cm.Dock = DockStyle.Fill;
            cm.BringToFront();
        }
    }
}
