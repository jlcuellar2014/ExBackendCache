using CacheInMemory.DTOs;
using CacheInMemory.Model;
using CacheInMemory.Repositories;
using Mapster;

namespace CacheInMemory.Services
{
    public class RegisteredCarsService(IRegisteredCarsRepository repo) : IRegisteredCarsService
    {
        public async Task<List<RegisteredCarReadDTO>> GetAsync()
        {
            var registeredCars = await repo.GetAsync();
            return registeredCars.Adapt<List<RegisteredCarReadDTO>>();
        }

        public async Task CreateAsync(RegisteredCarCreateDTO registeredCar)
            => await repo.CreateAsync(registeredCar.Adapt<RegisteredCar>());

        public async Task UpdateAsync(int idRegisteredCar, RegisteredCarUpdateDTO registeredCar)
            => await repo.UpdateAsync(idRegisteredCar, registeredCar.Adapt<RegisteredCar>());

        public async Task DeleteAsync(int idRegisteredCar)
            => await repo.DeleteAsync(idRegisteredCar);
    }
}