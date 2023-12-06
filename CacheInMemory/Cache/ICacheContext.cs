using CacheInMemory.Model;

namespace CacheInMemory.Cache
{
    public interface ICacheContext
    {
        List<Country> Countries { get; }
        List<Branch> Branches { get; }

        void CleanCountriesCache();
        void CleanBranchesCache();
    }
}