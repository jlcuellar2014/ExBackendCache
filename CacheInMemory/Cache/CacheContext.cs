using CacheInMemory.Model;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace CacheInMemory.Cache
{
    public class CacheContext(IMemoryCache cache, IDataContext dbContext, IConfiguration configuration) : ICacheContext
    {
        private List<Country>? countries;
        private List<Branch>? branches;

        public List<Country> Countries
        {
            get {
                LoadDataFromCache<Country>("countries", ref countries, () => dbContext.Countries.ToList());
                return countries ?? [];
            }
            set => countries = value;
        }

        public List<Branch> Branches
        {
            get
            {
                LoadDataFromCache<Branch>("branches", ref branches, () => dbContext.Branches.ToList());
                return branches ?? [];
            }
            set => branches = value;
        }

        private void LoadDataFromCache<T>(string key, ref List<T>? collection,  Func<List<T>?> func)
        {
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
            else
            {
                collection ??= JsonSerializer.Deserialize<List<T>>(dataInCache ?? string.Empty);
            }
        }
    }
}
