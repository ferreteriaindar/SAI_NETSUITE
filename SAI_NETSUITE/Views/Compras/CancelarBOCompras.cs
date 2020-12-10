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
using SAI_NETSUITE.Controllers.Ventas;
using SAI_NETSUITE.Controllers.Compras;

namespace SAI_NETSUITE.Views.Compras
{
    public partial class CancelarBOCompras : DevExpress.XtraEditors.XtraUserControl
    {
        SaleOrderCancelSearchModel scsm;
        string usuario;
        public CancelarBOCompras(string usr)
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
            btnBuscar.ImageOptions.Image = null;
            SaleOrderCancelSearchModel scsm = (SaleOrderCancelSearchModel)e.Result;
            if (scsm.result.Resultados.Documentos[0].statusText.Equals("Pending Approval") || scsm.result.Resultados.Documentos[0].statusText.Equals("Pending Fulfillment"))
            {
                if (scsm.result.Resultados.Documentos.Count > 0)
                {
                    this.scsm = scsm;
                    txtNombre.Text = scsm.result.Resultados.Documentos[0].companyname;
                    // txtCodigo.Text = scsm.result.Resultados.Documentos[0].entityid;
                    txtNumPedido.Text = scsm.result.Resultados.Documentos[0].tranid;
                    // txtFecha.Text = scsm.result.Resultados.Documentos[0].trandate;
                    txtTipo.Text = scsm.result.Resultados.Documentos[0].type;
                }
                gridControl1.DataSource = scsm.result.Resultados.Documentos.Select(x => new { x.custitem_categoria_articulo, x.itemid,x.closed,x.quantity }).ToList();
            }
            else
            {
                btnCancela.Enabled = false;
                MessageBox.Show("El pedido no se puede editar ya esta facturado");
            }
        }

        private void CancelarBOCompras_Load(object sender, EventArgs e)
        {

        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {

                if (!backgroundWorkerCancelar.IsBusy)
                {
                    btnCancelar.ImageOptions.Image = SAI_NETSUITE.Properties.Resources.gear;
                    List<object> argumentos = new List<object>();
                    argumentos.Add(scsm.result.Resultados.Documentos[0].tranid);                   
                    argumentos.Add(scsm);
                    argumentos.Add(usuario);
                    List<CancelSaleOrdeModelLine> listaItems = new List<CancelSaleOrdeModelLine>();
                    CancelarBOComprasController cbocc = new CancelarBOComprasController();
                    for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                    {
                        int rowHandle = gridView1.GetSelectedRows()[i];

                        int idItem = cbocc.regresaIdItem(gridView1.GetRowCellValue(rowHandle, colitemid).ToString());
                        CancelSaleOrdeModelLine csml = new CancelSaleOrdeModelLine()
                        {

                            item = gridView1.GetRowCellValue(rowHandle, colitemid).ToString(),
                            itemid = idItem,
                            quantity=Convert.ToInt32( gridView1.GetRowCellValue(rowHandle, colquantity).ToString())




                        };
                        listaItems.Add(csml);
                    }
                    argumentos.Add(listaItems);
                    backgroundWorkerCancelar.RunWorkerAsync(argument: argumentos);
                }
                else MessageBox.Show("Espera a que termine de mandar la peticion -_-!");

            }
            else MessageBox.Show("Selecciona al menos un articulo");

        }

        private void backgroundWorkerCancelar_DoWork(object sender, DoWorkEventArgs e)
        {
            List<object> argumentList = e.Argument as List<object>;
            CancelarPedidoController cpc = new CancelarPedidoController();
            string tranid = (string)argumentList[0];           
            SaleOrderCancelSearchModel scsm = (SaleOrderCancelSearchModel)argumentList[1];
            string usuario = (string)argumentList[2];
            List<CancelSaleOrdeModelLine> listaItems = (List < CancelSaleOrdeModelLine > )argumentList[3];
            

            //se deshabilita para detectar por que no lo cancela en wms
            var resultado = cpc.CancelarPedidoBo(tranid,  scsm, usuario, listaItems);
            e.Result = resultado.ToString();
        }

        private void backgroundWorkerCancelar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string resultado = (string)e.Result;

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
    }
}
