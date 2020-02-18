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

namespace SAI_NETSUITE.Views.PostVenta
{
    public partial class RegresarEventos : UserControl
    {
        public RegresarEventos()
        {
            InitializeComponent();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCargaIngo_Click(object sender, EventArgs e)
        {
            Controllers.PostVenta.RegresarEventosController rec = new Controllers.PostVenta.RegresarEventosController();
            if(!toggleSwitch1.IsOn)
            gridControl1.DataSource = rec.cargaDatos().result.Where(i => i.almacen.Equals("150-Mercancía en eventos"));
            else gridControl1.DataSource = rec.cargaDatos().result.Where(i=>i.almacen.Equals("151-Promos y regalos mercadotec"));
        }

        private void btnEnviarSeleccion_Click(object sender, EventArgs e)
        {

            if (gridView1.SelectedRowsCount > 0)
            {
                List<DocumentosInventoryEventsToList> lista = new List<DocumentosInventoryEventsToList>();

                for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                {
                    DocumentosInventoryEventsToList det = new DocumentosInventoryEventsToList()
                    {
                        nombre = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], "nombre").ToString(),
                        disponible = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], "disponible").ToString()
                    };
                    lista.Add(det);
                }
                Controllers.PostVenta.RegresarEventosController rec = new Controllers.PostVenta.RegresarEventosController();
                rec.InsertIREvento(lista,toggleSwitch1.IsOn);
            }
            else MessageBox.Show("Selecciona al menos 1 renglon");
        }

        
    }
}
