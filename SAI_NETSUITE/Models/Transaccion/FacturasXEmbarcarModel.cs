using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
    class FacturasXEmbarcarModel
    {
        public int? Pedido { get; set; }
        public string Cotizacion { get; set; }
        public string Consolidado { get; set; }
        public string Movimiento { get; set; }
        public int Factura { get; set; }
        public DateTime? FechaFactura { get; set; }
        public string Cliente { get; set; }
        public string Nota { get; set; }
        public string CondicionPago { get; set; }
        public decimal? Importe { get; set; }
        public string FormaEnvio { get; set; }
        public string Fletera { get; set; }
        public int? Embarque { get; set; }
        public DateTime? FechaEmbarque { get; set; }
        public string EstadoEmbarque { get; set; }
        public string ComentarioEmbarque { get; set; }
        public string EstadoFactura { get; set; }
        public string ComentarioFactura { get; set; }
        public DateTime? FechaFleteXConfirmar { get; set; }
        public string FechaEntrega { get; set; }
        public string usuario { get; set; }
        public string Chofer { get; set; }
        public int? Dias { get; set; }
        public string Responsable { get; set; }
        public int? DiasPermitidos { get; set; }
       // public string Estatus { get; set; }

        public string Ubicacion { get; set; }

        public string totalEmbarques { get; set; }
    }
}
