using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAI_NETSUITE.Controllers.CXC;
using SAI_NETSUITE.Models.Transaccion;

namespace SAI_NETSUITE.Views.CXC
{
    public partial class CreditMemoApply : UserControl
    {
        DataTable dt;
        public CreditMemoApply()
        {
            dt = InicializaDT();
            InitializeComponent();
        }


        public DataTable InicializaDT()
        {
            DataTable dt = new DataTable();
           dt.Columns.Add("internalid", typeof(int));
            dt.Columns.Add("tranid", typeof(string));
            dt.Columns.Add("saldo", typeof(decimal));
            dt.Columns.Add("aplicar", typeof(decimal));
            return dt;
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void CreditMemoApply_Load(object sender, EventArgs e)
        {
            btnAplicar.Enabled = false;
            cargaClientes();
            cargaFormaYRelacion();
        }

        public void cargaClientes()
        {
            CreditMemoApplyController cmac = new CreditMemoApplyController();
            searchLookUpEdit1.Properties.DataSource = cmac.regresaClientes();
            
        }

        public void cargaFormaYRelacion()
        {
            CreditMemoApplyController cmac = new CreditMemoApplyController();
            searchFormaPago.Properties.DataSource = cmac.regresaFormaPago();
            searchTipoRelacion.Properties.DataSource = cmac.regresaTipoRelacion();
        }


        private void btnBuscarNotas_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                btnBuscarNotas.ImageOptions.Image = SAI_NETSUITE.Properties.Resources.gear;
                btnBuscarNotas.Appearance.BackColor = Color.DodgerBlue;
                if (!backgroundWorker1.IsBusy)
                    backgroundWorker1.RunWorkerAsync(argument: searchLookUpEdit1.EditValue.ToString());
            }
            else MessageBox.Show("Selecciona un Cliente");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Controllers.CXC.CreditMemoApplyController cmac = new CreditMemoApplyController();
            CreditMemoApplySearchModel datos = cmac.regresaDatos(searchLookUpEdit1.EditValue.ToString());
            //gridControlFacturas.DataSource = datos.result.Resultados.Documentos.Where(x => x.type.Equals("Invoice")).ToList();
            e.Result = datos;


        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CreditMemoApplySearchModel datos = (CreditMemoApplySearchModel)e.Result;
            gridControlFacturas.DataSource = datos.result.Resultados.Documentos.Where(x => x.type.Equals("Invoice")).ToList();
            gridControlNotas.DataSource = datos.result.Resultados.Documentos.Where(x => x.type.Equals("Credit Memo")).ToList();
            btnBuscarNotas.ImageOptions.Image = null;
            btnBuscarNotas.Appearance.BackColor = Color.LightSkyBlue;
        }

