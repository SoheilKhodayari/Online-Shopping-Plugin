using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
//using OnlineShopping.Mapping;

namespace OnlineShopping
{
    public class MigrationsContextFactory : IDbContextFactory<AppContext>
    {
        public AppContext Create()
        {
            return new AppContext();
        }
    }

    public class AppContext : DbContext
    {

        public AppContext(Boolean DropInitializeDB = false, string ConnectionStringName = "OnlineShoppingFrameworkContext")
            : base(ConnectionStringName)
        {
            if (DropInitializeDB)
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<AppContext>());
            }
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<PurchaseHistory> PurchaseHistories { get; set; }
        public DbSet<ItemSpec> ItemSpecs { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ICategory> Categories { get; set; }
        public DbSet<Basket> Baskets { get; set; }

    }
}