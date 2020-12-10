using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAI_NETSUITE.Controllers.Ventas;
using SAI_NETSUITE.Models.Transaccion;

namespace SAI_NETSUITE.Views.Ventas.Apoyos
{
    public partial class CancelarPedido : UserControl
    {
        SaleOrderCancelSearchModel scsm;
        string usuario;
        public CancelarPedido(string usr)
        {
            usuario = usr;
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            scsm = null;
            cargaDatos(txtBuscar.Text);
        }

        public void cargaDatos(string tranid)
        {
            if (!backgroundWorkerSearch.IsBusy)
            {
                btnBuscar.ImageOptions.Image = SAI_NETSUITE.Properties.Resources.gear;
                backgroundWorkerSearch.RunWorkerAsync(argument: tranid);
            }
            else MessageBox.Show("Espera a que termine -_-!");




        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            string tranid = (string)e.Argument;
            CancelarPedidoController cpc = new CancelarPedidoController();
            SaleOrderCancelSearchModel scsm = cpc.regresaInfo(tranid);
            e.Result = scsm;
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SaleOrderCancelSearchModel scsm=(SaleOrderCancelSearchModel )  e.Result;
            if (scsm.result.Resultados.Documentos.Count>0)
            {
                this.scsm = scsm;
                txtNombre.Text = scsm.result.Resultados.Documentos[0].companyname;
                txtCodigo.Text = scsm.result.Resultados.Documentos[0].entityid;
                txtNumPedido.Text = scsm.result.Resultados.Documentos[0].tranid;
                txtFecha.Text = scsm.result.Resultados.Documentos[0].trandate;
                txtTipo.Text = scsm.result.Resultados.Documentos[0].type;
                string estatus = "";
                switch (scsm.result.Resultados.Documentos[0].statusText)
                {
                    case "Pending Approval":
                        estatus = "Aprobacion Pendiente";
                        break;
                    case "Pending Fulfillment":
                        estatus = "Surtido Pendiente";
                        break;
                    case "Cancelled":
                        estatus = "Cancelado";
                        break;
                    case "Partially Fulfilled":
                        estatus = "Parcialmente Surtido";
                        break;
                    case "Pending Billing/Partially Fulfilled":
                        estatus = "Facturacion Pendiente/Parcialmente Surtido";
                        break;
                    case "Pending Billing":
                        estatus = "Facturacion Pendiente";
                        break;
                    case "Billed":
                        estatus = "Facturado";
                        break;
                    case "Closed":
                        estatus = "Cerrado";
                        break;
                    default:
                        estatus = "UNKNOWN STATUS";
                        break;
                }
                txtNetsuiteStatus.Text = estatus;
                txtWms.Text = new CancelarPedidoController().regresaInfoWMS(scsm.result.Resultados.Documentos[0].tranid);
                gridControl1.DataSource = scsm.result.Resultados.Documentos.Select(x => new { x.custitem_categoria_articulo, x.itemid }).ToList();
                if (scsm.result.Resultados.Documentos[0].statusText.Equals("Pending Fulfillment") || scsm.result.Resultados.Documentos[0].statusText.Equals("Pending Approval"))
                {
                    DateTime docDate = Convert.ToDateTime(scsm.result.Resultados.Documentos[0].trandate);
                    DateTime now = DateTime.Now;
                    Console.WriteLine(docDate.CompareTo(Convert.ToDateTime(DateTime.Now.ToShortDateString())));
                    if (txtWms.Text.Equals("Ingresado") || txtWms.Text.Equals("No Ingresado"))
                    {
                        btnCancelar.Enabled = true;
                        if (scsm.result.Resultados.Documentos.Where(y => y.custitem_categoria_articulo.Equals("S/PEDIDO")).Select(x => x.custitem_categoria_articulo.Equals("S/PEDIDO")).Count() > 0 && (docDate.CompareTo(Convert.ToDateTime(DateTime.Now.ToShortDateString())) != 0)&& !scsm.result.Resultados.Documentos[0].statusText.Equals("Pending Approval"))
                            btnCancelar.Enabled = false;

                    }
                    else btnCancelar.Enabled = false;
                }
                else btnCancelar.Enabled = false;

            }
            else MessageBox.Show("Revisa el numero de pedido no enocontramos nada");
            btnBuscar.ImageOptions.Image = null;
          
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cargaDatos(txtBuscar.Text);
            }
        }

        private void CancelarPedido_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerCancelar.IsBusy)
            {
                btnCancelar.ImageOptions.Image = SAI_NETSUITE.Properties.Resources.gear;
                List<object> argumentos = new List<object>();
                argumentos.Add(scsm.result.Resultados.Documentos[0].tranid);
                argumentos.Add(txtNetsuiteStatus.Text);
                argumentos.Add(scsm);
                argumentos.Add(usuario);
                argumentos.Add(txtWms.Text);
                backgroundWorkerCancelar.RunWorkerAsync(argument: argumentos);
            }
            else MessageBox.Show("Espera a que termine de mandar la peticion -_-!");
           
        }

        private void backgroundWorkerCancelar_DoWork(object sender, DoWorkEventArgs e)
        {
            List<object> argumentList = e.Argument as List<object>;
            CancelarPedidoController cpc = new CancelarPedidoController();
            string tranid = (string)argumentList[0];
            string status = (string)argumentList[1];
            SaleOrderCancelSearchModel scsm = (SaleOrderCancelSearchModel)argumentList[2];
            string usuario = (string)argumentList[3];
            string wmsEstatus = (string)argumentList[4];
            //se deshabilita para detectar por que no lo cancela en wms
             var resultado = cpc.CancelarPedido(tranid, status, scsm, usuario,wmsEstatus);
             e.Result = resultado.ToString();
            //e.Result = "Hubo un problema ya no se pudo cancelar en WMS";
        }

        private void backgroundWorkerCancelar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string resultado =(string) e.Result;

            if (resultado.Equals("OK"))
            {
                scsm = null;
                cargaDatos(txtBuscar.Text);
                MessageBox.Show("Proceso terminado");
                btnCancelar.ImageOptions.Image = null;


            }
            else
            {
                MessageBox.Show(resultado);
                btnCancelar.ImageOptions.Image = null;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
