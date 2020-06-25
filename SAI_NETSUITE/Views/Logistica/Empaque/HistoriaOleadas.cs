using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAI_NETSUITE.Views.Logistica.Empaque
{
    public partial class HistoriaOleadas : Form
    {
        public HistoriaOleadas()
        {
            InitializeComponent();
        }

        private void HistoriaOleadas_Load(object sender, EventArgs e)
        {
            cargaDatos();
        }

        public void cargaDatos()
        {
            DateTime currenteDate = DateTime.UtcNow.Date.AddDays(-2);
            using (IWSEntities ctx = new IWSEntities())
            {
                var dato = ctx.OleadaFacturacion.Where(x => x.fecha >= currenteDate);
                gridControl1.DataSource = dato.ToList();
            }
        }
    }
}
