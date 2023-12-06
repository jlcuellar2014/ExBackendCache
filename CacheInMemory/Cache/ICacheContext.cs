using CacheInMemory.Model;

namespace CacheInMemory.Cache
{
    public interface ICacheContext
    {
        List<Country> Countries { get; set; }
        List<Branch> Branches { get; set; }
    }
}