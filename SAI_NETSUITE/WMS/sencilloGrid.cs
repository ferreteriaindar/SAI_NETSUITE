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
using DevExpress.Utils;
namespace SAI_NETSUITE.WMS
{
    public partial class sencilloGrid : UserControl
    {
        string query, sqlString,info;

        public sencilloGrid(string sqlQuery,string sql,string infoExtra)
        {
            query = sqlQuery;
            sqlString = sql;
            info = infoExtra;
            InitializeComponent();
        }

        private void sencilloGrid_Load(object sender, EventArgs e)
        {
            cargaInfo();
            label1.Text = info;
            foreach(DevExpress.XtraGrid.Columns.GridColumn columna in gridView1.Columns)
            {
           
                if (columna.ColumnType.ToString().Equals("System.DateTime"))
                {
                    columna.DisplayFormat.FormatType = FormatType.DateTime;
                    columna.DisplayFormat.FormatString = "g";
                    Debug.WriteLine("FORMATO FECHA");
                }
               
            }
        }


        public void cargaInfo()
        {
            try
            {
                SqlConnection myConnection = new SqlConnection(sqlString);
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                DataSet ds = new DataSet();
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(ds);
                gridControl1.DataSource = ds.Tables[0];


                myConnection.Close();
                myConnection.Dispose();
                da.Dispose();
                revisaExtras();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        
        }
        public void revisaExtras()
        {
            foreach ( DevExpress.XtraGrid.Columns.GridColumn  c in gridView1.Columns)
            {
                Console.WriteLine(c.Name.ToString());
                if (c.Name.ToString().Equals("colFechaActualizado"))
                {
                    c.DisplayFormat.FormatString = "g";
                }
                            
            }
        
        
        }

        private void btnEXCEL_Click(object sender, EventArgs e)
        {
            string carpeta = string.Empty;
            carpeta = System.IO.Path.GetTempPath();

            gridControl1.ExportToXlsx(carpeta + "\\REPORTE.xlsx");
            Process pdfexport = new Process();
            pdfexport.StartInfo.FileName = "EXCEL.exe";
            pdfexport.StartInfo.Arguments = carpeta + "\\REPORTE.xlsx";
            pdfexport.Start();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

            if(label1.Text.Equals(@"Facturas wms/Intelisis"))
            {
                string pedido = gridView1.GetFocusedRowCellValue("FOLIO_IA").ToString();
                Reportes.detalleReporte dr = new Reportes.detalleReporte("exec Indarwms.dbo.spConsultaDetalle '" + pedido + "'",sqlString);
                dr.Show();


            }
           // gridView1.FocusedColumn.ToString(
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            
        }


    }
}
