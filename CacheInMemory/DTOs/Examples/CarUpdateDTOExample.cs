using Swashbuckle.AspNetCore.Filters;

namespace CacheInMemory.DTOs.Examples
{
    public class CarUpdateDTOExample : IExamplesProvider<CarUpdateDTO>
    {
        public CarUpdateDTO GetExamples()
        {
            return new CarUpdateDTO()
            {
                BranchId = 1,
                CountryCode = "FR",
                Name = "Sedan 505",
                Description = "Sedan Mercedes Benz"
            };
        }
    }
}
