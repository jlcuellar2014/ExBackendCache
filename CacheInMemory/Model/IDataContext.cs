using Microsoft.EntityFrameworkCore;

namespace CacheInMemory.Model
{
    public interface IDataContext
    {
        DbSet<Branch> Branches { get; set; }
        DbSet<Car> Cars { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<RegisteredCar> RegisteredCars { get; set; }

        Task SaveChangesAsync();
    }
}