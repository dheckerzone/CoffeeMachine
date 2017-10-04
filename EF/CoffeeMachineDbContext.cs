using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EF
{
    public class CoffeeMachineDbContext: DbContext
    {
        public CoffeeMachineDbContext(): base("Server=(localdb)\\mssqllocaldb;Database=CoffeeMachine;Trusted_Connection=True;MultipleActiveResultSets=true")
        {

        }

        public DbSet<Coffee> Coffees { get; set; }

        public DbSet<Office> Offices { get; set; }

        public DbSet<Supply> Supplies { get; set; }

        public DbSet<Pantry> Pantries { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
