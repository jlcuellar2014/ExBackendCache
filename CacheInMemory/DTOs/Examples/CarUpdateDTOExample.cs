using Swashbuckle.AspNetCore.Filters;

namespace CacheInMemory.DTOs.Examples
{
    public class CarUpdateDTOExample : IExamplesProvider<CarUpdateDTO>
    {
        CarUpdateDTO IExamplesProvider<CarUpdateDTO>.GetExamples()
        {
            return new CarUpdateDTO
            {
                BranchId = 1,
                CountryCode = "ES",
                Name = "EQS Berlina",
                Description = "La elegancia de un coupé unida a la espaciosidad de una berlina."
            };
        }
    }
}
