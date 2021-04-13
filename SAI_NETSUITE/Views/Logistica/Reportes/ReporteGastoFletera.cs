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

namespace SAI_NETSUITE.Views.Logistica.Reportes
{
    public partial class ReporteGastoFletera : UserControl
    {
        public ReporteGastoFletera()
        {
            InitializeComponent();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            cargaDatos();
        }

        public void cargaDatos()
        {
            using (IndarnegEntities ctx = new IndarnegEntities())
            {
                var resultado = from G in ctx.GastoFletera
                                join GD in ctx.GastoFleteraD on G.idGastoFletera equals GD.idGastoFletera
                                select new
                                {
                                    G.NumDoc,
                                    G.Vendor,
                                    G.numFactura,
                                    G.importeFactura,
                                    G.checkRetencion,
                                    G.uuid,
                                    G.usuario,
                                    G.comentario,
                                    G.autorizado,
                                    G.autorizadoUsuario,
                                    GD.NumGuia,
                                    GD.importeGuia,
                                    GD.facturas,
                                    ComentarioGuia=GD.comentario

                                };
                gridControl1.DataSource = resultado.ToList();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

            string carpeta = string.Empty;
            carpeta = System.IO.Path.GetTempPath();

            gridControl1.ExportToXlsx(carpeta + "\\GastoFleteras.xlsx");
            Process pdfexport = new Process();
            pdfexport.StartInfo.FileName = "EXCEL.exe";
            pdfexport.StartInfo.Arguments = carpeta + "\\GastoFleteras.xlsx";
            pdfexport.Start();
        }
    }
}
