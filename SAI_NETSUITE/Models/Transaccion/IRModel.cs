using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
    public class IRModel
    {
        public  int id { get; set; }
        public string mov { get; set; }
        public string  vendor { get; set; }
        public DateTime  date { get; set; }
        public List<IRDModel> IRDetalle { get; set; }

    }


   
}
