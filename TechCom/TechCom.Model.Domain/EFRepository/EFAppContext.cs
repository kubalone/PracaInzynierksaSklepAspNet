using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using TechCom.Model.Domain.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TechCom.Model.Domain.EFRepository
{
  public class EFAppContext:DbContext
    {
        public EFAppContext():base("EFAppContext")
        {

        }
        //static EFAppContext()//wywołanie initializera
        //{
        //    Database.SetInitializer<EFAppContext>(null);
        //}
        public  DbSet<Product> Products { get; set; }
        public  DbSet<Category> Categories { get; set; }
        public virtual DbSet<OrderDetail> ShippingDetails { get; set; }//skorzystać do stworzenia zamówienia

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//nie tworzy mnogich nazw tabel
        }
    }
}
