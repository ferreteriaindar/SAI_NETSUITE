using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using DevExpress.DashboardCommon;
using DevExpress.DashboardWin;


namespace SAI_NETSUITE.WMS.Reportes
{
    public partial class ReporteSurtidoPicking : UserControl
    {
        public ReporteSurtidoPicking()
        {
            InitializeComponent();
        }

        private void ReporteSurtidoPicking_Load(object sender, EventArgs e)
        {
          //  cargaDASH();
           // cargaInfoXML();
            cargaDASH();
           
        }

        public void cargaDASH()
        {

            dashboardViewer1.DashboardSource = null;
            dashboardViewer1.DashboardSource = @"S:\XML\Almacen\WMSreportePisosPicking_UAT3.xml";
        
        }

        public void cargaInfoXML()
        { 
          XmlDocument xd = new XmlDocument();
            xd.Load(@"S:\XML\Almacen\WMSreportePisosPicking.xml");

          
            foreach (XElement level1Element in XElement.Load(@"S:\XML\Almacen\WMSreportePisosPicking.xml").Elements("Parameters"))
            {
              //  result.AppendLine(level1Element.Attribute("name").Value);
                foreach (XElement level2Element in level1Element.Elements("Parameter"))
                {
                    Console.WriteLine("si"+level2Element.Attribute("Name").Value);
                    //result.AppendLine("  " + level2Element.Attribute("Name").Value);
                    switch (level2Element.Attribute("Name").Value)
                    {
                        case "tJaula": txtJaula.Text = level2Element.Attribute("Value").Value;
                            break;
                        case "tPick1": txtPick1.Text = level2Element.Attribute("Value").Value;
                            break;
                        case "Tpick2": txtPick2.Text = level2Element.Attribute("Value").Value;
                            break;
                        case "tPick3": txtPick3.Text = level2Element.Attribute("Value").Value;
                            break;
                        case "tPick4": txtPick4.Text = level2Element.Attribute("Value").Value;
                            break;
                        case "tPick5": txtPick5.Text = level2Element.Attribute("Value").Value;
                            break;
                        case "tSINAREA": txtSAREA.Text = level2Element.Attribute("Value").Value;
                            break;
                        case "tSobreP": txtPedido.Text = level2Element.Attribute("Value").Value;
                            break;
                        case "tVol": txtVOL.Text = level2Element.Attribute("Value").Value;
                            break;
                        case "tBulk": txtBulk.Text = level2Element.Attribute("Value").Value;
                           
                            break;
                        case "tInflamable": txtInflamable.Text = level2Element.Attribute("Value").Value;
                            break;
                    }
                   
                }
            }
       
           
        
        }

