using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
    class UnsplitSaleOrderModel
    {
        public int CustomerId { get; set; }
        public List<LineItem> items { get; set; }
    }
}
