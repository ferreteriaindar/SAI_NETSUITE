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
    
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            this.Estilo = new HashSet<Estilo>();
            this.OrdenEmbarque = new HashSet<OrdenEmbarque>();
            this.PedidoRenglon = new HashSet<PedidoRenglon>();
        }
    
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Usuario1 { get; set; }
        public string Contrasenia { get; set; }
        public Nullable<short> IdPerfil { get; set; }
        public bool Activo { get; set; }
        public System.DateTime FechaActualizado { get; set; }
        public int IdUsuarioActualiza { get; set; }
        public Nullable<byte> IDTIPOUSUARIO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Estilo> Estilo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdenEmbarque> OrdenEmbarque { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidoRenglon> PedidoRenglon { get; set; }
    }
}