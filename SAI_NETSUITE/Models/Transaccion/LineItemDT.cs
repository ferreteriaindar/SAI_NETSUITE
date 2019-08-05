using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAI_NETSUITE.Models.Transaccion
{
  public  class LineItemDT
    {
        public string itemId { get; set; }
        public int quantity { get; set; }
        public int inventoryQty { get; set; }
        public int listPriceId { get; set; }
        public double discount { get; set; }
        public int term { get; set; }
        public int category { get; set; }
    }
}
