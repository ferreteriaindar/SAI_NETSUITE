using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
   public class IRDModel
    {
      
        
            public int idIR { get; set; }
            public string itemid { get; set; }
            public int quantity { get; set; }
            public string sourceTran { get; set; }
            public int sourceNumber { get; set; }

        
    }
}
