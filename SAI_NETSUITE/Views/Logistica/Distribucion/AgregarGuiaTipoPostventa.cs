using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SAI_NETSUITE.Views.PostVenta;

namespace SAI_NETSUITE.Views.Logistica.Distribucion
{
    public partial class AgregarGuiaTipoPostventa : DevExpress.XtraEditors.XtraForm
    {
        string user;
        public string resultado;
        Views.PostVenta.RegistrodeGuias rg;
        public AgregarGuiaTipoPostventa(string  user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void AgregarGuiaTipoPostventa_Load(object sender, EventArgs e)
        {
            CargaPanel();
        }


        public void CargaPanel()
        {
            rg = new PostVenta.RegistrodeGuias(user,true)
            {
                Parent = panelControl1,
                Dock = DockStyle.Fill,
                Name = "rg"

            };
            rg.BringToFront();
          

        }

        private void AgregarGuiaTipoPostventa_FormClosing(object sender, FormClosingEventArgs e)
        {
            resultado = rg.TextBoxRegresa.Text;
        }   
    }
}