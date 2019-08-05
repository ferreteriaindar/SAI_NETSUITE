using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
   public class SplitSaleOrderModel
    {

        public int CustomerId { get; set; }
        public int Discount { get; set; }
        public string PaymentTerm { get; set; }
        public string GroupName { get; set; }
        public List<LineItemDT> items { get; set; }
    }

    public class ResultSplitSaleOrderModel
    {
        public List<SplitSaleOrderModel> Result { get; set; }
    }
}
