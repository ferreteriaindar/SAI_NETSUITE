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

namespace SAI_NETSUITE.Views.CXC
{
    public partial class PaymentInvoiceApplyReport : UserControl
    {
        public PaymentInvoiceApplyReport()
        {
            InitializeComponent();
        }

        private void PaymentInvoiceApplyReport_Load(object sender, EventArgs e)
        {
            cargaZonas();
        }


        public void cargaZonas()
        {
            Controllers.CXC.ArqueoController ac = new Controllers.CXC.ArqueoController();
            searchLookUpEdit1.Properties.DisplayMember = "zona";
            searchLookUpEdit1.Properties.ValueMember = "id";
            searchLookUpEdit1.Properties.DataSource = ac.regresaZonas();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
              BtnConsultar.ImageOptions.Image = SAI_NETSUITE.Properties.Resources.gear;
                if (!backgroundWorker1.IsBusy)
                    backgroundWorker1.RunWorkerAsync(argument: searchLookUpEdit1.EditValue.ToString());
            }
            else MessageBox.Show("Selecciona una Zona");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Controllers.CXC.PaymentInvoiceApplyController piac = new Controllers.CXC.PaymentInvoiceApplyController();
            Payment_CreditMemo_certifiedModel pcc = piac.regresaReporteTimbrados((string)e.Argument);

            e.Result = pcc;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Payment_CreditMemo_certifiedModel pcc = (Payment_CreditMemo_certifiedModel)e.Result;
            BtnConsultar.ImageOptions.Image = null;
            //gridControl1.DataSource = pcc.result.Resultados.Documentos.ToList();

            List<resumenPaymentCreditReport> lista = new List<resumenPaymentCreditReport>();
            int row = 0;
            foreach (var item in pcc.result.Resultados.Documentos.Where(x=> x.type.Equals("Payment") && x.facturaId==null))
            {
                row++;
                resumenPaymentCreditReport rpcr = new resumenPaymentCreditReport()
                {
                    customer = item.customer,
                    mensaje = item.mensaje,
                    uuuid = item.uuid,
                    pago = item.tranid,
                    row = row,
                    url = "https://5327814.app.netsuite.com/app/accounting/transactions/custpymt.nl?id="+item.respuesta,


                };
                lista.Add(rpcr);
                var facturasID = pcc.result.Resultados.Documentos.Where(x => x.type.Equals("Payment") && x.tranid.Equals(item.tranid) && x.facturaId != null).Select(x => x.facturaId).ToList();
                var notas = pcc.result.Resultados.Documentos.Where(x => x.type.Equals("Credit Memo")&& facturasID.Contains(x.facturaId)).GroupBy(y=> y.tranid).Select(g=>g.First()); //&& facturasID.Contains(x.facturaId));
                foreach (var nc in notas.Distinct())
                {
                    row++;
                    resumenPaymentCreditReport rpcr2 = new resumenPaymentCreditReport()
                    {
                        nota = nc.tranid,
                        row = row,
                        mensaje = nc.mensaje,
                        uuuid = nc.uuid,
                        url= "https://5327814.app.netsuite.com/app/accounting/transactions/custcred.nl?id=" + nc.respuesta,


                    };

                    lista.Add(rpcr2);
                }

            }

            gridControl1.DataSource = lista;
        }
    }
}
