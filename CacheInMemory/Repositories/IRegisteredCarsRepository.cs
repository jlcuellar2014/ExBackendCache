using CacheInMemory.Model;
using CacheInMemory.Records;

namespace CacheInMemory.Repositories
{
    public interface IRegisteredCarsRepository
    {
        Task CreateAsync(RegisteredCar registeredCar);
        Task DeleteAsync(int idRegisteredCar);
        Task<List<RegisteredCarRecord>> GetAsync();
        Task UpdateAsync(int idRegisteredCar, RegisteredCar registeredCar);
    }
}