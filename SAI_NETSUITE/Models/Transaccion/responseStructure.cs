using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
    class responseJson
    {
        public ResponseStructure responseStructure { get; set; }
        public int internalId { get; set; }
    }
    public class ResponseStructure
    {
        public string codeStatus { get; set; }
        public string descriptionStatus { get; set; }
    }
}
