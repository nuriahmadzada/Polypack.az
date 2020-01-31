using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Polypack.Models;

namespace Polypack.Data
{
    public class PolypackContext:DbContext
    {
        public PolypackContext() : base("PolypackContext")
        {

        }

        public DbSet<Header> Headers { get; set; }

        public DbSet<About> Abouts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Partner> Partners { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<WeProvide> WeProvides { get; set; }

        public DbSet<Banner> Banners { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }
    }
}