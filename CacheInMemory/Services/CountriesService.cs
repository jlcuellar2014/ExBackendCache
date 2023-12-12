using CacheInMemory.DTOs;
using CacheInMemory.Repositories;
using Mapster;

namespace CacheInMemory.Services
{
    public class CountriesService(ICountriesRepository repo) : ICountriesService
    {
        public async Task<List<CountryReadDTO>> GetAsync()
        {
            var countrie = await repo.GetAsync();
            return countrie.Adapt<List<CountryReadDTO>>();
        }
    }
}
