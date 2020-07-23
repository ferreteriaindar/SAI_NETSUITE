using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using SAI_NETSUITE.Controllers.Ventas;

namespace SAI_NETSUITE.Views.Ventas.Apoyos
{
    public partial class saleOrderEditor : UserControl
    {
      
        public saleOrderEditor()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            cargaInfo();
        }

        public void cargaInfo()
        {
            try
            {
                Controllers.Ventas.PedidoEstatusBOController pebo = new Controllers.Ventas.PedidoEstatusBOController();
                Models.Transaccion.SalesOrderBOStatusModel soBO = pebo.regresaInfo(txtPedido.Text);
                foreach (var item in soBO.result)
                {
                    item.quantity2 = item.quantitycommitted;
                }         
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
                
                txtEstatusWMS.Text = pebo.regresaInfoWMS2(txtPedido.Text, txtTipo.Text);
                if (!txtEstatusWMS.Text.Equals("No esta ingresado a WMS"))
                {
                    gridControl1.Enabled = false;
                    BtnEnviarWMS.Enabled = false;
                }
                else
                {
                    gridControl1.Enabled = true;
                    BtnEnviarWMS.Enabled = true;
                }
                if (soBO.result.Sum(x => x.quantitycommitted) == 0)
                    BtnEnviarWMS.Enabled = false;
                   
            }
            catch (Exception ex)
            {
                MessageBox.Show("El pedido no existe \n  o \n no esta aprobado");
            }

        }

        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            EditFormValidateEditorEventArgs ea = e as EditFormValidateEditorEventArgs;
            string fieldName = string.Empty;

            if (ea == null)
                fieldName = view.FocusedColumn.FieldName;
            else
                fieldName = ea.Column.FieldName;

            if (fieldName == "quantity2")
            {
                int cantidad = Convert.ToInt32(e.Value);
                int reservado = Convert.ToInt32(gridView1.GetFocusedRowCellValue(colquantitycommitted).ToString());
                if (cantidad > reservado)
                {
                    BtnEnviarWMS.Enabled = false;
                    e.Valid = false;
                    e.ErrorText = "La Cantidad no puede ser mayor a Reservado";
                }
                else BtnEnviarWMS.Enabled = true;
                
            }
              //  e.Valid = !(Convert.ToInt32(e.Value) < 0);
           /* else if (fieldName == "Notes")
                e.Valid = !(string.IsNullOrEmpty(Convert.ToString(e.Value)));*/

           // e.ErrorText = "The entered value is invalid (ValidatingEditor)";


        }

        private void BtnEnviarWMS_Click(object sender, EventArgs e)
        {
            
            List<saleordereditorART> listaNew = new List<saleordereditorART>();

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                saleordereditorART aRT = new saleordereditorART()
                {
                    itemid = gridView1.GetRowCellValue(i, colitemid).ToString(),
                    cantidad = Convert.ToInt32(gridView1.GetRowCellValue(i, colquantityNew).ToString())
                };
                listaNew.Add(aRT);
            }

            var despues = listaNew.ToList();
            saleOrderEditorController soc = new saleOrderEditorController();
            bool resultado = soc.actualizaDetalle(despues, txtNumpedido.Text);
            if (resultado)
            {
              bool resultadoWMS=  soc.InsertaAWMS(txtNumpedido.Text);
                if (resultadoWMS)
                {
                    MessageBox.Show("Enviado existosamente");
                    cargaInfo();
                }
                else MessageBox.Show("Perdon!!  parece que hubo un error habla a sistemas");
            }
            else MessageBox.Show("Perdon!!  parece que hubo un error habla a sistemas");
        }


    }
    public class saleordereditorART
    {
      public  string itemid { get; set; }
        public int  cantidad { get; set; }
    }
}
