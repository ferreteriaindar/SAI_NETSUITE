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
    
    public partial class FormaEnvio
    {
        public FormaEnvio()
        {
            this.Customers = new HashSet<Customers>();
        }
    
        public int LIST_ID { get; set; }
        public string LIST_ITEM_NAME { get; set; }
        public Nullable<bool> isInactive { get; set; }
    
        public virtual ICollection<Customers> Customers { get; set; }
    }
}
