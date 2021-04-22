using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
  public  class PlaneadorModel
    {

        public string Mov { get; set; }
        public int NumPedido { get; set; }

        public int Prioridad { get; set; }

        public string FormaEnvio { get; set; }

        public string Cliente { get; set; }

        public string Clave { get; set; }

        public string Nombre { get; set; }

        public int IdEstilo { get; set; }

        public string AREA { get; set; }

        public int porsurtir { get; set; }
        public int surtido { get; set; }
    }
}
