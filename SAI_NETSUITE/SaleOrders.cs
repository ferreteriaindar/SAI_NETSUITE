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
    
    public partial class SaleOrders
    {
        public SaleOrders()
        {
            this.SaleOrdersDetails = new HashSet<SaleOrdersDetails>();
        }
    
        public int internalId { get; set; }
        public Nullable<int> idCustomer { get; set; }
        public Nullable<int> location { get; set; }
        public string idWeb { get; set; }
        public Nullable<int> typeSale { get; set; }
        public Nullable<System.DateTime> trandate { get; set; }
        public Nullable<int> condition { get; set; }
        public Nullable<int> paymetTerm { get; set; }
        public Nullable<int> term { get; set; }
        public Nullable<int> @event { get; set; }
        public Nullable<int> typeOrder { get; set; }
        public Nullable<int> tranId { get; set; }
        public string status { get; set; }
        public Nullable<int> package { get; set; }
        public string memo { get; set; }
        public Nullable<int> shippingWay { get; set; }
        public Nullable<decimal> customerDiscountPP { get; set; }
        public Nullable<int> billingAddress { get; set; }
        public Nullable<int> shippingAddress { get; set; }
        public Nullable<decimal> subtotal { get; set; }
        public Nullable<decimal> taxtotal { get; set; }
        public Nullable<decimal> total { get; set; }
        public Nullable<decimal> discounttotal { get; set; }
        public Nullable<decimal> specialDiscount { get; set; }
        public string specialDiscountAuth { get; set; }
        public Nullable<decimal> eventDiscount { get; set; }
        public Nullable<bool> syncWMS { get; set; }
        public Nullable<System.DateTime> fechaActualizacion { get; set; }
        public string department { get; set; }
        public string zone { get; set; }
    
        public virtual ICollection<SaleOrdersDetails> SaleOrdersDetails { get; set; }
    }
}