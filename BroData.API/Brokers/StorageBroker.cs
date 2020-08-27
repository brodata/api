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
            
        }
        
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
