using CacheInMemory.Model;

namespace CacheInMemory.Cache
{
    public interface ICacheContext
    {
        void ResetBranches();
        void ResetCars();
        void ResetCountries();
        void ResetRegisteredCars();
        Task<List<Branch>> GetBranchesAsync();
        Task<List<Car>> GetCarsAsync();
        Task<List<Country>> GetCountriesAsync();
        Task<List<RegisteredCar>> GetAsync();
    }
}