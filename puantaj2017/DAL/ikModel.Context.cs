﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace puantaj2017.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ikEntities : DbContext
    {
        public ikEntities()
            : base("name=ikEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<birim> birims { get; set; }
        public virtual DbSet<Grup> Grups { get; set; }
        public virtual DbSet<Izin> Izins { get; set; }
        public virtual DbSet<IzinTip> IzinTips { get; set; }
        public virtual DbSet<PersonelGrup> PersonelGrups { get; set; }
        public virtual DbSet<Takip> Takips { get; set; }
        public virtual DbSet<Avanslar> Avanslars { get; set; }
        public virtual DbSet<vergi_dilim> vergi_dilim { get; set; }
        public virtual DbSet<vergi_dilim_detay> vergi_dilim_detay { get; set; }
        public virtual DbSet<Personel> Personels { get; set; }
        public virtual DbSet<PersonelMesai> PersonelMesais { get; set; }
    }
}
