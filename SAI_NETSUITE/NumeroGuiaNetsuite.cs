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
        public int idNumeroGuia { get; set; }
        public string NumeroGuia { get; set; }
        public Nullable<int> idPaqueteria { get; set; }
        public Nullable<decimal> ImporteTotal { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string Usuario { get; set; }
    
        public virtual NumeroGuiaNetsuiteC NumeroGuiaNetsuiteC { get; set; }
        public virtual NumeroGuiaNetsuiteD NumeroGuiaNetsuiteD { get; set; }
    }
}