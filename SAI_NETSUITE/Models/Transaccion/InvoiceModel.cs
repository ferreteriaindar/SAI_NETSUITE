using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
    public class InvoiceModel
    {
        public int internalId { get; set; }
        public int TranId { get; set; }
        public string TranType { get; set; }
        public int Entity { get; set; }
        public DateTime TranDate { get; set; }
        public string Memo { get; set; }
        public double SubTotal { get; set; }
        public double DiscountTotal { get; set; }
        public double TaxTotal { get; set; }
        public double Total { get; set; }
        public double DescuentoTotalImporte { get; set; }
        public int DescuentoTotalPP { get; set; }
        public string DescuentoEspecial { get; set; }
        public string DescuentoEvento { get; set; }
        public string AutorizacionEspecial { get; set; }
        public double AmountDue { get; set; }
        public DateTime SaleDate { get; set; }
        public string LeadSource { get; set; }
        public string DepartamentoCliente { get; set; }
        public int TipoPedido { get; set; }
        public int ClienteContado { get; set; }
        public string RFC { get; set; }
        public string UUID { get; set; }
        public string OrdenCompra { get; set; }
        public string Usuario { get; set; }
        public int createdfrom { get; set; }
        public int ShippingWay { get; set; }
        public string status { get; set; }
        public int Paqueteria { get; set; }
        public DateTime? FechaRecepcionCliente { get; set; }
        public string ShipAddress { get; set; }
        public int TerminosPago { get; set; }
        public int CondicionVencimiento { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string BillAddress { get; set; }
        public int ExchangeRate { get; set; }
        public int Currency { get; set; }
        public DateTime? FechaProntoPago { get; set; }
        public bool AprobacionDescuentos { get; set; }
        public InvoiceLineItems lineItems { get; set; }
        public int? custbody_refpdf { get; set; }

        public string custbody_cfdi_metpago_sat { get; set; }
        public string custbody_cfdi_formadepago { get; set; }
        public string custbody_uso_cfdi { get; set; }
        public string CurrencySymbol { get; set; }

    }


    public class InvoiceItems
    {
        public int item { get; set; }
        public double amount { get; set; }
        public double rate { get; set; }
        public double tax1amt { get; set; }
        public string taxcode { get; set; }
        public string taxcode_display { get; set; }
        public int taxrate1 { get; set; }
        public int quantity { get; set; }
        public double grossamt { get; set; }
        public double DiscountTotal { get; set; }
    }

    public class InvoiceLineItems
    {
        public List<InvoiceItems> item { get; set; }
    }
}
