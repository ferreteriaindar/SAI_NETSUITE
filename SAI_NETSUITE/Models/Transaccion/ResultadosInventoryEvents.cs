using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
    class ResultadosInventoryEvents
    {
        public List<DocumentosInventoryEventsToList> result { get; set; }
    }

    public class DocumentosInventoryEventsToList
    {
        public string disponible { get; set; }
        public string nombre { get; set; }
        public string almacen { get; set; }
        public string descripcion { get; set; }
        public string internalid { get; set; }
    }
}
