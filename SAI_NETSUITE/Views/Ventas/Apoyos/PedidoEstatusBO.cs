using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAI_NETSUITE.Views.Ventas.Apoyos
{
    public partial class PedidoEstatusBO : UserControl
    {
        public PedidoEstatusBO()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            btnCambiarBo.Enabled = false;
            cargaInfo();
            if (NohayBackorders())
                btnCambiarBo.Enabled = true;
            else btnCambiarBo.Enabled = false;
        }
        //VALIDAR QUE NO ESTE INGRESADO  AL  WMS
        //ANTES DE MOSTRAR EN PANTALLA   LA INFO DE NETSUITE PARA  ASI VALIDAR QUE SI SE PUEDE INSERTAR EN WMS
        //
        //
        //
        //
        //

        private bool NohayBackorders()
        {
            int bo = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                int actual = Convert.ToInt32(gridView1.GetRowCellValue(i, colquantitybackordered).ToString());
                bo = bo + actual;
                
            }
            if (bo > 0)
                txtEstatusWMS.Text = "Hay Backorder";
            if (txtestatus.Text.Equals("Cerrado") || txtestatus.Text.Equals("Cancelado"))
                return false;
            if (txtEstatusWMS.Text.Equals("ES_BO") && bo == 0 && txtTipo.Text.Equals("BO"))
            {
                txtEstatusWMS.Text = "Ingresalo a WMS";
                return true;
            }
            if (txtEstatusWMS.Text.Equals("ES_BO") && bo == 0 && !txtTipo.Text.Equals("BO"))
            {
                txtEstatusWMS.Text = "Ingresalo a WMS";
                return true;
            }

            if (bo == 0 && txtEstatusWMS.Equals("Facturado"))
            {
                return true;
            }
            else return false;
        }

        public void cargaInfo()
        {
            try
            {
                Controllers.Ventas.PedidoEstatusBOController pebo = new Controllers.Ventas.PedidoEstatusBOController();
                Models.Transaccion.SalesOrderBOStatusModel soBO = pebo.regresaInfo(txtPedido.Text);
                gridControl1.DataSource = soBO.result;
                TxtNombreCliente.Text = soBO.result[0].customername;
                string status = "";
                // txtestatus.Text = soBO.result[0].status;
                txtFecha.Text = soBO.result[0].fecha.ToShortDateString();
                txtTipo.Text = soBO.result[0].typeOrder;
                txtNumpedido.Text = soBO.result[0].pedido;
                switch (soBO.result[0].status)
                {
                    case "Pending Approval":
                        status = "Pendiente por Aprobar";
                        break;
                    case "Pending Fulfillment":
                        status = "Por Surtir";
                        break;
                    case "Cancelled":
                        status = "Cancelado";
                        break;
                    case "Partially Fulfilled":
                        status = "Parcialmente Surtido";
                        break;
                    case "Pending Billing/Partially Fulfilled":
                        status = "Parcialmente surtido y Facturado";
                        break;
                    case "Pending Billing":
                        status = "Pendiente por Facturar";
                        break;
                    case "Billed":
                        status = "Facturado";
                        break;
                    case "Closed":
                        status = "Cerrado";
                        break;

                };
                txtestatus.Text = status;
                txtEstatusWMS.Text = pebo.regresaInfoWMS(txtPedido.Text,txtTipo.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("El pedido no existe \n  o \n no esta aprobado");
            }


        }

        private void txtPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnCambiarBo.Enabled = false;
                cargaInfo();
                if (NohayBackorders())
                    btnCambiarBo.Enabled = true;
                else btnCambiarBo.Enabled = false;
            }
        }

        private void btnCambiarBo_Click(object sender, EventArgs e)
        {

            Controllers.Ventas.PedidoEstatusBOController pebo = new Controllers.Ventas.PedidoEstatusBOController();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                pebo.actualizaRenglon(txtNumpedido.Text, gridView1.GetRowCellValue(i, colitemid).ToString(),Convert.ToInt32( gridView1.GetRowCellValue(i, colquantity).ToString()));

            }

            pebo.insertaPedidoWMS(txtNumpedido.Text);
            cargaInfo();
            MessageBox.Show("Proceso Terminado");
          
        }
    }
}
