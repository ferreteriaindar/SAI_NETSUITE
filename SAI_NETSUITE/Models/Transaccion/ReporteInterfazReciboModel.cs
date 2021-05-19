using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
    class ReporteInterfazReciboModel
    {
        public List<ReporteInterfazReciboModelDocumentos> result { get; set; }

    }

    public class ReporteInterfazReciboModelDocumentos
    {
        public string tranid { get; set; }
        public string from_location { get; set; }
        public string to_location { get; set; }
        public string item { get; set; }
        public int quantity { get; set; }
        public string trandate { get; set; }
       
    }


    public class ReporteInterfazReciboMix
    {
        public string tranid { get; set; }
        public string from_location { get; set; }
        public string to_location { get; set; }
        public string item { get; set; }
        public int quantity { get; set; }
        public string trandate { get; set; }

        public string MovId { get; set; }

        public string Articulo { get; set; }

        public int CantidadRecibida { get; set; }

        public int CantidadNoRecibida { get; set; }

        public DateTime FechaModificacion { get; set; }

        public bool EstatusSincronizacion { get; set; }
        public string mov { get; set; }

    }

}
