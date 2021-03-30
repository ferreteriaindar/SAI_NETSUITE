using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
   public class GastoFleteraModel
    {
        public int idNumeroGuia { get; set; }
        public string NumeroGuia { get; set; }
        public decimal importe { get; set; }
        public decimal importeSinIVA { get; set; }
        public int  CAJAS { get; set; }
        public int BULTOS { get; set; }
        public int ATADO { get; set; }
        public int TARIMA { get; set; }
        public string Facturas { get; set; }
        public string METODO { get; set; }
        public string  comentario { get; set; }
        
        public string  paqueteria { get; set; }
        public string cliente { get; set; }
        public decimal retencion { get; set; }
    }
}
