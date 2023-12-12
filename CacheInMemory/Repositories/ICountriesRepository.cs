using CacheInMemory.Model;

namespace CacheInMemory.Repositories
{
    public interface ICountriesRepository
    {
        Task<List<Country>> GetAsync();
    }
}