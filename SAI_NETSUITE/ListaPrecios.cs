//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAI_NETSUITE
{
    using System;
    using System.Collections.Generic;
    
    public partial class ListaPrecios
    {
        public ListaPrecios()
        {
            this.Customers = new HashSet<Customers>();
        }
    
        public int price_type_id { get; set; }
        public string name { get; set; }
        public Nullable<bool> isInactive { get; set; }
    
        public virtual ICollection<Customers> Customers { get; set; }
    }
}
