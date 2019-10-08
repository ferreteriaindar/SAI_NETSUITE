using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
    class ItemFullfilmentModel
    {

        
        public Createdfrom createdfrom { get; set; }
        
        public string shipcountry { get; set; }
        
        public Shipstatus shipstatus { get; set; }
        
        public string shipzip { get; set; }
        
        public List<Line> lines { get; set; }
    }
    public class Createdfrom
    {
        
        public string id { get; set; }
        
        public string recordType { get; set; }
    }

    public class Shipstatus
    {
        
        public string value { get; set; }
        
        public string txt { get; set; }
    }

    public class Line
    {
        
        public string itemId { get; set; }
        
        public string location { get; set; }
        
        public string quantity { get; set; }
    }
}

