using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;

using System.IO;
using DevExpress.Pdf;

namespace SAI_NETSUITE.Controllers.Logistica.Empaque
{
    class pdfController
    {

        public void imprimePDFyPacking(string id,string tipo)
        {
            
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                string query = @"exec iws.[dbo].[sp_ResumenEmpaqueWMS] " + id + "," + tipo;
                    SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                //ds.WriteXmlSchema(@"S:\XML\Almacen\Distribucion\ResumenEmpaque.xml");

                if (tipo.Equals("1"))
                {
                    Views.Logistica.Empaque.ListaEmpaquePedidoCliente lpc = new Views.Logistica.Empaque.ListaEmpaquePedidoCliente();

                    lpc.DataSource = ds;


                    using (ReportPrintTool printTool = new ReportPrintTool(lpc))
                    {
                        // Invoke the Ribbon Print Preview form modally, 
                        // and load the report document into it.
                        printTool.ShowRibbonPreviewDialog();

                        // Invoke the Ribbon Print Preview form
                        // with the specified look and feel setting.
                        printTool.ShowRibbonPreview(UserLookAndFeel.Default);
                        //printTool.Print(); System.Windows.Forms.MessageBox.Show("Impreso");
                        
                    }
                }
                else
                {
                    Views.Logistica.Empaque.ResumenEmpaqueCliente lpc = new Views.Logistica.Empaque.ResumenEmpaqueCliente();

                    lpc.DataSource = ds;


                    using (ReportPrintTool printTool = new ReportPrintTool(lpc))
                    {
                        // Invoke the Ribbon Print Preview form modally, 
                        // and load the report document into it.
                        printTool.ShowRibbonPreviewDialog();

                        // Invoke the Ribbon Print Preview form
                        // with the specified look and feel setting.
                        printTool.ShowRibbonPreview(UserLookAndFeel.Default);
                        //printTool.Print(); System.Windows.Forms.MessageBox.Show("Impreso");
                    }
                }
            };
           // ImprimeFacturaPdf(id);

        }


        public void ImprimeFacturaPdf(string factura)

        {
            var settings = new PdfPrinterSettings();
            settings.Settings.Copies = 2;
            FileStream stream = new FileStream(@"\\192.168.86.5\pdfcfdi\"+factura+@".pdf", FileMode.Open);
            var pdfViewer2 = new  DevExpress.XtraPdfViewer.PdfViewer();
            pdfViewer2.LoadDocument(stream);
            pdfViewer2.Print(settings);

        }
    }
}
