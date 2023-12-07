using CacheInMemory.Model;

namespace CacheInMemory.Cache
{
    public interface ICacheContext
    {
        List<Country> Countries { get; }
        List<Branch> Branches { get; }
        List<Car> Cars { get; }
        List<RegisteredCar> RegisteredCars { get; }

        void CleanCountriesCache();
        void CleanBranchesCache();
        void CleanCarsCache();
        void CleanRegisteredCarCache();
    }
}