using CacheInMemory.Cache;
using CacheInMemory.Model;

namespace CacheInMemory.Services
{
    public class CountriesService(ICacheContext cache) : ICountriesService
    {
        public async Task<List<Country>> GetCountriesAsync() => cache.Countries;
    }
}
