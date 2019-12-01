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

namespace SAI_NETSUITE.Views.Compras.Reportes
{
    public partial class RepErikacs : UserControl
    {
        public RepErikacs()
        {
            InitializeComponent();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.SERVER87_5))
            {
                string query = @"SELECT * FROM OPENQUERY([NETSUITE],

                'SELECT I.FULL_NAME as Articulo,I.PURCHASEDESCRIPTION as Descripcion1,LFA.LIST_ITEM_NAME AS Fabricante,I.VENDORNAME as Proveedor
		                ,LCDA.LIST_ITEM_NAME AS Categoria,L.NAME as AlmDisp,ILM.AVAILABLE_COUNT as Disponible,L.NAME as AlmRes,NVL(ILM.ON_HAND_COUNT,0)-NVL(ILM.AVAILABLE_COUNT,0) as Reservado--,I.AVERAGECOST as CostoPromedio

					                FROM [Ferreteria indar SA de CV].[Administrator].ITEMS I 

                                INNER JOIN  [Ferreteria indar SA de CV].[Administrator].LISTA_CATEGORÍA_DE_ARTÍCULO LCDA ON I.CATEGORA_ID=LCDA.LIST_ID
				                INNER JOIN [Ferreteria indar SA de CV].[Administrator].LISTA_FABRICANTE_ARTÍCULO LFA ON I.FABRICANTE_ID=LFA.LIST_ID
				                INNER JOIN [Ferreteria indar SA de CV].[Administrator].ITEM_LOCATION_MAP ILM ON I.ITEM_ID = ILM.ITEM_ID
				                INNER JOIN [Ferreteria indar SA de CV].[Administrator].LOCATIONS L on ILM.LOCATION_ID=L.LOCATION_ID
				                WHERE (ILM.AVAILABLE_COUNT>0 or ILM.ON_HAND_COUNT>0)'
			
				                )";
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gridControl1.DataSource = ds.Tables[0];

            };
        }

        private void BTNexcel_Click(object sender, EventArgs e)
        {
            string carpeta = string.Empty;
            carpeta = System.IO.Path.GetTempPath();

            gridControl1.ExportToXlsx(carpeta + "\\OCPENDIENTE.xlsx");
            Process pdfexport = new Process();
            pdfexport.StartInfo.FileName = "EXCEL.exe";
            pdfexport.StartInfo.Arguments = carpeta + "\\OCPENDIENTE.xlsx";
            pdfexport.Start();
        }
    }
}
