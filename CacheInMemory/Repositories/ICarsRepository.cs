using CacheInMemory.Model;
using CacheInMemory.Records;

namespace CacheInMemory.Repositories
{
    public interface ICarsRepository
    {
        Task CreateAsync(Car car);
        Task DeleteAsync(int cardId);
        Task<List<Car>> GetAsync();
        Task<List<Car>> GetByParamsAsync(CarSearchingRecord carSearching);
        Task UpdateAsync(int cardId, Car car);
    }
}