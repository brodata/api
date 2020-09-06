using BroData.API.Models.v0;
using Microsoft.EntityFrameworkCore;

namespace BroData.API.Brokers
{
    public class StorageBroker : DbContext
    {
        public StorageBroker(DbContextOptions<StorageBroker> options)
            : base(options)
        {
            //this.Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Name>().HasNoKey();
            modelBuilder.Entity<ISO3166>().HasNoKey();
        }
        
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ISO3166> iSO3166s { get; set; }
        public DbSet<Name> Names { get; set; }
    }
}
