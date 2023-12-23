using Swashbuckle.AspNetCore.Filters;

namespace CacheInMemory.DTOs.Examples
{
    public class CarCreateDTOExample : IExamplesProvider<CarCreateDTO>
    {
        CarCreateDTO IExamplesProvider<CarCreateDTO>.GetExamples()
        {
            return new CarCreateDTO
            {
                BranchId = 1,
                CountryCode = "ES",
                Name = "EQS Berlina",
                Description = "La elegancia de un coupé unida a la espaciosidad de una berlina."
            };
        }
    }
}
