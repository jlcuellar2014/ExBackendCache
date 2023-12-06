using CacheInMemory.Model;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace CacheInMemory.Cache
{
    public class CacheContext(IMemoryCache cache, IDataContext dbContext, IConfiguration configuration) : ICacheContext
    {
        private static List<Country>? countries;

        public List<Country> Countries
        {
            get => GetCountries() ?? [];
            set => countries = value;
        }

        private List<Country>? GetCountries()
        {
            var key = "countries";

            if (!cache.TryGetValue(key, out string? countriesInCache))
            {
                countries = [.. dbContext.Countries];

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(
                        double.TryParse(configuration["Cache:LiveInMinutes"], out double time) ? time : 10)
                };

                var data = JsonSerializer.Serialize<List<Country>>(countries);

                cache.Set(key, data, cacheEntryOptions);

                return countries;
            }

            countries ??= JsonSerializer.Deserialize<List<Country>>(countriesInCache ?? string.Empty);

            return countries;
        }
    }
}
