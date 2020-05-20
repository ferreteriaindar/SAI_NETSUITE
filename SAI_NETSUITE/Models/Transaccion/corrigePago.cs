using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
    class corrigePago
    {
        public int internalId { get; set; }
        public string tranid { get; set; }

        public string xml { get; set; }
        public string pdf { get; set; }
    }
}
