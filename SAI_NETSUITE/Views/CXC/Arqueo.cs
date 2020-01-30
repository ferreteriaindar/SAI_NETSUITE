using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAI_NETSUITE.Models.Transaccion;
using System.Diagnostics;

namespace SAI_NETSUITE.Views.CXC
{
    public partial class Arqueo : UserControl
    {
        public Arqueo()
        {
            InitializeComponent();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCargaArque_Click(object sender, EventArgs e)
        {
            Controllers.CXC.ArqueoController ac = new Controllers.CXC.ArqueoController();
            ArqueoModel am = ac.regresaPrimerosDatos(searchLookUpEdit1.EditValue.ToString());
          gridControl1.DataSource = am.result.Documentos.ToList();

            
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, "type").ToString().Contains("Invoice"))
                    gridView1.SetRowCellValue(i, "cobro", ac.regresaOrdenCobroId(gridView1.GetRowCellValue(i, "numero").ToString()));
                if(gridView1.GetRowCellValue(i, "numero").ToString().Contains("SI"))
                gridView1.SetRowCellValue(i, "cobro", ac.regresaOrdenCobroIntelisis(gridView1.GetRowCellValue(i, "numero").ToString()));
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string carpeta = string.Empty;
            carpeta = System.IO.Path.GetTempPath();

            gridControl1.ExportToXlsx(carpeta + "\\arqueo.xlsx");
            Process pdfexport = new Process();
            pdfexport.StartInfo.FileName = "EXCEL.exe";
            pdfexport.StartInfo.Arguments = carpeta + "\\arqueo.xlsx";
            pdfexport.Start();
        }

        private void Arqueo_Load(object sender, EventArgs e)
        {
            cargaZonas();
        }


        public void cargaZonas()
        {
            Controllers.CXC.ArqueoController ac = new Controllers.CXC.ArqueoController();
            searchLookUpEdit1.Properties.DisplayMember = "zona";
            searchLookUpEdit1.Properties.ValueMember = "id";
            searchLookUpEdit1.Properties.DataSource = ac.regresaZonas();
        }
    }
}
