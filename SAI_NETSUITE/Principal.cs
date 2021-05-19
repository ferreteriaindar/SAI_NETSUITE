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
        string conString, usuario, perfil,sucursal;
        Token token;
        public Principal(string  conexion,string usuario,string perfil,string sucursal)
        {
            conString = conexion;
            this.usuario = usuario;
            this.perfil = perfil;
            this.sucursal = sucursal;
            InitializeComponent();
        }

        private void tileNavPane1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            token = new Token();
             token.token   = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJyb2xlIjoiQWRtaW4iLCJ1bmlxdWVfbmFtZSI6IndpbnNlcnZpY2V3bXMiLCJuYmYiOjE1NjQ0MjE1MTcsImV4cCI6MTg4MDA0MDcxNywiaWF0IjoxNTY0NDIxNTE3fQ.f06XZK3H0nFUS5heHKuX_aez8NBzMA7H5zrHjtjYzRs";
            cargaPermisos();
        }

        public void cargaPermisos()
        {
            if (!perfil.Equals("admin"))
            { 
                CategoriaClienteRecoge.Enabled = false;
                CategoriaCompras.Enabled = false;
                CategoriaContabilidad.Enabled = false;
                CategoriaCXC.Enabled = false;
                CategoriaLogistica.Enabled = false;
                Categoriamkt.Enabled = false;
                CategoriaPostVenta.Enabled = false;
                CategoriaVentas.Enabled = false;
            }

            string acceso = perfil.ToUpper();
            switch (acceso)
            {
                case "CONTABILIDAD":
                    break;
                case "COMPRAS":
                    CategoriaCompras.Enabled = true;
                    break;
                case "CTERECOGE":
                    CategoriaClienteRecoge.Enabled = true;
                    break;
                case "COBRANZA":
                    CategoriaCXC.Enabled = true;
                    break;
                case "ALMACEN":
                    CategoriaLogistica.Enabled = true;
                    break;
                case "MKT":
                    Categoriamkt.Enabled = true;
                    break;
                case "POSTVENTA":
                    CategoriaPostVenta.Enabled = true;
                    break;
                case "APOYOVENTAS":
                    CategoriaVentas.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void tileNavPane1_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            if (e.IsTile)
            {
                UserControl userControl;      
                switch (e.Element.Name.ToString())
                { 
                    case "tileNavWMS":
                        WMS.menuWMS wms = new WMS.menuWMS(conString,"admin","admin");
                        wms.Show();
                        
                        break;
                   case "btnCreaPedido": 
                      /*  panelControl1.Controls.Clear();
                        Views.Ventas.SaleOrderSentVista sosv = new Views.Ventas.SaleOrderSentVista(token);
                        sosv.Parent = panelControl1;
                        sosv.Dock = DockStyle.Fill;
                        panelControl1.Controls.Add(sosv);
                        sosv.BringToFront();*/

                      //  userControl= new Views.Ventas.SaleOrderSentVista(token);
                        break;
                    case "btnEmbarqueMasivo":   case "btnApoyosEmbarcar":
                    case "btnEmbarqueMasivoCteRec":
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
                    case "btnDesembarcarCterec":
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
                    case "btnConfirmarCteRec":
                            panelControl1.Controls.Clear();
                        Views.PostVenta.Confirmacion c = new Views.PostVenta.Confirmacion(perfil, usuario,token)
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
                    case "btnRepVentasCliente":
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
                        Views.ClienteRecoge.entregaPedido epCTE = new Views.ClienteRecoge.entregaPedido(usuario,perfil,SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString,token)
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill

                        };
                        epCTE.BringToFront();
                        break;
                    case "btnAlmacenCteRecoge":
                    case "btnAlmacenCteRecRegistra":///borrar pruebas anyelo
                        panelControl1.Controls.Clear();
                        Views.ClienteRecoge.almacenCteRecoge acr = new Views.ClienteRecoge.almacenCteRecoge(usuario, perfil, sucursal);
                        acr.Show();
                        
                        break;
                    //btnRegistraCliente
                    case "btnRegistraCliente": ///borrar pruebas anyelo
                        panelControl1.Controls.Clear();
                        Views.ClienteRecoge.registroCliente rc = new Views.ClienteRecoge.registroCliente(usuario, perfil);
                        rc.Show();
                        break;

                    case "btnImprimirFactura":
                        panelControl1.Controls.Clear();
                        Views.Logistica.Empaque.ReimprimirFactura rf = new Views.Logistica.Empaque.ReimprimirFactura()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        rf.BringToFront();
                        break;
                    case "btnOrdenCobro":
                        panelControl1.Controls.Clear();
                        Views.CXC.OrdenCobroViewcs ocv = new Views.CXC.OrdenCobroViewcs(usuario)
                        {
                            Parent=panelControl1,
                            Dock=DockStyle.Fill
                        };
                        ocv.BringToFront();
                        break;
                    case "btnConvertirSAD":
                        panelControl1.Controls.Clear();
                        Views.Ventas.Apoyos.ConvertirSAD cs = new Views.Ventas.Apoyos.ConvertirSAD(usuario)
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        cs.BringToFront();
                        break;
                    case "btnAutorizarSAD":
                        panelControl1.Controls.Clear();
                        Views.CXC.AutorizarSAD sad = new Views.CXC.AutorizarSAD(usuario)
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        sad.BringToFront();
                        break;
                    case "btnValidarSADCR": case "btnValidarSADALM":
                        panelControl1.Controls.Clear();
                        Views.Logistica.Distribucion.ValidarSAD vscr = new Views.Logistica.Distribucion.ValidarSAD(usuario)
                        {
                            Parent=panelControl1,
                            Dock=DockStyle.Fill
                        };
                        break;
                    case "btnReporteSADCXC": case "btnReporteSADALM":
                        panelControl1.Controls.Clear();
                        Views.CXC.ReporteSAD rs = new Views.CXC.ReporteSAD()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        break;
                    case "btnFacturasEmbarcadas":
                        panelControl1.Controls.Clear();
                        Views.CXC.Reportes.FacturasEmbarcadas fe = new Views.CXC.Reportes.FacturasEmbarcadas()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        break;
                    case "btnReporteOrdenCobro":
                        panelControl1.Controls.Clear();
                        Views.CXC.Reportes.ReporteOrdenCobro roc = new Views.CXC.Reportes.ReporteOrdenCobro()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        break;
                    case "btnReciboDeCobro":
                        panelControl1.Controls.Clear();
                        Views.CXC.entrega_block eb = new Views.CXC.entrega_block(usuario,perfil)
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        break;
                    case "btnTOR":
                        panelControl1.Controls.Clear();
                        Views.PostVenta.TransferOrder tor = new Views.PostVenta.TransferOrder()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        break;
                    case "btnComprasOcPend":
                        panelControl1.Controls.Clear();
                        Views.Compras.Reportes.RepOCPendientes OCPEN = new Views.Compras.Reportes.RepOCPendientes()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        break;
                    case "btnCompraeRIKA":
                        panelControl1.Controls.Clear();
                        Views.Compras.Reportes.RepErikacs repErikacs = new Views.Compras.Reportes.RepErikacs()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                            //KJDHKJSHDKS
                        };
                        break;
                    case "btndistribubcionEmbarque":
                    case "btnReporteEmbarqueCteRec":
                        panelControl1.Controls.Clear();
                        Views.Logistica.Distribucion.reporteEmbarques reD = new Views.Logistica.Distribucion.reporteEmbarques()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        reD.BringToFront();
                        break;
                    
                    case "btnPostVentaReportesEmbarques":
                        panelControl1.Controls.Clear();
                        Views.Logistica.Distribucion.reporteEmbarques remb = new Views.Logistica.Distribucion.reporteEmbarques()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        remb.BringToFront();
                        break;
                    case "btnApoyosReporteSAD":
                        panelControl1.Controls.Clear();
                        Views.CXC.ReporteSAD rasad = new Views.CXC.ReporteSAD()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        rasad.BringToFront();
                        break;
                    case "btnApoyosOrdenCobro":
                        panelControl1.Controls.Clear();
                        Views.CXC.OrdenCobroViewcs ocapo = new Views.CXC.OrdenCobroViewcs(usuario)
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        ocapo.BringToFront();
                        break;
                    case "btnArqueo":
                        panelControl1.Controls.Clear();
                        Views.CXC.Arqueo ar = new Views.CXC.Arqueo()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        ar.BringToFront();
                        break;
                    case "btnReporteOrdenCobroAPoyo":
                        panelControl1.Controls.Clear();
                        Views.CXC.Reportes.ReporteOrdenCobro roca = new Views.CXC.Reportes.ReporteOrdenCobro()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        roca.BringToFront();
                        break;
                    case "btnCteRecogeReporteAlmacen":
                        panelControl1.Controls.Clear();
                        Views.ClienteRecoge.ReporteAlmacenCterecoge racr = new Views.ClienteRecoge.ReporteAlmacenCterecoge("")
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        racr.BringToFront();
                        break;
                    case "btnSurtirEventos":
                        panelControl1.Controls.Clear();
                        Views.PostVenta.SurtirEventos se = new Views.PostVenta.SurtirEventos()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        se.BringToFront();
                        break;
                    case "btnCxcReportesEmbarques":
                        panelControl1.Controls.Clear();
                        Views.Logistica.Distribucion.reporteEmbarques res = new Views.Logistica.Distribucion.reporteEmbarques()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        res.BringToFront();
                        break;
                    case "btnRegresarEventos":
                        panelControl1.Controls.Clear();
                        Views.PostVenta.RegresarEventos rev = new Views.PostVenta.RegresarEventos()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        rev.BringToFront();
                        break;
                    case "btnApoyosEstatusPedido":
                        panelControl1.Controls.Clear();
                        Views.Ventas.Apoyos.PedidoEstatusBO peo = new Views.Ventas.Apoyos.PedidoEstatusBO()
                        {
                            Parent=panelControl1,
                            Dock=DockStyle.Fill
                        };
                        
                        break;
                    case "btnFacturarV2":
                        panelControl1.Controls.Clear();
                        Views.Logistica.Empaque.empaquePantallaV2 epv2 = new Views.Logistica.Empaque.empaquePantallaV2(usuario)
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        epv2.BringToFront();
                        break;
                    case "btnAplicarPAgos":
                        panelControl1.Controls.Clear();
                        Views.CXC.PaymentInvoiceApply pia = new Views.CXC.PaymentInvoiceApply(usuario)
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        pia.BringToFront();
                        break;
                    case "btnTimbrado":
                       /* panelControl1.Controls.Clear();
                        Views.Contabilidad.TimbradoPrueba tb = new Views.Contabilidad.TimbradoPrueba()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        tb.BringToFront();*/
                        break;
                    case "btnTimbrarPagos":
                       /*  panelControl1.Controls.Clear();
                         Views.CXC.TimbradoPago tp = new Views.CXC.TimbradoPago()
                         {
                             Parent = panelControl1,
                             Dock = DockStyle.Fill
                         };
                         tp.BringToFront();
                      */
                        break;
                    case "btnCancelarPedidoApoyo":
                        panelControl1.Controls.Clear();
                        Views.Ventas.Apoyos.CancelarPedido cp = new Views.Ventas.Apoyos.CancelarPedido(usuario)
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        cp.BringToFront();
                        break;
                    case "btnsaleorderEditor":
                        panelControl1.Controls.Clear();
                        Views.Ventas.Apoyos.saleOrderEditor soe = new Views.Ventas.Apoyos.saleOrderEditor()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        soe.BringToFront();
                        break;
                    case "btnReporteTimbrados":
                    panelControl1.Controls.Clear();
                    Views.CXC.PaymentInvoiceApplyReport puar = new Views.CXC.PaymentInvoiceApplyReport()
                    {
                        Parent = panelControl1,
                        Dock = DockStyle.Fill
                    };
                       puar.BringToFront();
                        break;

                    case "btnReporteEmbarqueCTeRecoge":
                        panelControl1.Controls.Clear();
                        Views.Logistica.Distribucion.reporteEmbarques resCTeREC = new Views.Logistica.Distribucion.reporteEmbarques()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill

                        };
                        resCTeREC.BringToFront();
                        break;

                    case "btnAplicarNotaCredito":
                        panelControl1.Controls.Clear();
                        Views.CXC.CreditMemoApply cma = new Views.CXC.CreditMemoApply()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill

                        };
                        cma.BringToFront();
                        break;

                    case "btnDesgloseMOV":
                        panelControl1.Controls.Clear();
                        Views.Compras.Reportes.DesgloseMovimientosQV dmqv = new Views.Compras.Reportes.DesgloseMovimientosQV()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        dmqv.BringToFront();
                        break;

                    case "btnCancelarArticuloPedido":
                        panelControl1.Controls.Clear();
                        Views.Compras.CancelarBOCompras CBo = new Views.Compras.CancelarBOCompras(usuario)
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        CBo.BringToFront();
                        break;
                    case "btnComprasActualizaBases":
                        panelControl1.Controls.Clear();
                        Views.Compras.ActualizaBasesCompras abc = new Views.Compras.ActualizaBasesCompras()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill

                        };
                        abc.BringToFront();
                        break;
                    case "btnLiberaUsuario":
                        panelControl1.Controls.Clear();
                        Views.Logistica.Empaque.LiberarUsuarioWMS luwms = new Views.Logistica.Empaque.LiberarUsuarioWMS()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        luwms.BringToFront();
                        break;
                    case "btnCapturaGastoFletera":
                        panelControl1.Controls.Clear();
                        Views.Logistica.Distribucion.GastoFleteras gf = new Views.Logistica.Distribucion.GastoFleteras(usuario,token)
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        gf.BringToFront();
                        break;
                    case "btnEditarGuia":
                        panelControl1.Controls.Clear();
                        Views.Logistica.Distribucion.EditarNumGuia eng = new Views.Logistica.Distribucion.EditarNumGuia()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        eng.BringToFront();
                        break;
                    case "btnLogisticaRepFacturasXEmb":
                    case "btnPostVentaFacturasXEmbarcar":
                        panelControl1.Controls.Clear();
                        Views.Logistica.Reportes.FacturasXEmbarcar fxe = new Views.Logistica.Reportes.FacturasXEmbarcar()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        fxe.BringToFront();
                        break;
                    case "btnReporteGastoFletera":
                        panelControl1.Controls.Clear();
                        Views.Logistica.Reportes.ReporteGastoFletera rgf = new Views.Logistica.Reportes.ReporteGastoFletera()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill                        
                        };
                        rgf.BringToFront();
                        break;
                    case "btnNumeroGuiaPostventa":   case "btnNumguiaPostventaLogistica":
                        panelControl1.Controls.Clear();
                        Views.PostVenta.RegistrodeGuias rdg = new Views.PostVenta.RegistrodeGuias(usuario,false)
                        {

                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        rdg.BringToFront();
                        break;
                    case "btnPlaneador":
                        panelControl1.Controls.Clear();
                        Views.Logistica.MesaControl.Planeador P = new Views.Logistica.MesaControl.Planeador()
                        {

                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        P.BringToFront();
                        break;
                    case "btnReporteInterfazRecibo":
                        panelControl1.Controls.Clear();
                        Views.Logistica.Reportes.ReporteInterfazRecibo rir = new Views.Logistica.Reportes.ReporteInterfazRecibo()
                        {
                            Parent = panelControl1,
                            Dock = DockStyle.Fill
                        };
                        rir.BringToFront();
                        break;


                    default:
                    

                        break;


                }


            }
        }
    }
}