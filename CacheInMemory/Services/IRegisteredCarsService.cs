using CacheInMemory.DTOs;

namespace CacheInMemory.Services
{
    public interface IRegisteredCarsService
    {
        Task CreateRegisteredCarAsync(RegisteredCarCreateDTO registeredCar);
        Task DeleteRegisteredCarAsync(int idRegisteredCar);
        List<RegisteredCarReadDTO> GetRegisteredCars();
        Task UpdateRegisteredCarAsync(int idRegisteredCar, RegisteredCarUpdateDTO registeredCar);
    }
}