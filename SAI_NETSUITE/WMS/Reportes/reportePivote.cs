using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraPivotGrid;


namespace SAI_NETSUITE.WMS.Reportes
{
    public partial class reportePivote : DevExpress.XtraEditors.XtraUserControl
    {
      
        string sqlString;
        public reportePivote(string sql)
        {
          //  sqlString = sql;
            sqlString = "Data Source=192.168.87.100;" + "Initial Catalog=INDAR_INACTIONWMS;" + "User id=sa;" + "Password=7Ind4r7;Connection Timeout=200";
            InitializeComponent();
        }

        private void reportePivote_Load(object sender, EventArgs e)
        {

            try
            {
                cargainfo();
                //  pivotGridControl1.ActiveFilterString = "[fieldAREA1] Is Not Null";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Por favor de reintentar");
            }
        }


        public void cargainfo()
        {
            System.Data.SqlClient.SqlConnection myConnection = new SqlConnection(sqlString);
            string query = @"SELECT IdOrdenEmbarque,Mov,NumPedido,FechaIngreso,Prioridad,CLIENTE,FormaEnvio,Clave,IdEstilo,
                                CASE WHEN IdEstatusOrdenEmbarque=5 THEN 1 ELSE 0 END AS SURTIDO,CASE WHEN IdEstatusOrdenEmbarque=1 THEN 1 ELSE 0 END AS PORSURTIR ,
                                case when AREA=null then  (select TOP 1 A.Nombre from RecoleccionDetalle RD with (nolock)
                                LEFT JOIN Unitario U with (nolock) ON RD.IdUnitario=U.IdUnitario
                                LEFT JOIN Producto P with (nolock) ON U.IdProducto=P.IdProducto
                                LEFT JOIN Estilo E3 with (nolock) ON P.IdEstilo=E3.IdEstilo
                                LEFT JOIN Localidad L with (nolock) ON RD.IdLocalidad=L.IdLocalidad
                                LEFT JOIN Area A  with (nolock) ON L.IdArea=A.IdArea
                                where rd.IdOrdenEmbarque=Q.IdOrdenEmbarque AND E3.IdEstilo=Q.IdEstilo)  else AREA end as AREA
                                 from (
                                SELECT OE.IdOrdenEmbarque, OE.Mov,OE.NumPedido,OE.FechaIngreso,OE.Prioridad,CT.Clave AS CLIENTE,OE.FormaEnvio,E.Clave,E.IdEstilo,PR.IdEstatusOrdenEmbarque,
                                CASE WHEN PR.IdEstatusOrdenEmbarque=5 THEN 
                                (select TOP 1 A.Nombre from RecoleccionDetalle  RE with (nolock)
                                LEFT JOIN Localidad L  with (nolock) ON RE.IdLocalidad=L.IdLocalidad
                                LEFT JOIN Area A  with (nolock) ON L.IdArea=A.IdArea
                                LEFT JOIN Unitario U  with (nolock) ON RE.IdUnitario=U.IdUnitario
                                LEFT JOIN Producto P with (nolock) ON U.IdProducto=P.IdProducto
                                LEFT JOIN Estilo E2 with (nolock) ON P.IdEstilo=E2.IdEstilo
                                WHERE IdOrdenEmbarque=OE.IdOrdenEmbarque AND   E2.IdEstilo=PR.IdEstilo) 
                                    WHEN PR.IdEstatusOrdenEmbarque IN (1,4) THEN   [dbo].[fnObtenArea](oe.IdOrdenEmbarque,pr.IdEstilo)
                                 END AS AREA


                                 FROM OrdenEmbarque OE
                                LEFT JOIN PedidoRenglon PR with (nolock) ON OE.IdOrdenEmbarque=PR.IdOrdenEmbarque
                                LEFT JOIN Estilo E with (nolock) ON PR.IdEstilo=E.IdEstilo
                                LEFT JOIN Cliente CT with (nolock) ON OE.IdCliente=CT.IdCliente
                                WHERE OE.IdEstatusOrdenEmbarque IN (1,4)
                                ) as q   ";
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            da.SelectCommand.CommandTimeout = 0;
            DataSet ds = new DataSet();
            da.Fill(ds);
           pivotGridControl1.DataSource = ds.Tables[0];



        }

        private void pivotGridControl1_CustomDrawCell(object sender, DevExpress.XtraPivotGrid.PivotCustomDrawCellEventArgs e)
        {
            
        }

        private void pivotGridControl1_CellDoubleClick(object sender, PivotCellEventArgs e)
        {
        //    PivotGridHitInfo hi = pivotGridControl1.CalcHitInfo(pivotGridControl1.PointToClient(MousePosition));
        //    if (hi.HitTest == PivotGridHitTest.Cell)
        //    {
        //        var fieldValue = hi.CellInfo.GetFieldValue(fieldNUMPEDIDO1);
        //        var cliente = hi.CellInfo.GetFieldValue(fieldCLIENTE1);
        //        pickingDetalle pd = new pickingDetalle(sqlString, fieldValue.ToString(), cliente.ToString());
        //        pd.ShowDialog();

        //    }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            cargainfo();
        }

        private void pivotGridControl1_CellDoubleClick_1(object sender, PivotCellEventArgs e)
        {
            Console.WriteLine(pivotGridControl1.ActiveFilterString);
        }
    }
}
