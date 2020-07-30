using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
    class PaymentInvoiceApplyModel
    {

        public ResultPaymentInvoiceApplyModel result { get; set; }
    }

    public class ResultPaymentInvoiceApplyModel
    {
        public List<DocumentosPaymentInvoice> Documentos { get; set; }
    }


    public class DocumentosPaymentInvoice
    {
        public double? LimiteCredito { get; set; }
        public string Cobrador { get; set; }
        public string Vendedor { get; set; }
        public string Zona { get; set; }
        public string Cliente { get; set; }
        public string Documento { get; set; }
        public string NumDoc { get; set; }
        public string Nota { get; set; }
        public string Origen { get; set; }
        public string Fecha { get; set; }
        public string FechaRecibo { get; set; }
        public string FechaVencimiento { get; set; }
        public string Terminos { get; set; }
        public string DescuentoCliente { get; set; }
        public decimal? Vencimiento { get; set; }
        public double? ImporteBruto { get; set; }
        public double? SaldoPendiente { get; set; }
        public double? Porcentaje { get; set; }
        public double? DescuentoTotal { get; set; }
        public double? A_pagar { get; set; }
        public string custbody_paqueteria { get; set; }
        public int internalId { get; set; }
        public DateTime  fechaPago { get; set; }
        public DateTime FechaVencimientov2 { get; set; }
        public decimal? DescuentoFactura { get; set; }
        public string metodoPago { get; set; }
        public decimal? discount6 { get; set; }
        public decimal? discount10 { get; set; }
    }
}
