using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
   

    public class BillingAddress
    {
        public string id { get; set; }
    }

    public class ShippingAddress
    {
        public string id { get; set; }
    }

    public class TypeOrder
    {
        public string id { get; set; }
        public string txt { get; set; }
    }

    public class LineItem
    {
        public string itemId { get; set; }
        public string quantity { get; set; }
        public string listPrice { get; set; }
    }

    public class Department
    {
        public string id { get; set; }
        public string txt { get; set; }
    }

    public class ShippingWay
    {
        public string id { get; set; }
        public string txt { get; set; }
    }

    public class Package
    {
        public string id { get; set; }
        public string txt { get; set; }
    }

    public class SaleOrder
    {
        public string idCustomer { get; set; }
        public string date { get; set; }
        public string location { get; set; }
        public BillingAddress billingAddress { get; set; }
        public ShippingAddress shippingAddress { get; set; }
        public TypeOrder typeOrder { get; set; }
        public string idWeb { get; set; }
        public List<LineItem> lineItems { get; set; }
        public Department department { get; set; }
        public ShippingWay shippingWay { get; set; }
        public Package package { get; set; }
    }
}
