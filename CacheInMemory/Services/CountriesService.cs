using CacheInMemory.Cache;
using CacheInMemory.DTOs;
using Mapster;

namespace CacheInMemory.Services
{
    public class CountriesService(ICacheContext cache) : ICountriesService
    {
        public async Task<List<CountryReadDTO>> GetCountriesAsync()
        {
            var countrie = await cache.GetCountriesAsync();
            return countrie.Adapt<List<CountryReadDTO>>();
        }
    }
}
