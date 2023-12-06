using Microsoft.EntityFrameworkCore;

namespace CacheInMemory.Model
{
    public class CarRegistryContext(IConfiguration configuration): DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<RegisteredCar> RegisteredCars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(configuration.GetConnectionString("SqLite"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasKey(o => o.CountryCode);
        }
    }
}
