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

namespace SAI_NETSUITE.Views.CXC.Reportes
{
    public partial class FacturasEmbarcadas : UserControl
    {
        public FacturasEmbarcadas()
        {
            InitializeComponent();
        }

        private void FacturasEmbarcadas_Load(object sender, EventArgs e)
        {

        }


        public void cargaDatos()
        {
            DataSet ds = new DataSet();
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                string query = @"select ED.factura,I.AmountDue,SubString(ED.fechaHora,1,10) as FechaHora,EN.NAME as Cobrador,EN.ENTITY_ID AS IDCOBRADOR,EN2.NAME AS VENDEDOR,EN2.ENTITY_ID AS IDVENDEDOR,E.idEmbarque,ED.estado,ZI.NSO___ZONAS_CLIENTES_NAME as Zona,C.company from indarneg.dbo.EmbarquesD ED
                            INNER JOIN  IWS.DBO.Invoices I ON ED.factura=I.TranId
                            INNER JOIN  IWS.DBO.Customers C ON I.Entity=c.internalid
                            INNER JOIN  IWS.DBO.ZonasIndar ZI ON C.customerZone=ZI.NSO___ZONAS_CLIENTES_ID
                            INNER JOIN  IWS.DBO.Entity  EN ON ZI.AGENTE_COBRADOR_ID=EN.ENTITY_ID
							INNER JOIN  IWS.DBO.Entity EN2 ON ZI.REPRESENTANTE_VENTAS_ID=EN2.ENTITY_ID
                            INNER JOIN  Indarneg.dbo.Embarques E ON  ED.idEmbarque=E.idEmbarque
							INNER JOIN  Indarneg.dbo.sai_usuario SU on e.usuario=su.usuario
                             where (ISNULL(SU.sucursal,''))  not like ('Of%') AND
                            estado='ENTREGADO' AND  SubString(fechaHora,1,10) ='" + dateEdit1.Text+"'";
                Console.WriteLine(query);
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                da.Fill(ds);
                gridControl1.DataSource = ds.Tables[0];

            }

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            cargaDatos();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string carpeta = string.Empty;
            carpeta = System.IO.Path.GetTempPath();

            gridView1.ExportToXlsx(carpeta + "\\facturas.xlsx");
            Process pdfexport = new Process();
            pdfexport.StartInfo.FileName = "EXCEL.exe";
            pdfexport.StartInfo.Arguments = carpeta + "\\facturas.xlsx";
            pdfexport.Start();
        }
    }
}
