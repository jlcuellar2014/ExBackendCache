using CacheInMemory.Cache;
using CacheInMemory.DTOs;
using CacheInMemory.Model;

namespace CacheInMemory.Repositories
{
    public class CarsRepository(ICacheContext cache, IDataContext data) : ICarsRepository
    {
        public async Task<List<Car>> GetAsync()
            => await cache.GetAsync();

        public async Task<List<Car>> GetByParamsAsync(CarSearchingDTO carSearching)
        {
            IEnumerable<Car> query = await cache.GetAsync();

            if (carSearching.CarId.GetValueOrDefault() > 0)
            {
                query = query.Where(x => x.CarId
                             .Equals(carSearching.CarId));
            }

            if (carSearching.BranchId.GetValueOrDefault() > 0)
            {
                query = query.Where(x => x.BranchId
                             .Equals(carSearching.BranchId));
            }

            if (carSearching.CarName != null)
            {
                query = query.Where(x => x.Name.ToUpper()
                             .Contains(carSearching.CarName.ToUpper()));
            }

            if (carSearching.CarDescription != null)
            {
                query = query.Where(x => (x.Description ?? string.Empty)
                             .Contains(carSearching.CarDescription.ToUpper()));
            }

            if (carSearching.BranchName != null)
            {
                var branches = await cache.GetBranchesAsync();
                query = query.Where(x
                    => (branches
                             .Where(b => b.Name.ToUpper().Contains(carSearching.BranchName.ToUpper()))
                             .Select(b => b.BranchId)
                        )
                        .Any(branchId => branchId.Equals(x.BranchId))
                    );
            }

            if (carSearching.CountryCode != null)
            {
                query = query.Where(x => x.CountryCode
                             .Contains(carSearching.CountryCode.ToUpper()));
            }

            if (carSearching.CountryName != null)
            {
                var countrie = await cache.GetCountriesAsync();
                query = query.Where(x
                    => (countrie
                             .Where(b => b.CountryName.ToUpper().Contains(carSearching.CountryName.ToUpper()))
                             .Select(b => b.CountryCode)
                        )
                        .Any(countryCode => countryCode.Equals(x.CountryCode))
                    );
            }

            return query.ToList();
        }

        public async Task CreateAsync(Car car)
        {
            try
            {
                data.Cars.Add(car);

                await data.SaveChangesAsync();

                cache.CleanCarsCache();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(int cardId, Car car)
        {
            try
            {
                var oldCar = data.Cars.Find(cardId) ??
                    throw new ArgumentException("There is no car with this identification.", nameof(cardId));

                if (car.Name != null)
                    oldCar.Name = car.Name ?? string.Empty;

                if (car.Description != null)
                    oldCar.Description = car.Description;

                if (car.BranchId > 0)
                    oldCar.BranchId = car.BranchId;

                if (car.CountryCode != null)
                    oldCar.CountryCode = car.CountryCode ?? string.Empty;

                await data.SaveChangesAsync();

                cache.CleanCarsCache();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync(int cardId)
        {
            try
            {
                var oldCar = data.Cars.Find(cardId) ??
                  throw new ArgumentException("There is no car with this identification.", nameof(cardId));

                data.Cars.Remove(oldCar);

                await data.SaveChangesAsync();

                cache.CleanCarsCache();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
