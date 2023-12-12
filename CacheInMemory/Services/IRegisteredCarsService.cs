using CacheInMemory.DTOs;

namespace CacheInMemory.Services
{
    public interface IRegisteredCarsService
    {
        Task CreateAsync(RegisteredCarCreateDTO registeredCar);
        Task DeleteAsync(int idRegisteredCar);
        Task<List<RegisteredCarReadDTO>> GetAsync();
        Task UpdateAsync(int idRegisteredCar, RegisteredCarUpdateDTO registeredCar);
    }
}