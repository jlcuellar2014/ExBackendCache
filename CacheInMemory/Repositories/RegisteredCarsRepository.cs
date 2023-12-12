using CacheInMemory.Cache;
using CacheInMemory.Model;
using CacheInMemory.Records;

namespace CacheInMemory.Repositories
{
    public class RegisteredCarsRepository(ICacheContext cache, IDataContext data) : IRegisteredCarsRepository
    {
        public async Task<List<RegisteredCarRecord>> GetAsync()
        {
            IEnumerable<RegisteredCar> registries = await cache.GetAsync();

            if (!registries.Any())
                return [];

            var cars = await cache.GetCarsAsync();
            var branches = await cache.GetBranchesAsync();

            var data = from r in registries
                       join c in cars on r.CarId equals c.CarId
                       join b in branches on c.BranchId equals b.BranchId
                       select new RegisteredCarRecord
                       {
                           RegisteredCarId = r.RegisteredCarId,
                           RegistrationCountry = r.CountryCode,
                           RegistrationOwner = r.Owner,
                           RegistrationNumber = r.RegistrationNumber,
                           CarId = r.CarId,
                           CarName = c.Name,
                           CarDescription = c.Description,
                           CarCountry = c.CountryCode,
                           CarBranch = b.Name,
                           BranchCountry = b.CountryCode
                       };

            return data.ToList();
        }

        public async Task CreateAsync(RegisteredCar registeredCar)
        {
            try
            {
                data.RegisteredCars.Add(registeredCar);

                await data.SaveChangesAsync();

                cache.ResetRegisteredCars();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(int idRegisteredCar, RegisteredCar registeredCar)
        {
            try
            {
                var oldRegisteredCar = data.RegisteredCars.Find(idRegisteredCar)
                    ?? throw new ArgumentException("There is no registry with this identification.", nameof(idRegisteredCar));

                if (registeredCar.Owner != null)
                    oldRegisteredCar.Owner = registeredCar.Owner;

                if (registeredCar.RegistrationNumber != null)
                    oldRegisteredCar.RegistrationNumber = registeredCar.RegistrationNumber;

                if (registeredCar.CarId > 0)
                    oldRegisteredCar.CarId = registeredCar.CarId;

                if (registeredCar.CountryCode != null)
                    oldRegisteredCar.CountryCode = registeredCar.CountryCode;

                await data.SaveChangesAsync();
                cache.ResetRegisteredCars();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync(int idRegisteredCar)
        {
            try
            {
                var oldRegisteredCar = data.RegisteredCars.Find(idRegisteredCar)
                    ?? throw new ArgumentException("There is no registry with this identification.", nameof(idRegisteredCar));

                data.RegisteredCars.Remove(oldRegisteredCar);

                await data.SaveChangesAsync();
                cache.ResetRegisteredCars();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
