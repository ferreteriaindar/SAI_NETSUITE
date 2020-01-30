using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SAI_NETSUITE.Views.ClienteRecoge
{
    public partial class ReporteAlmacenCterecoge : UserControl
    {
        string sqlString = "";
        public ReporteAlmacenCterecoge(string sql)
        {
            sqlString = sql;
            InitializeComponent();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1);
            /* string query = "select factura,fechaentrada,ct.rama,indarneg.dbo.almacencterecoge.cliente,v.embarqueestado,v.formaenvio from indarneg.dbo.almacencterecoge   " +
                           "      left join ( select movid,cliente,embarqueestado,formaenvio from venta where mov='Factura Indar')as v on factura=v.movid " +
                           "      left join cte ct on v.cliente=ct.cliente " +
                           "      where check1 is null  and v.embarqueestado='Pendiente' " +
                           "     and v.FormaEnvio in ('CDI Cliente esta en CDI','CCI Cliente Recoge','CCI Cliente está en CCI','CCI Vendedor Entrega','GDL-07 Cliente Recoge','CDI Cliente Recoge','CCI Cliente está en CCI','Cte Esta en CDI','Cte Esta en Suc1', 'Cte Mostrador','Cte Recoge CDI','Cte Recoge Suc 1','Cte Recoge Surtefacil','Vendedor Entrega','Vendedor Entrega CCI','Cte Esta en CCI','Cte Recoge en CCI','Cte Recoge en GDL 07','GDL-07 Vendedor Entrega')";
                           */
            string query = @"select * from (
                                select AC.factura,AC.fechaentrada,ZI.NSO___ZONAS_CLIENTES_NAME AS rama,AC.cliente,(SELECT top 1 estado FROM Indarneg.dbo.EmbarquesD where i.internalId=EmbarquesD.facturaid order by IdEmbarqueD desc)as embarqueestado,fe.LIST_ITEM_NAME as formaenvio
                                 from indarneg.dbo.almacencterecoge    AC
                                INNER JOIN iws.dbo.Invoices I  ON AC.factura=I.TranId
                                INNER join iws.dbo.Customers C on i.Entity =C.internalid
                                INNER JOIN IWS.DBO.ZonasIndar ZI ON  C.customerZone=ZI.NSO___ZONAS_CLIENTES_ID
                                INNER JOIN IWS.DBO.FormaEnvio FE ON I.ShippingWay=FE.LIST_ID
                                WHERE check1 IS NULL AND AC.fechaEntrada>='20191201'
                                ) as Q where q.embarqueestado <>'ENTREGADO'";

            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

            string carpeta = string.Empty;
            carpeta = System.IO.Path.GetTempPath();

            gridControl1.ExportToXlsx(carpeta + "\\reporteCteRecoge.xlsx");
            Process pdfexport = new Process();
            pdfexport.StartInfo.FileName = "EXCEL.exe";
            pdfexport.StartInfo.Arguments = carpeta + "\\reporteCteRecoge.xlsx";
            pdfexport.Start();
        }
    }
}
