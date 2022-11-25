using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MyCode_EntityFramework.Models
{
    public class DB_Entities : DbContext
    {
        public DB_Entities() : base("DataUser") { }
        public DbSet<Usertbl> user { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Usertbl>().ToTable("UserName");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);


        }
    }
}
