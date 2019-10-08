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
        string conString,usuario,perfil;
        Token token;
        public Principal(string  conexion,string usuario,string perfil)
        {
            conString = conexion;
            this.usuario = usuario;
            this.perfil = perfil;
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
                   case "btnCreaPedido": 
                        panelControl1.Controls.Clear();
                        Views.Ventas.SaleOrderSentVista sosv = new Views.Ventas.SaleOrderSentVista(token);
                        sosv.Parent = panelControl1;
                        sosv.Dock = DockStyle.Fill;
                        panelControl1.Controls.Add(sosv);
                        sosv.BringToFront();
                        break;
                    case "btnEmbarqueMasivo":   case "btnApoyosEmbarcar":
                        panelControl1.Controls.Clear();
                        Views.Logistica.Distribucion.embarqueMasivo em = new Views.Logistica.Distribucion.embarqueMasivo(usuario);
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
                    case "tileFacturar1":
                        panelControl1.Controls.Clear();
                        Views.Logistica.Empaque.empaquePantalla ep = new Views.Logistica.Empaque.empaquePantalla
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        panelControl1.Controls.Add(ep);
                        ep.BringToFront();
                        break;
                    case "btnPostVentaDesembarcar":case "btnLogisticaDesembarcar":case "btnApoyosDesembarcar":
                        panelControl1.Controls.Clear();
                        Views.Logistica.Distribucion.desembarque des = new Views.Logistica.Distribucion.desembarque(perfil, usuario)
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        panelControl1.Controls.Add(des);
                        des.BringToFront();
                        break;
                    case "btnConfirmarDistribucion": case "btnConfirmarApoyos": case "btnConfirmarPostVenta":
                            panelControl1.Controls.Clear();
                        Views.PostVenta.Confirmacion c = new Views.PostVenta.Confirmacion(perfil, usuario)
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        c.BringToFront();
                        break;
                    case "btnReporteExitencis": //BORARR  SOLO FUE PARA UNA PRESENTACION
                        panelControl1.Controls.Clear();
                        Views.Ventas.Reportes.reporteExistencias c2 = new Views.Ventas.Reportes.reporteExistencias()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        c2.BringToFront();
                        break;
                    case "btnreportevtas":
                        panelControl1.Controls.Clear();
                        Views.Ventas.Reportes.ventasCte c3 = new Views.Ventas.Reportes.ventasCte()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        c3.BringToFront();
                        break;
                    case "btnRastrearArt":
                        panelControl1.Controls.Clear();
                        Views.Ventas.Reportes.rastrearART c4 = new Views.Ventas.Reportes.rastrearART()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        c4.BringToFront(); //btnApoyosEmbarques
                        break;
                    case "btnApoyosEmbarques":
                        panelControl1.Controls.Clear();
                        Views.Logistica.Distribucion.reporteEmbarques re = new Views.Logistica.Distribucion.reporteEmbarques()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        re.BringToFront();
                        break;

                    case "btnReportesexisalamacen": ///borrar pruebas anyelo
                        panelControl1.Controls.Clear();
                        Views.Ventas.Reportes.reporteExistenciasAlmacen rea = new Views.Ventas.Reportes.reporteExistenciasAlmacen()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill

                        };
                        rea.BringToFront();
                        break;

                    //btnReportesexisalamacen
                    case "btnReportesInfo": ///borrar pruebas anyelo
                        panelControl1.Controls.Clear();
                        Views.Ventas.Reportes.infoCTe ic= new Views.Ventas.Reportes.infoCTe()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill

                        };
                        ic.BringToFront();
                        break;

                    case "btnEntregaPedido": ///borrar pruebas anyelo
                        panelControl1.Controls.Clear();
                        Views.ClienteRecoge.entregaPedido epCTE = new Views.ClienteRecoge.entregaPedido(usuario,perfil,SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString)
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill

                        };
                        epCTE.BringToFront();
                        break;
                    case "btnAlmacenCteRecoge": ///borrar pruebas anyelo
                        panelControl1.Controls.Clear();
                        Views.ClienteRecoge.almacenCteRecoge acr = new Views.ClienteRecoge.almacenCteRecoge(usuario, perfil, "1");
                        acr.Show();
                        
                        break;


                }


            }
        }
    }
}