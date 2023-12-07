using CacheInMemory.DTOs;

namespace CacheInMemory.Services
{
    public interface ICarsService
    {
        Task CreateCarAsync(CarCreateDTO car);
        Task DeleteCarAsync(int cardId, CarCreateDTO car);
        List<CarReadDTO> GetCars();
        List<CarReadDTO> GetCarsByParams(CarSearchingDTO carSearching);
        Task UpdateCarAsync(int cardId, CarUpdateDTO car);
    }
}