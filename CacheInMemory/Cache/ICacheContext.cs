using CacheInMemory.Model;

namespace CacheInMemory.Cache
{
    public interface ICacheContext
    {
        List<Country> Countries { get; set; }
    }
}