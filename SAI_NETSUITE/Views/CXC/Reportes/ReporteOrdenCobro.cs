using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;

namespace SAI_NETSUITE.Views.CXC.Reportes
{
    public partial class ReporteOrdenCobro : UserControl
    {
        public ReporteOrdenCobro()
        {
            InitializeComponent();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string carpeta = string.Empty;
            carpeta = System.IO.Path.GetTempPath();

            gridView1.ExportToXlsx(carpeta + "\\ordenCobro.xlsx");
            Process pdfexport = new Process();
            pdfexport.StartInfo.FileName = "EXCEL.exe";
            pdfexport.StartInfo.Arguments = carpeta + "\\ordenCobro.xlsx";
            pdfexport.Start();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            cargaDatos();
        }


        public void cargaDatos()
        {
            DataSet ds = new DataSet();
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                string query = @"select OC.idOrdenCobro,E.NAME,OC.FECHA,OC.usuario,OC.comentarios,OCD.factura,OCD.comentarios AS NotasFac,I.DescuentoTotalPP,I.AmountDue from Indarneg.dbo.OrdenCobro OC
                                INNER JOIN Indarneg.dbo.OrdenCobroD OCD ON OC.idOrdenCobro=OCD.idOrdenCobro
                                INNER JOIN IWS.DBO.Entity E ON OC.entity_id=E.ENTITY_ID
                                INNER JOIN IWS.DBO.Invoices I ON OCD.facturaid=I.internalId
                                INNER JOIN IWS.DBO.CondicionesPago CP ON I.CondicionVencimiento=CP.TIPO_DE_ENTIDAD_ID";
                Console.WriteLine(query);
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                da.Fill(ds);
                gridControl1.DataSource = ds.Tables[0];

            }

        }
    }
}
