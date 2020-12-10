using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SAI_NETSUITE.Views.CXC
{
    public partial class ReporteSAD : UserControl
    {
        public ReporteSAD()
        {
            InitializeComponent();
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            cargaDatos();
        }

        public void cargaDatos()
        {
            DataSet ds = new DataSet();
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                /* string query = @"SELECT e.NAME, C.companyId,ZI.NSO___ZONAS_CLIENTES_NAME AS Zona, S.pedido,S.usuario,S.fecha,S.excepcion,S.comentario,I.TranId AS Factura,
                                 S.cxcMonto,S.cxcAgente,S.cxcFecha,S.cxcComentario,S.validaAgente,S.validadFecha
                                 FROM Indarneg.dbo.SAD  S
                                 INNER  JOIN IWS.dbo.Invoices I ON S.pedidoID=I.createdfrom
                                 INNER JOIN IWS.DBO.SaleOrders SO ON I.createdfrom=SO.internalId
                                 INNER JOIN IWS.DBO.Customers C ON SO.idCustomer=C.internalid
                                 INNER JOIN IWS.DBO.ZonasIndar ZI on C.customerZone=ZI.NSO___ZONAS_CLIENTES_ID
                                 INNER JOIN IWS.DBO.Entity E on zi.AGENTE_COBRADOR_ID=e.ENTITY_ID";*/
                string query = @"SELECT e.NAME, C.companyId,ZI.NSO___ZONAS_CLIENTES_NAME AS Zona, S.pedido,S.usuario,S.fecha,S.excepcion,S.comentario,Factura=ISNULL((SELECT tranId FROM IWS.dbo.Invoices WHERE createdfrom=S.pedidoID),NULL),
                                S.cxcMonto,S.cxcAgente,S.cxcFecha,S.cxcComentario,S.validaAgente,S.validadFecha
                                FROM Indarneg.dbo.SAD  S
                             ---   left   JOIN IWS.dbo.Invoices I ON S.pedidoID=I.createdfrom
                                INNER JOIN IWS.DBO.SaleOrders SO ON S.pedidoID=SO.internalId
                                INNER JOIN IWS.DBO.Customers C ON SO.idCustomer=C.internalid
                                INNER JOIN IWS.DBO.ZonasIndar ZI on C.customerZone=ZI.NSO___ZONAS_CLIENTES_ID
                                INNER JOIN IWS.DBO.Entity E on zi.AGENTE_COBRADOR_ID=e.ENTITY_ID";
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                da.Fill(ds);
                gridControl1.DataSource = ds.Tables[0];

            }
            gridView1.Columns["cxcFecha"].DisplayFormat.FormatString = "G";
            gridView1.Columns["fecha"].DisplayFormat.FormatString = "G";
            gridView1.Columns["validadFecha"].DisplayFormat.FormatString = "G";
        }

        private void btnEXCEL_Click(object sender, EventArgs e)
        {
            string carpeta = string.Empty;
            carpeta = System.IO.Path.GetTempPath();

            gridView1.ExportToXlsx(carpeta + "\\sad.xlsx");
            Process pdfexport = new Process();
            pdfexport.StartInfo.FileName = "EXCEL.exe";
            pdfexport.StartInfo.Arguments = carpeta + "\\sad.xlsx";
            pdfexport.Start();
        }
    }
}
