using CacheInMemory.DTOs;

namespace CacheInMemory.Services
{
    public interface ICarsService
    {
        Task CreateAsync(CarCreateDTO car);
        Task DeleteAsync(int cardId);
        Task<List<CarReadDTO>> GetAsync();
        Task<List<CarReadDTO>> GetByParamsAsync(CarSearchingDTO carSearching);
        Task UpdateAsync(int cardId, CarUpdateDTO car);
    }
}