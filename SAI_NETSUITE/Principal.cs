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
using SAI_NETSUITE.IWS;

namespace SAI_NETSUITE
{
    public partial class Principal : DevExpress.XtraEditors.XtraForm
    {
        string conString;
        Token token;
        public Principal(string  conexion)
        {
            conString = conexion;
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            token = new Token();
             token.token   = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJyb2xlIjoiQWRtaW4iLCJ1bmlxdWVfbmFtZSI6IndpbnNlcnZpY2V3bXMiLCJuYmYiOjE1NjQ0MjE1MTcsImV4cCI6MTg4MDA0MDcxNywiaWF0IjoxNTY0NDIxNTE3fQ.f06XZK3H0nFUS5heHKuX_aez8NBzMA7H5zrHjtjYzRs";
        }

        private void tileNavPane1_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            if (e.IsTile)
            {
                switch (e.Element.Name.ToString())
                { 
                    case "tileNavWMS":
                        WMS.menuWMS wms = new WMS.menuWMS(conString,"admin","admin");
                        wms.Show();
                        break;
                    case "tileNavVentas": //
                        panelControl1.Controls.Clear();
                        Views.Ventas.SaleOrderSentVista sosv = new Views.Ventas.SaleOrderSentVista(token);
                        sosv.Parent = panelControl1;
                        sosv.Dock = DockStyle.Fill;
                        panelControl1.Controls.Add(sosv);
                        sosv.BringToFront();
                        break;
                    case "btnEmbarqueMasivo":
                        panelControl1.Controls.Clear();
                        Views.Logistica.Distribucion.embarqueMasivo em = new Views.Logistica.Distribucion.embarqueMasivo();
                        em.Parent = panelControl1;
                        em.Dock = DockStyle.Fill;
                        panelControl1.Controls.Add(em);
                        em.BringToFront();
                        break;
                    case "btnNumeroGuia":
                        panelControl1.Controls.Clear();
                        //  Views.Logistica.Distribucion.NumerodGuia2cs ng2 = new Views.Logistica.Distribucion.NumerodGuia2cs(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString, "");
                        Views.Logistica.Distribucion.numeroGuiaView ng2 = new Views.Logistica.Distribucion.numeroGuiaView();
                        ng2.Parent = panelControl1;
                        ng2.Dock = DockStyle.Fill;
                        panelControl1.Controls.Add(ng2);
                        ng2.BringToFront();
                        break;
                    case "btnGenerarIR":
                        panelControl1.Controls.Clear();
                        Views.Compras.Entradas.IR iR = new Views.Compras.Entradas.IR
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        panelControl1.Controls.Add(iR);
                        iR.BringToFront();
                        break;






                }


            }
        }
    }
}