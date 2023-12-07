using CacheInMemory.DTOs;
using CacheInMemory.Model;

namespace CacheInMemory.Services
{
    public interface ICountriesService
    {
        List<CountryReadDTO> GetCountries();
    }
}