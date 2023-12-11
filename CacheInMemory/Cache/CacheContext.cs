using CacheInMemory.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace CacheInMemory.Cache
{
    public class CacheContext(IMemoryCache cache, IDataContext dbContext, IConfiguration configuration) : ICacheContext
    {
        private static List<Country>? countries;
        private static List<Branch>? branches;
        private static List<Car>? cars;
        private static List<RegisteredCar>? registeredCars;

        public async Task<List<Country>> GetCountriesAsync()
        {
            countries = await GetDataFromCacheAsync<Country>(countries, dbContext.Countries);
            return countries ?? [];
        }
        public async Task<List<Branch>> GetBranchesAsync()
        {
            branches = await GetDataFromCacheAsync<Branch>(branches, dbContext.Branches);
            return branches ?? [];
        }
        public async Task<List<Car>> GetCarsAsync()
        {
            cars = await GetDataFromCacheAsync<Car>(cars, dbContext.Cars);
            return cars ?? [];
        }
        public async Task<List<RegisteredCar>> GetRegisteredCarsAsync()
        {
            registeredCars = await GetDataFromCacheAsync<RegisteredCar>(registeredCars, dbContext.RegisteredCars);
            return registeredCars ?? [];
        }

        public void CleanCountriesCache() => cache.Remove(nameof(Country));
        public void CleanBranchesCache() => cache.Remove(nameof(Branch));
        public void CleanCarsCache() => cache.Remove(nameof(Car));
        public void CleanRegisteredCarCache() => cache.Remove(nameof(RegisteredCar));

        private async Task<List<T>?> GetDataFromCacheAsync<T>(List<T>? collection, DbSet<T> values) where T : class
        {
            var key = typeof(T).Name;

            if (!cache.TryGetValue(key, out string? dataInCache))
            {
                collection = await values.ToListAsync();

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(
                       double.TryParse(configuration["Cache:LiveInMinutes"], out double time) ? time : 10)
                };

                if (collection.Any())
                {
                    var data = JsonSerializer.Serialize(collection);

                    cache.Set(key, data, cacheEntryOptions);
                }
            }

            if (collection == null || !collection.Any())
            {
                string data = dataInCache ?? string.Empty;

                collection = data.Any() ? JsonSerializer.Deserialize<List<T>>(data) : [];
            }

            return collection;
        }
    }
}
