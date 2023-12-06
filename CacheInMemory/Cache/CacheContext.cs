using CacheInMemory.Model;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace CacheInMemory.Cache
{
    public class CacheContext(IMemoryCache cache, IDataContext dbContext, IConfiguration configuration) : ICacheContext
    {
        private static List<Country>? countries;
        private static List<Branch>? branches;

        public List<Country> Countries {
            get {
                countries = GetDataFromCache<Country>(countries, () => dbContext.Countries.ToList());
                return countries ?? [];
            } 
        }
        public List<Branch> Branches {
            get {
                branches = GetDataFromCache<Branch>(branches, () => dbContext.Branches.ToList());
                return branches ?? [];
            }
        }

        public void CleanCountriesCache() => cache.Remove(nameof(Country));
        public void CleanBranchesCache() => cache.Remove(nameof(Branch));

        private List<T>? GetDataFromCache<T>(List<T>? collection,  Func<List<T>?> func)
        {
            var key = nameof(T);

            if (!cache.TryGetValue(key, out string? dataInCache))
            {
                collection = func.Invoke() ?? [];

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(
                       double.TryParse(configuration["Cache:LiveInMinutes"], out double time) ? time : 10)
                };

                var data = JsonSerializer.Serialize(collection);

                cache.Set(key, data, cacheEntryOptions);
            }

            if (collection == null || !collection.Any())
            {
                collection = JsonSerializer.Deserialize<List<T>>(dataInCache ?? string.Empty);
            }

            return collection;
        }
    }
}
