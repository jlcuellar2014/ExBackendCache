using CacheInMemory.DTOs;
using CacheInMemory.Model;

namespace CacheInMemory.Repositories
{
    public interface ICarsRepository
    {
        Task CreateAsync(Car car);
        Task DeleteAsync(int cardId);
        Task<List<Car>> GetAsync();
        Task<List<Car>> GetByParamsAsync(CarSearchingDTO carSearching);
        Task UpdateAsync(int cardId, Car car);
    }
}