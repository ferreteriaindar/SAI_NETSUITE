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
    
    public partial class Departments
    {
        public Departments()
        {
            this.Customers = new HashSet<Customers>();
        }
    
        public int DEPARTMENT_ID { get; set; }
        public string NAME { get; set; }
        public Nullable<int> PARENT_ID { get; set; }
        public Nullable<bool> isInactive { get; set; }
    
        public virtual ICollection<Customers> Customers { get; set; }
    }
}
