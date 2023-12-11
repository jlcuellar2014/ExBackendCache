using CacheInMemory.DTOs;

namespace CacheInMemory.Services
{
    public interface ICarsService
    {
        Task CreateCarAsync(CarCreateDTO car);
        Task DeleteCarAsync(int cardId, CarCreateDTO car);
        Task<List<CarReadDTO>> GetCarsAsync();
        Task<List<CarReadDTO>> GetCarsByParamsAsync(CarSearchingDTO carSearching);
        Task UpdateCarAsync(int cardId, CarUpdateDTO car);
    }
}