using Swashbuckle.AspNetCore.Filters;

namespace CacheInMemory.DTOs.Examples
{
    public class CarSearchingDTOExample : IExamplesProvider<CarSearchingDTO>
    {
        public CarSearchingDTO GetExamples()
        {
            return new CarSearchingDTO
            {
                BranchId = 1,
                BranchName = "DE",
                CarId = 1,
                CarName = "Berlina",
                CarDescription = "Berlina",
                CountryCode = "De",
                CountryName = "Alemania"
            };
        }
    }
}
