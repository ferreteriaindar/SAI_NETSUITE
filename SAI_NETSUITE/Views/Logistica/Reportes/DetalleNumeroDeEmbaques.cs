using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAI_NETSUITE.Views.Logistica.Reportes
{
    public partial class DetalleNumeroDeEmbaques : Form
    {
        string factura;
        public DetalleNumeroDeEmbaques(string factura)
        {
            this.factura = factura;
            InitializeComponent();
        }

        private void DetalleNumeroDeEmbaques_Load(object sender, EventArgs e)
        {
            using (IndarnegEntities ctx = new IndarnegEntities())
            {
                var info = (from E in ctx.Embarques
                            join ED in ctx.EmbarquesD on E.idEmbarque equals ED.idEmbarque
                            
                            where ED.factura == factura
                            select new { E.idEmbarque,E.fecha,E.estatus,E.comentarios,E.usuario, ED.factura,ED.estado,ED.fechaHora,ED.FechaFleteXConfirmar,ED.fechaConfirmaPostventa }).ToList();
                gridControl1.DataSource = info.ToList();
            }
        }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            string carpeta = string.Empty;
            carpeta = System.IO.Path.GetTempPath();

            gridControl1.ExportToXlsx(carpeta + "\\DetalleDeNumEmbarques" + DateTime.Now.ToShortDateString() + ".xlsx");
            Process pdfexport = new Process();
            pdfexport.StartInfo.FileName = "EXCEL.exe";
            pdfexport.StartInfo.Arguments = carpeta + "\\DetalleDeNumEmbarques" + DateTime.Now.ToShortDateString() + ".xlsx";
            pdfexport.Start();
        }
    }
}
