using CacheInMemory.Cache;
using CacheInMemory.DTOs;
using CacheInMemory.Model;
using Mapster;

namespace CacheInMemory.Services
{
    public class CountriesService(ICacheContext cache) : ICountriesService
    {
        public List<CountryReadDTO> GetCountries() => cache.Countries.Adapt<List<CountryReadDTO>>();
    }
}
