﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class INDAR_INACTIONWMSEntities : DbContext
    {
        public INDAR_INACTIONWMSEntities()
            : base("name=INDAR_INACTIONWMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<OrdenEmbarque> OrdenEmbarque { get; set; }
        public virtual DbSet<PedidoRenglon> PedidoRenglon { get; set; }
        public virtual DbSet<Estilo> Estilo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<EntradaCompraEstatus_Out> EntradaCompraEstatus_Out { get; set; }
    }
}
