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

namespace SAI_NETSUITE.Views.Logistica.Distribucion
{
    public partial class reporteEmbarques : UserControl
    {
        public reporteEmbarques()
        {
            InitializeComponent();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }


        public void cargaInfo()
        {
            string query = @"  select e.idEmbarque,e.fecha,e.fechaConcluido,p.LIST_ITEM_NAME,e.comentarios,e.estatus,e.usuario,ENT.NAME as CHOFER,ed.factura,ed.estado,ed.persona,ed.fechaHora,ed.comentarios as comentariosFactura,ed.usuarioConfirma,ed.FechaConfirmaPostventa from Indarneg.dbo.Embarques E
                            left join Indarneg.dbo.EmbarquesD ED ON E.idEmbarque = ED.idEmbarque
                            Left join iws.dbo.Entity ENT on E.entity_id = ENT.ENTITY_ID
                            left join iws.dbo.Paqueteria P on e.idPaqueteria = p.LIST_ID
                            where factura is not null   and E.FECHA > DATEADD(month, -3, GETDATE())";
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gridControl1.DataSource = ds.Tables[0];

            }

        }

        private void reporteEmbarques_Load(object sender, EventArgs e)
        {
          
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            cargaInfo();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            string carpeta = string.Empty;
            carpeta = System.IO.Path.GetTempPath();

            gridControl1.ExportToXlsx(carpeta + "\\embarques.xlsx");
            Process pdfexport = new Process();
            pdfexport.StartInfo.FileName = "EXCEL.exe";
            pdfexport.StartInfo.Arguments = carpeta + "\\embarques.xlsx";
            pdfexport.Start();
        }
    }
}
