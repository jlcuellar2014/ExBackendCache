using CacheInMemory.Model;

namespace CacheInMemory.Services
{
    public interface ICountriesService
    {
        Task<List<Country>> GetCountriesAsync();
    }
}