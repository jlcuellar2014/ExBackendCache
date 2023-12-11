using CacheInMemory.DTOs;

namespace CacheInMemory.Services
{
    public interface ICountriesService
    {
        Task<List<CountryReadDTO>> GetCountriesAsync();
    }
}