using CacheInMemory.Model;
using Microsoft.EntityFrameworkCore;

namespace CacheInMemory.Tests.Utils
{
    public class FakeDataContext : DbContext, IDataContext, IDisposable
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<RegisteredCar> RegisteredCars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseInMemoryDatabase("ForTest");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasKey(o => o.CountryCode);
            modelBuilder.Entity<Branch>().HasIndex(e => e.Name).IsUnique();
        }

        public async Task SaveChangesAsync() => await base.SaveChangesAsync();

        public override void Dispose()
        {
            Database.EnsureDeleted();
        }
    }
}
