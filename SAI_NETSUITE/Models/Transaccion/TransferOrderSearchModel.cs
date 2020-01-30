using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
    class TransferOrderSearchModel
    {
       

        public List<DocumentosTransferOrderSearch> result { get; set; }
    }


    public class DocumentosTransferOrderSearch
    {
        public string fecha { get; set; }
        public int  tranid { get; set; }
        public string articulo { get; set; }
        public int cantidad { get; set; }
        public string creadopor { get; set; }
        public string memo { get; set; }
        public int internalid { get; set; }
    }
}
