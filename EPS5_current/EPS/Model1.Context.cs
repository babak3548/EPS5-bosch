﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EPS
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EPS200_SecureSQL1Entities : DbContext
    {
        public EPS200_SecureSQL1Entities()
            : base("name=EPS200_SecureSQL1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<CriBoschProfiles> CriBoschProfiles { get; set; }
        public DbSet<CriKomponenten> CriKomponenten { get; set; }
        public DbSet<CriPruefschritte> CriPruefschritte { get; set; }
        public DbSet<DbInfo> DbInfo { get; set; }
        public DbSet<DhkKomponenten> DhkKomponenten { get; set; }
        public DbSet<dtproperties> dtproperties { get; set; }
        public DbSet<KomponentenTypen> KomponentenTypen { get; set; }
        public DbSet<Kunden> Kunden { get; set; }
        public DbSet<Protokolle> Protokolle { get; set; }
    }
}
