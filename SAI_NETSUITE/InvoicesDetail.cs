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
    
    public partial class InvoicesDetail
    {
        public int InvoicesDId { get; set; }
        public Nullable<int> InvoicesId { get; set; }
        public Nullable<int> item { get; set; }
        public Nullable<decimal> amount { get; set; }
        public Nullable<decimal> rate { get; set; }
        public Nullable<decimal> tax1amt { get; set; }
        public string taxcode { get; set; }
        public string taxcode_display { get; set; }
        public Nullable<int> taxrate1 { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<decimal> DiscountTotal { get; set; }
    
        public virtual Invoices Invoices { get; set; }
    }
}
