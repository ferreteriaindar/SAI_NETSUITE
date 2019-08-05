using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
    public class ItemInfobyCode
    {

        public string internalid { get; set; }
        public string code { get; set; }
        public string displayName { get; set; }
        public int categoryId { get; set; }
        public string category { get; set; }
        public string unit { get; set; }
        public int availableQty { get; set; }
        public int saleAmount { get; set; }
        public double price { get; set; }
        public double taxId { get; set; }
        public List<PromoIndar> PromoIndar { get; set; }
    }
    public class PromoIndar
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public double Discount { get; set; }
    }


    public class ResultItembyCode
    {
        public ItemInfobyCode Result { get; set; }
    
    }
}
