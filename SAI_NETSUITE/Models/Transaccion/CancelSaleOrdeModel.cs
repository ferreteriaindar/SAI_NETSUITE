using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
    class CancelSaleOrdeModel
    {
        public string saleOrderID { get; set; }
        public int compras { get; set; }
        public string usuario { get; set; }
        public string apoyo { get; set; }
        public string vendedor { get; set; }
        public List<CancelSaleOrdeModelLine> lines { get; set; }
    }

    public class CancelSaleOrdeModelLine
    {
        public string item { get; set; }
        public int itemid { get; set; }
        public int quantity { get; set; }
    }
}
