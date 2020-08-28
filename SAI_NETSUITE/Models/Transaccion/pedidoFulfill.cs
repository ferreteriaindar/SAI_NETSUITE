using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
 public   class pedidoFulfill
    {
        public string mov { get; set; }
        public string movid { get; set; }
        public string error { get; set; }
        public string cons { get; set; }
        public string formaEnvio { get; set; }
        public string cotizacion { get; set; }

        public List<Line> lines { get; set; }
    }







    public class PedidoFulfillCotizacion {
        public string idpedido { get; set; }
        public List<Articuloscotizacion>  listaArt{get;set;}
    }

    public class Articuloscotizacion
    {
        public string id { get; set; }
        public string  itemid  {get;set;}
        public int  cantidad { get; set; }



    }
}
