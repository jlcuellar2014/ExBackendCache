using CacheInMemory.DTOs;
using CacheInMemory.Model;
using CacheInMemory.Repositories;
using Mapster;

namespace CacheInMemory.Services
{
    public class CarsService(ICarsRepository repo) : ICarsService
    {
        public async Task<List<CarReadDTO>> GetAsync()
        {
            var cars = await repo.GetAsync();
            return cars.Adapt<List<CarReadDTO>>();
        }

        public async Task<List<CarReadDTO>> GetByParamsAsync(CarSearchingDTO carSearching)
        {
            var cars = await repo.GetByParamsAsync(carSearching);
            return cars.Adapt<List<CarReadDTO>>();
        }

        public async Task CreateAsync(CarCreateDTO car)
            => await repo.CreateAsync(car.Adapt<Car>());

        public async Task UpdateAsync(int cardId, CarUpdateDTO car)
            => await repo.UpdateAsync(cardId, car.Adapt<Car>());

        public async Task DeleteAsync(int cardId)
            => await repo.DeleteAsync(cardId);
    }
}
