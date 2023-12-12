using Swashbuckle.AspNetCore.Filters;

namespace CacheInMemory.DTOs.Examples
{
    public class BranchUpdateDTOExample : IExamplesProvider<BranchUpdateDTO>
    {
        public BranchUpdateDTO GetExamples()
        {
            return new BranchUpdateDTO
            {
                Name = "Toyota",
                CountryCode = "JP",
                Description = "Japanise branch"
            };
        }
    }
}
