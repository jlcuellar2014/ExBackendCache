using CacheInMemory.Cache;
using CacheInMemory.Model;

namespace CacheInMemory.Repositories
{
    public class CountriesRepository(ICacheContext cache) : ICountriesRepository
    {
        public async Task<List<Country>> GetAsync()
        => await cache.GetCountriesAsync();
    }
}
