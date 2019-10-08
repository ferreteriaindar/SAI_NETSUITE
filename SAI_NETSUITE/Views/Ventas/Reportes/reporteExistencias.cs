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

namespace SAI_NETSUITE.Views.Ventas.Reportes
{
    public partial class reporteExistencias : UserControl
    {
        public reporteExistencias()
        {
            InitializeComponent();
        }

        private void BTNCARGAR_Click(object sender, EventArgs e)
        {
            cargainfo();
        }


        public void cargainfo()
        {
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                string query = "exec Indarneg.dbo.sp_reporteExistencias 'U1 1212'";
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gridControl1.DataSource = ds.Tables[0];
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string carpeta = string.Empty;
            carpeta = System.IO.Path.GetTempPath();

            gridControl1.ExportToXlsx(carpeta + "\\articulo.xlsx");
            Process pdfexport = new Process();
            pdfexport.StartInfo.FileName = "EXCEL.exe";
            pdfexport.StartInfo.Arguments = carpeta + "\\articulo.xlsx";
            pdfexport.Start();
        }
    }
}
