//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAI_NETSUITE
{
    using System;
    using System.Collections.Generic;
    
    public partial class Invoices
    {
        public Invoices()
        {
            this.InvoicesDetail = new HashSet<InvoicesDetail>();
        }
    
        public int TranId { get; set; }
        public string TranType { get; set; }
        public Nullable<int> Entity { get; set; }
        public Nullable<System.DateTime> TranDate { get; set; }
        public string Memo { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<decimal> DiscountTotal { get; set; }
        public Nullable<decimal> TaxTotal { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> DescuentoTotalImporte { get; set; }
        public Nullable<decimal> DescuentoTotalPP { get; set; }
        public string DescuentoEspecial { get; set; }
        public string DescuentoEvento { get; set; }
        public string AutorizacionEspecial { get; set; }
        public Nullable<decimal> AmountDue { get; set; }
        public Nullable<System.DateTime> SaleDate { get; set; }
        public string LeadSource { get; set; }
        public string DepartamentoCliente { get; set; }
        public Nullable<int> TipoPedido { get; set; }
        public Nullable<int> ClienteContado { get; set; }
        public string RFC { get; set; }
        public string UUID { get; set; }
        public string OrdenCompra { get; set; }
        public string Usuario { get; set; }
        public Nullable<int> createdfrom { get; set; }
        public Nullable<int> ShippingWay { get; set; }
        public Nullable<int> Paqueteria { get; set; }
        public Nullable<System.DateTime> FechaRecepcionCliente { get; set; }
        public string ShipAddress { get; set; }
        public Nullable<int> TerminosPago { get; set; }
        public Nullable<int> CondicionVencimiento { get; set; }
        public Nullable<System.DateTime> FechaVencimiento { get; set; }
        public string BillAddress { get; set; }
        public Nullable<bool> ExchangeRate { get; set; }
        public Nullable<bool> Currency { get; set; }
        public Nullable<System.DateTime> FechaProntoPago { get; set; }
        public Nullable<bool> AprobacionDescuentos { get; set; }
        public Nullable<System.DateTime> fechaActualizacion { get; set; }
        public Nullable<int> internalId { get; set; }
        public Nullable<int> custbody_refpdf { get; set; }
        public string status { get; set; }
        public string CfdiMetPagoSat { get; set; }
        public string CFDIFormaDePago { get; set; }
        public string UsoCFDI { get; set; }
        public string CurrencySymbol { get; set; }
        public string CfdiComentario { get; set; }
        public string ResponseCfdi { get; set; }
    
        public virtual ICollection<InvoicesDetail> InvoicesDetail { get; set; }
    }
}
