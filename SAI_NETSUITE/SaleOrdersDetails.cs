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
    
    public partial class SaleOrdersDetails
    {
        public int idSaleOrderDetail { get; set; }
        public string itemId { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<int> listPrice { get; set; }
        public Nullable<decimal> amount { get; set; }
        public Nullable<int> saleOrderId { get; set; }
    
        public virtual Items Items { get; set; }
        public virtual SaleOrders SaleOrders { get; set; }
    }
}