using CacheInMemory.DTOs;

namespace CacheInMemory.Services
{
    public interface IRegisteredCarsService
    {
        Task CreateRegisteredCarAsync(RegisteredCarCreateDTO registeredCar);
        Task DeleteRegisteredCarAsync(int idRegisteredCar);
        Task<List<RegisteredCarReadDTO>> GetRegisteredCarsAsync();
        Task UpdateRegisteredCarAsync(int idRegisteredCar, RegisteredCarUpdateDTO registeredCar);
    }
}