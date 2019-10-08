using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Data.SqlClient;

namespace SAI_NETSUITE.Views.Logistica.Empaque
{
    public partial class PDFEmpaque : DevExpress.XtraEditors.XtraForm
    {
        public PDFEmpaque()
        {
            InitializeComponent();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PDFEmpaque_Load(object sender, EventArgs e)
        {
            cargaDatos();
        }

        public void cargaDatos()
        {
            string[] filePaths = Directory.GetFiles(@"\\192.168.86.5\pdfcfdi\", "*.pdf");
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                string query = @"select i.TranId,so.tranid as pedido,e.NAME,FE.LIST_ITEM_NAME from iws.dbo.Invoices  I 
                                left join iws.dbo.SaleOrders  SO on i.createdfrom=so.id
                                left join  iws.dbo.Entity E on i.Entity=e.ENTITY_ID
                                LEFT JOIN iws.dbo.FormaEnvio  FE ON I.ShippingWay=FE.LIST_ID
                                where i.TranId in ({0})";
                SqlCommand cmd = new SqlCommand("", myConnection);
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                var idParameterList = new List<string>();
                var index = 0;
                foreach (var id in filePaths)
                {
                    var paramName = "@idParam" + index;
                    Console.WriteLine(Path.GetFileNameWithoutExtension(id).ToString());
                     da.SelectCommand.Parameters.AddWithValue(paramName, Path.GetFileNameWithoutExtension(id).ToString());
                    idParameterList.Add(paramName);
                    index++;
                }
                cmd.CommandText = String.Format(query, string.Join(",", idParameterList));

                DataSet ds = new DataSet();
                da.SelectCommand.CommandText = cmd.CommandText;

                da.Fill(ds);
                gridControl1.DataSource = ds.Tables[0];
            };
         

        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Controllers.Logistica.Empaque.pdfController pc = new Controllers.Logistica.Empaque.pdfController();
            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                string factura = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colTranId).ToString();
                string tipo = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colLIST_ITEM_NAME).ToString().Contains("LOCAL") ? "2" :"1";
                pc.imprimePDFyPacking(factura, tipo);
             
            }

        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {

        }
    }
}