        private void gridView3_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
        }

        private void gridViewNota_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            dt.Rows.Clear();
            txtFecha.Text = gridViewNota.GetFocusedRowCellValue(colNotadatecreated).ToString();
            txtNota.Text = gridViewNota.GetFocusedRowCellValue(colNotamemo).ToString();
            txtNumNota.Text = gridViewNota.GetFocusedRowCellValue(colNotatranid).ToString();
            txtSaldo.Text = gridViewNota.GetFocusedRowCellValue(colNotaamountremaining).ToString();
            searchFormaPago.EditValue= gridViewNota.GetFocusedRowCellValue(colNotaformaPago).ToString();
            searchTipoRelacion.EditValue= gridViewNota.GetFocusedRowCellValue(colNotatipoRelacion).ToString();
            txtsUMA.Text = "";

            gridViewFactura.ClearSelection();
            btnAplicar.Enabled = false;
        }

        

        private void gridViewFactura_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

            if (gridViewFactura.SelectedRowsCount > 0)
            {
                if (txtSaldo.Text.Equals(""))
                {
                    MessageBox.Show("Selecciona al menos una NOTA DE CREDITO");
                    gridViewFactura.ClearSelection();
                }
                else
                {
                    actualizaSuma();
                }
            }
            else dt.Rows.Clear();
            
        }

        public void actualizaSuma()
        {
            decimal saldo = Convert.ToDecimal(txtSaldo.Text);
            decimal actual = 0;
            dt.Rows.Clear();
            for (int i = 0; i < gridViewFactura.SelectedRowsCount; i++)
            {
                decimal facturaSaldo = Convert.ToDecimal(gridViewFactura.GetRowCellValue(gridViewFactura.GetSelectedRows()[i], colFacturaamountremaining).ToString());
                decimal aplicar = (saldo - actual) > facturaSaldo ?  facturaSaldo: (saldo - actual);
                actual = actual + aplicar;
                if ((dt.Rows.Count == 0 || aplicar < saldo) && aplicar != 0)
                    dt.Rows.Add(
                        gridViewFactura.GetRowCellValue(gridViewFactura.GetSelectedRows()[i], colfacturainternalid).ToString(),
                        gridViewFactura.GetRowCellValue(gridViewFactura.GetSelectedRows()[i], colFacturatranid).ToString(),
                        Convert.ToDecimal(gridViewFactura.GetRowCellValue(gridViewFactura.GetSelectedRows()[i], colFacturaamountremaining).ToString()),
                        aplicar
                        );
                else gridViewFactura.UnselectRow(gridViewFactura.GetSelectedRows()[i]);
                if (dt.Rows.Count > 0)
                    btnAplicar.Enabled = true;


            }

            gridControlFinal.DataSource = dt;
            txtsUMA.Text = actual.ToString();




        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (gridViewFinal.RowCount > 0 && dxValidationProvider1.Validate())
            {
                gridControlFacturas.Enabled = false;
                gridControlNotas.Enabled = false;
                gridControlFinal.Enabled = false;
                btnAplicar.ImageOptions.Image = SAI_NETSUITE.Properties.Resources.gear;
                ApplyCreditMemoSendModel acmsm = new ApplyCreditMemoSendModel();
                acmsm.invoices = new List<InvoiceApplyCreditMemoSendModel>();
                acmsm.internalId = gridViewNota.GetFocusedRowCellValue(colNotainternalid).ToString();
                acmsm.custbody_cfdi_tipo_relacion_33 = searchTipoRelacion.EditValue.ToString();
                acmsm.custbody_fe_metodo_de_pago = searchFormaPago.EditValue.ToString();
                List<InvoiceApplyCreditMemoSendModel> lista = new List<InvoiceApplyCreditMemoSendModel>();
                for (int i = 0; i < gridViewFinal.RowCount; i++)
                {
                    InvoiceApplyCreditMemoSendModel factura = new InvoiceApplyCreditMemoSendModel()
                    {
                        discount = gridViewFinal.GetRowCellValue(i, colFinalAplicar).ToString(),
                        Id = Convert.ToInt32(gridViewFinal.GetRowCellValue(i, colFinalinternalid).ToString())
                    };
                    lista.Add(factura);
                    acmsm.invoices.Add(factura);
                }

                if (!backgroundWorkerAplicar.IsBusy)
                {
                    backgroundWorkerAplicar.RunWorkerAsync(argument: acmsm);
                }
                else MessageBox.Show("Espera a que termine -_-!");

                /*
                CreditMemoApplyController cmac = new CreditMemoApplyController();
                if(cmac.AplicarNotaCredito(acmsm))
                    MessageBox.Show("Terminado y aplicado");
                else MessageBox.Show("Hubo un problema con la Aplicacion");  */


            }
            else MessageBox.Show("Escoge Al menos una Factura");
        }

        private void backgroundWorkerAplicar_DoWork(object sender, DoWorkEventArgs e)
        {
            ApplyCreditMemoSendModel acmsm = (ApplyCreditMemoSendModel)e.Argument;
            CreditMemoApplyController cmac = new CreditMemoApplyController();
            if (cmac.AplicarNotaCredito(acmsm))
                e.Result = true;
            else e.Result = false;
        }

        private void backgroundWorkerAplicar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool resultado = (bool)e.Result;
            gridControlFacturas.Enabled = true;
            gridControlNotas.Enabled = true;
            gridControlFinal.Enabled = true;
            gridControlFacturas.DataSource = null;
            Controllers.CXC.CreditMemoApplyController cmac = new CreditMemoApplyController();
            CreditMemoApplySearchModel datos = cmac.regresaDatos(searchLookUpEdit1.EditValue.ToString());
            gridControlFacturas.DataSource = datos.result.Resultados.Documentos.Where(x => x.type.Equals("Invoice")).ToList();
            gridControlNotas.DataSource = datos.result.Resultados.Documentos.Where(x => x.type.Equals("Credit Memo")).ToList();
            btnBuscarNotas.ImageOptions.Image = null;
            btnBuscarNotas.Appearance.BackColor = Color.LightSkyBlue;

            if (resultado)            
                MessageBox.Show("Terminado y aplicado");
            else MessageBox.Show("Hubo un problema con la Aplicacion");
            btnAplicar.ImageOptions.Image = null;


        }
    }
}
