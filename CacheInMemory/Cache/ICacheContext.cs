using CacheInMemory.Model;

namespace CacheInMemory.Cache
{
    public interface ICacheContext
    {
        void CleanBranchesCache();
        void CleanCarsCache();
        void CleanCountriesCache();
        void CleanRegisteredCarCache();
        Task<List<Branch>> GetBranchesAsync();
        Task<List<Car>> GetAsync();
        Task<List<Country>> GetCountriesAsync();
        Task<List<RegisteredCar>> GetRegisteredCarsAsync();
    }
}