        public void cargaInfoDASH()
        { 
                  Dashboard dashboard = new Dashboard();
            dashboard.LoadFromXml(@"S:\XML\Almacen\WMSreportePisosPicking_UAT3.xml");

            if (dashboard.UserData != null)
            {
                // Obtains used data from the dashboard XML definition.
                XElement xml = dashboard.UserData;

                // Saves values from the XML element to the list.
                IList<XElement> parsInfo = xml.Elements().ToList();
                IList<object> values = new List<object>();
                foreach (XElement parInfo in parsInfo)
                {
                    // Converts parameter values with the 'DateTime' type to date-time values.
                    if (parInfo.Element("Type").Value == "DateTime")
                    {
                        values.Add(DateTime.Parse(parInfo.Element("Value").Value));
                    }
                    else
                    {
                        values.Add(parInfo.Element("Value").Value);
                    }
                }

                DashboardParameters parameters1 = dashboardViewer1.Parameters;

                // Sets obtained user values as current parameters' values.
                dashboardViewer1.BeginUpdateParameters();
                for (int i = 0; i < parameters1.Count; i++)
                {
                    parameters1[i].Value = values[i];
                }
                dashboardViewer1.EndUpdateParameters();
            }
        
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {


            
          
            Dashboard dashboard = new Dashboard();
            dashboard.LoadFromXml(@"S:\XML\Almacen\WMSreportePisosPicking_UAT3.xml");

            // Obtains dashboard parameter settings and metadata for a currently open dashboard.
            IList<DashboardParameterDescriptor> parameters = dashboardViewer1.Parameters;

            // Saves parameter settings and current values to an XML element.
            XElement xml = new XElement("ParametersInfo",
                        from parameter in parameters
                        select new XElement("ParameterInfo",
                                    new XElement("Name", parameter.Name),
                                    new XElement("Value",parameter.Values),
                                    new XElement("Type", parameter.Type)));

            // Adds the created XML element to the dashboard XML definition and saves the dashboard.
            dashboard.UserData = xml;
            dashboard.SaveToXml(@"S:\XML\Almacen\WMSreportePisosPicking_UAT3.xml");

            //cargaDASH();
            //XmlDocument doc = new XmlDocument();
            //string path = @"S:\XML\Almacen\WMSreportePisosPicking.xml";
            //doc.Load(path);
            //doc.SelectSingleNode("/Parameters/Parameter").Attributes["value"].Value = "hello";
            //doc.Save(path);
            //XElement xd = new XElement(@"S:\XML\Almacen\WMSreportePisosPicking.xml");

            //foreach (XElement level1Element in xd.Elements("Parameters"))
            //     //XElement.Load(@"S:\XML\Almacen\WMSreportePisosPicking.xml").Elements("Parameters"))
            //{
            //    //  result.AppendLine(level1Element.Attribute("name").Value);
            //    foreach (XElement level2Element in level1Element.Elements("Parameter"))
            //    {
            //        //result.AppendLine("  " + level2Element.Attribute("Name").Value);
            //        switch (level2Element.Attribute("Name").Value)
            //        {
            //            case "tJaula":  level2Element.Attribute("Value").Value=txtJaula.Text ;
            //                break;
            //            case "tPick1":  level2Element.Attribute("Value").Value=txtPick1.Text ;
            //                break;
            //            case "Tpick2":  level2Element.Attribute("Value").Value=txtPick2.Text ;
            //                break;
            //            case "tPick3":  level2Element.Attribute("Value").Value=txtPick3.Text ;
            //                break;
            //            case "tPick4":  level2Element.Attribute("Value").Value=txtPick4.Text ;
            //                break;
            //            case "tPick5":  level2Element.Attribute("Value").Value=txtPick5.Text ;
            //                break;
            //            case "tSINAREA":  level2Element.Attribute("Value").Value =txtSAREA.Text ;
            //                break;
            //            case "tSobreP":  level2Element.Attribute("Value").Value=txtPedido.Text ;
            //                break;
            //            case "tVol":  level2Element.Attribute("Value").Value=txtVOL.Text ;
            //                break;
            //            case "tBulk":  level2Element.Attribute("Value").Value=txtBulk.Text ;

            //                break;
            //            case "tInflamable":  level2Element.Attribute("Value").Value= txtInflamable.Text ;
            //                break;
            //        }
            //    }
            //    level1Element.Save(@"S:\XML\Almacen\WMSreportePisosPicking.xml");

            //}
            //xd.RemoveAll();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //cargaInfoDASH();
            dashboardViewer1.ReloadData();
            
        }
        private void dashboardViewer1_DashboardItemControlCreated(object sender, DashboardItemControlEventArgs e)
        {
            if (e.PivotGridControl != null)
                e.PivotGridControl.BestFit();
        }
        private void dashboardViewer1_DashboardItemControlUpdated(object sender, DashboardItemControlEventArgs e)
        {
            if (e.PivotGridControl != null)
                e.PivotGridControl.BestFit();
        }

        private void ReporteSurtidoPicking_DoubleClick(object sender, EventArgs e)
        {
           
        }
    }
    }
