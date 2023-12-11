using CacheInMemory.Cache;
using CacheInMemory.DTOs;
using CacheInMemory.Model;
using Mapster;

namespace CacheInMemory.Services
{
    public class CarsService(ICacheContext cache, IDataContext data) : ICarsService
    {
        public async Task<List<CarReadDTO>> GetCarsAsync()
        {
            var cars = await cache.GetCarsAsync();
            return cars.Adapt<List<CarReadDTO>>();
        }

        public async Task<List<CarReadDTO>> GetCarsByParamsAsync(CarSearchingDTO carSearching)
        {
            IEnumerable<Car> query = await cache.GetCarsAsync();

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

            return query.ToList().Adapt<List<CarReadDTO>>();
        }

        public async Task CreateCarAsync(CarCreateDTO car)
        {
            try
            {
                var newCar = new Car
                {
                    BranchId = car.BranchId,
                    Name = car.Name,
                    CountryCode = car.CountryCode,
                    Description = car.Description,
                };

                data.Cars.Add(newCar);
                await data.SaveChangesAsync();

                cache.CleanCarsCache();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateCarAsync(int cardId, CarUpdateDTO car)
        {
            try
            {
                var oldCar = data.Cars.Find(cardId) ??
                    throw new ArgumentException("There is no car with this identification.", nameof(cardId));

                if (car.Name != null)
                    oldCar.Name = car.Name ?? string.Empty;

                if (car.Description != null)
                    oldCar.Description = car.Description;

                if (car.BranchId != null)
                    oldCar.BranchId = car.BranchId ?? 0;

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

        public async Task DeleteCarAsync(int cardId, CarCreateDTO car)
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
