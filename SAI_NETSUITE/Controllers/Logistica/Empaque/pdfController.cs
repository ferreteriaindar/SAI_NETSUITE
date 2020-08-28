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
using DevExpress.XtraPrinting;

namespace SAI_NETSUITE.Controllers.Logistica.Empaque
{
    class pdfController
    {

        public void imprimePDFyPacking(string id, string tipo)
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
                       // printTool.ShowRibbonPreviewDialog();
                        printTool.Print();

              
                    }
                }
            };
            // ImprimeFacturaPdf(id);

        }



        public void imprimePDFyPackingCons(string cons, string tipo)
        {

            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                string query = @"exec iws.[dbo].[sp_ResumenEmpaqueWMSCons] " + cons + "," + tipo;
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                DataSet ds = new DataSet();
                da.Fill(ds);
              //  ds.WriteXmlSchema(@"S:\XML\Almacen\Distribucion\ResumenEmpaque.xml");

                if (tipo.Equals("1"))
                {
                    Views.Logistica.Empaque.ListaEmpaquePedidoCliente lpc = new Views.Logistica.Empaque.ListaEmpaquePedidoCliente();

                    lpc.DataSource = ds;


                    using (ReportPrintTool printTool = new ReportPrintTool(lpc))
                    {
                        // Invoke the Ribbon Print Preview form modally, 
                        // and load the report document into it.
                        printTool.Print();

                        // Invoke the Ribbon Print Preview form
                        // with the specified look and feel setting.
                        //printTool.ShowRibbonPreview(UserLookAndFeel.Default);
                

                    }
                }
                else
                {
                    Views.Logistica.Empaque.ResumenEmpaqueCliente lpc = new Views.Logistica.Empaque.ResumenEmpaqueCliente();

                    lpc.DataSource = ds;


                    using (ReportPrintTool printTool = new ReportPrintTool(lpc))
                    {
                        printTool.Print();
                     /*
                        printTool.ShowRibbonPreviewDialog();

                        
                        printTool.ShowRibbonPreview(UserLookAndFeel.Default);
                      */
                    }
                }
            };
            // ImprimeFacturaPdf(id);

        }

        public void ImprimeFacturaPdf(string factura)

        {
            var settings = new PdfPrinterSettings();
            settings.Settings.Copies = 2;
            FileStream stream = new FileStream(@"\\192.168.86.5\pdfcfdi\" + factura + @".pdf", FileMode.Open);
            var pdfViewer2 = new DevExpress.XtraPdfViewer.PdfViewer();
            pdfViewer2.LoadDocument(stream);
            pdfViewer2.Print(settings);

        }


        public void imprimePDFyPackingV2(string id, string tipo)
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
                        printTool.Print();


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
                        //printTool.ShowRibbonPreviewDialog();
                       
                        printTool.Print();


                    }
                }
            };
            // ImprimeFacturaPdf(id);

        }


        public void imprimePDFyPackingConsV2(string cons, string tipo)
        {

            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                string query = @"exec iws.[dbo].[sp_ResumenEmpaqueWMSCons] " + cons + "," + tipo;
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
                        printTool.Print();


                    }
                }
                else
                {
                    Views.Logistica.Empaque.ResumenEmpaqueCliente lpc = new Views.Logistica.Empaque.ResumenEmpaqueCliente();

                    lpc.DataSource = ds;


                    using (ReportPrintTool printTool = new ReportPrintTool(lpc))
                    {
                        printTool.Print();
                        /*
                           printTool.ShowRibbonPreviewDialog();


                           printTool.ShowRibbonPreview(UserLookAndFeel.Default);
                         */
                    }
                }
            };
            // ImprimeFacturaPdf(id);

        }

        public void imprimePDFyPackingCotizacion(string cotizacion, string tipo)
        {
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                string query = @"exec iws.[dbo].[sp_ResumenEmpaqueWMSCotizacion] " + cotizacion + "," + tipo;
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                //  ds.WriteXmlSchema(@"S:\XML\Almacen\Distribucion\ResumenEmpaque.xml");

                if (tipo.Equals("1"))
                {
                    Views.Logistica.Empaque.ListaEmpaquePedidoCliente lpc = new Views.Logistica.Empaque.ListaEmpaquePedidoCliente();

                    lpc.DataSource = ds;


                    using (ReportPrintTool printTool = new ReportPrintTool(lpc))
                    {
                        
                       
                        printTool.Print();

                        
                       // printTool.ShowRibbonPreview(UserLookAndFeel.Default);


                    }
                }
                else
                {
                    Views.Logistica.Empaque.ResumenEmpaqueCliente lpc = new Views.Logistica.Empaque.ResumenEmpaqueCliente();
                    
                  
                         lpc.DataSource = ds;


                    using (ReportPrintTool printTool = new ReportPrintTool(lpc))
                    {

                        
                        printTool.Print();
                        
                    }
                }
            };
            // ImprimeFacturaPdf(id);
        }
    }
}