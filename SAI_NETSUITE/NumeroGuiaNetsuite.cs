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
    
    public partial class NumeroGuiaNetsuite
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NumeroGuiaNetsuite()
        {
            this.NumeroGuiaNetsuiteD = new HashSet<NumeroGuiaNetsuiteD>();
            this.NumeroGuiaNetsuiteC = new HashSet<NumeroGuiaNetsuiteC>();
        }
    
        public int idNumeroGuia { get; set; }
        public string NumeroGuia { get; set; }
        public Nullable<int> idPaqueteria { get; set; }
        public Nullable<decimal> ImporteTotal { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string Usuario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NumeroGuiaNetsuiteD> NumeroGuiaNetsuiteD { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NumeroGuiaNetsuiteC> NumeroGuiaNetsuiteC { get; set; }
    }
}
