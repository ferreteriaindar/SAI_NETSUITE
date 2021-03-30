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
using SAI_NETSUITE.Controllers.Logistica.Reportes;
using SAI_NETSUITE.Models.Transaccion;
using System.Diagnostics;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace SAI_NETSUITE.Views.Logistica.Reportes
{
    public partial class FacturasXEmbarcar : UserControl
    {
        public FacturasXEmbarcar()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            /*  SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1);
              string fechaIni, fechaFin;
              fechaIni = dateIni.Text;
              fechaFin = dateFin.Text;
              string query = "exec  IndarWms.dbo.spFacturaEmbarqueResponsableDias '" + fechaIni + "','" + fechaFin + "'";

              SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
              da.SelectCommand.CommandTimeout = 120;
              DataSet ds = new DataSet();
              da.Fill(ds);
              e.Result = ds;*/
            string fechaIni, fechaFin;
            fechaIni = dateIni.Text;
            fechaFin = dateFin.Text;
            FacturasXEmbarcarController fxec = new FacturasXEmbarcarController();
            e.Result = fxec.regresaEmbarques(fechaIni,fechaFin);
        }

        private void FacturasXEmbarcar_Load(object sender, EventArgs e)
        {
            dateFin.Properties.Mask.UseMaskAsDisplayFormat = true;
            dateIni.Properties.Mask.UseMaskAsDisplayFormat = true;
            btnConsultar.ImageOptions.Image = null;
           // btnConsultar.ImageOptions.Image = SAI_NETSUITE.Properties.Resources.gear;
            //btnConsultar.StopAnimation();
            btnConsultar.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            btnConsultar.ImageOptions.Image = SAI_NETSUITE.Properties.Resources.gear;
            btnConsultar.StartAnimation();
            if(!backgroundWorker1.IsBusy)
            backgroundWorker1.RunWorkerAsync();
            else MessageBox.Show("Espera a que termine de cargar -_-!");

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<FacturasXEmbarcarModel> ds = (List<FacturasXEmbarcarModel>)e.Result;
            gridControl1.DataSource = ds;
            btnConsultar.StopAnimation();
        }

        private void btnParametros_Click(object sender, EventArgs e)
        {
            ParametrosFacturasXEmbarcar pfxe = new ParametrosFacturasXEmbarcar();
            pfxe.ShowDialog();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string carpeta = string.Empty;
            carpeta = System.IO.Path.GetTempPath();

            gridControl1.ExportToXlsx(carpeta + "\\FacturasXEmbarcar.xlsx");
            Process pdfexport = new Process();
            pdfexport.StartInfo.FileName = "EXCEL.exe";
            pdfexport.StartInfo.Arguments = carpeta + "\\FacturasXEmbarcar.xlsx";
            pdfexport.Start();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

           
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(gridView1.FocusedColumn.FieldName);

            if (gridView1.FocusedColumn.FieldName.Equals("totalEmbarques"))
            {
                if (!gridView1.GetFocusedRowCellValue(coltotalEmbarques).ToString().Equals(""))
                {
                    DetalleNumeroDeEmbaques dnde = new DetalleNumeroDeEmbaques(gridView1.GetFocusedRowCellValue(colFactura).ToString());
                    dnde.ShowDialog();
                }

            }
        }

        private void comboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(gridView1.ActiveFilterString);
            //[EstadoFactura] <> 'ENTREGADO'
            //Not [EstadoFactura] In ('C0', 'CANCELADO', 'ENTREGADO') And Not IsNullOrEmpty([EstadoFactura])
            //IsNullOrEmpty([EstadoFactura])
            switch (comboFiltro.Text)
            {
               

                case "Vivos": gridView1.ActiveFilterString = "Not [EstadoFactura] In ('C0', 'CANCELADO', 'ENTREGADO') And Not IsNullOrEmpty([EstadoFactura])";
                    break;
                case "Sin Embarque": gridView1.ActiveFilterString = "IsNullOrEmpty([EstadoFactura])";
                    break;
                case "FIN FILTRO":gridView1.ActiveFilterString = "";
                    break;
                case "MTY08 OFICINA MONTERREY": gridView1.ActiveFilterString = "[FormaEnvio] = 'MTY08 OFICINA MONTERREY'";
                    break;
                case "AGS01 OFICINA AGUASCALIENTES": gridView1.ActiveFilterString= "[FormaEnvio] = 'AGS01 OFICINA AGUASCALIENTES'";
                    break;
                case "BJX02 OFICINA LEON": gridView1.ActiveFilterString= "[FormaEnvio] = 'BJX02 OFICINA LEON'";
                    break;
                case "QRO03 OFICINA QRO": gridView1.ActiveFilterString = "[FormaEnvio] = 'QRO03 OFICINA QRO'";
                    break;
                case "CUL04 OFICINA CULIACAN": gridView1.ActiveFilterString= "[FormaEnvio] = 'CUL04 OFICINA CULIACAN'";
                    break;
                case "MLM05 OFICINA MORELIA": gridView1.ActiveFilterString= "[FormaEnvio] = 'MLM05 OFICINA MORELIA'";
                    break;
                case "TRC06 OFICINA TORREON":  gridView1.ActiveFilterString = "[FormaEnvio] = 'TRC06 OFICINA TORREON'";
                    break;
                case "GDL07 CLIENTE RECOGE":  gridView1.ActiveFilterString= "[FormaEnvio] = 'GDL07 CLIENTE RECOGE'";
                    break;
               
            }
        }
    }
}
