using ProjektNaAplikacjeWWW.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProjektNaAplikacjeWWW.DAL
{
    public class databaseContext : DbContext
    {
        public databaseContext() : base("name=BookShopContext")
        {
            
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<databaseContext>(new DropCreateDatabaseIfModelChanges<databaseContext>());
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}