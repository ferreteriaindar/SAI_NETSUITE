using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SAI_NETSUITE.WMS.Recibo
{
    public partial class SobrePedidoPendientes : UserControl
    {
        string sqlString;
        public SobrePedidoPendientes(string sql)
        {
            sqlString = sql;
            InitializeComponent();
        }

        public void cargaInfo()
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            string query = @"select OFA.FechaActualizado,OFA.Mov,MovId,OFA.Mov+CONVERT(varchar(15),OFA.NumOrden) AS CODIGO,OFA.Proveedor, E.Clave,E.Categoria,OFD.Cantidad,OFD.CantidadRecibida from  INDAR_INACTIONWMS.dbo.OrdenFabricacion OFA
                            left join INDAR_INACTIONWMS.dbo.OrdenFabricacionDetalle OFD on OFA.IdOrdenFabricacion=OFD.IdOrdenFabricacion
                            left join INDAR_INACTIONWMS.dbo.Estilo E on OFD.IdEstilo=e.IdEstilo
                            where OFA.FechaActualizado>= DATEADD(DD,-3,getdate())
                            and IdEstatusOrdenFabricacion=1  and ofa.Mov='OE' and e.Categoria='S/PEDIDO'
                            ORDER BY OFA.FechaActualizado ASC";

            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
            
        }

        private void SobrePedidoPendientes_Load(object sender, EventArgs e)
        {
            cargaInfo();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string carpeta = string.Empty;
            carpeta = System.IO.Path.GetTempPath();

            gridControl1.ExportToXlsx(carpeta + "\\sobrePedido.xlsx");
            Process pdfexport = new Process();
            pdfexport.StartInfo.FileName = "EXCEL.exe";
            pdfexport.StartInfo.Arguments = carpeta + "\\SobrePedido.xlsx";
            pdfexport.Start();
        }
    }
}
