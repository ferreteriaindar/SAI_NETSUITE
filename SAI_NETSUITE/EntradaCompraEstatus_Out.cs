//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAI_NETSUITE
{
    using System;
    using System.Collections.Generic;
    
    public partial class EntradaCompraEstatus_Out
    {
        public int IdEntradaCompraEstatus { get; set; }
        public string Mov { get; set; }
        public string MovId { get; set; }
        public string Articulo { get; set; }
        public string Estatus { get; set; }
        public Nullable<double> CantidadRecibida { get; set; }
        public Nullable<double> CantidadNoRecibida { get; set; }
        public string IdUsuario_modifica { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<byte> EstatusSincronizacion { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
    }
}
