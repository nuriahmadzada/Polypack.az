﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Polypack.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PolymerContext : DbContext
    {
        public PolymerContext()
            : base("name=PolymerContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Header> Headers { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WeProvide> WeProvides { get; set; }
    }
}
