using CacheInMemory.Cache;
using CacheInMemory.DTOs;
using CacheInMemory.Model;

namespace CacheInMemory.Services
{
    public class RegisteredCarsService(ICacheContext cache, IDataContext data) : IRegisteredCarsService
    {
        public async Task<List<RegisteredCarReadDTO>> GetRegisteredCarsAsync()
        {
            IEnumerable<RegisteredCar> registries = await cache.GetRegisteredCarsAsync();

            if (!registries.Any())
                return [];

            var cars = await cache.GetCarsAsync();
            var branches = await cache.GetBranchesAsync();

            var data = from r in registries
                       join c in cars on r.CarId equals c.CarId
                       join b in branches on c.BranchId equals b.BranchId
                       select new RegisteredCarReadDTO
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

        public async Task CreateRegisteredCarAsync(RegisteredCarCreateDTO registeredCar)
        {
            try
            {
                data.RegisteredCars.Add(new RegisteredCar
                {
                    CountryCode = registeredCar.CountryCode,
                    Owner = registeredCar.Owner,
                    RegistrationNumber = registeredCar.RegistrationNumber,
                    CarId = registeredCar.CarId
                });

                await data.SaveChangesAsync();
                cache.CleanRegisteredCarCache();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateRegisteredCarAsync(int idRegisteredCar, RegisteredCarUpdateDTO registeredCar)
        {
            try
            {
                var oldRegisteredCar = data.RegisteredCars.Find(idRegisteredCar)
                    ?? throw new ArgumentException("There is no registry with this identification.", nameof(idRegisteredCar));

                if (registeredCar.Owner != null)
                    oldRegisteredCar.Owner = registeredCar.Owner;

                if (registeredCar.RegistrationNumber != null)
                    oldRegisteredCar.RegistrationNumber = registeredCar.RegistrationNumber;

                if (registeredCar.CarId != null)
                    oldRegisteredCar.CarId = registeredCar.CarId ?? 0;

                if (registeredCar.CountryCode != null)
                    oldRegisteredCar.CountryCode = registeredCar.CountryCode;

                await data.SaveChangesAsync();
                cache.CleanRegisteredCarCache();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteRegisteredCarAsync(int idRegisteredCar)
        {
            try
            {
                var oldRegisteredCar = data.RegisteredCars.Find(idRegisteredCar)
                    ?? throw new ArgumentException("There is no registry with this identification.", nameof(idRegisteredCar));

                data.RegisteredCars.Remove(oldRegisteredCar);

                await data.SaveChangesAsync();
                cache.CleanRegisteredCarCache();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
