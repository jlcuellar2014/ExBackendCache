using CacheInMemory.Model;
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
        public List<Car> Cars
        {
            get
            {
                cars = GetDataFromCache<Car>(cars, () => dbContext.Cars.ToList());
                return cars ?? [];
            }
        }
        public List<RegisteredCar> RegisteredCars
        {
            get
            {
                registeredCars = GetDataFromCache<RegisteredCar>(registeredCars, () => dbContext.RegisteredCars.ToList());
                return registeredCars ?? [];
            }
        }

        public void CleanCountriesCache() => cache.Remove(nameof(Country));
        public void CleanBranchesCache() => cache.Remove(nameof(Branch));
        public void CleanCarsCache() => cache.Remove(nameof(Car));
        public void CleanRegisteredCarCache() => cache.Remove(nameof(RegisteredCar));

        private List<T>? GetDataFromCache<T>(List<T>? collection,  Func<List<T>?> func)
        {
            var key = typeof(T).Name;

            if (!cache.TryGetValue(key, out string? dataInCache))
            {
                collection = func.Invoke() ?? [];

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
