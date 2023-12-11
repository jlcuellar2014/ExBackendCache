using Swashbuckle.AspNetCore.Filters;

namespace CacheInMemory.DTOs.Examples
{
    public class BranchCreateDTOExample : IExamplesProvider<BranchCreateDTO>
    {
        public BranchCreateDTO GetExamples()
        {
            return new BranchCreateDTO
            {
                Name = "Toyota",
                CountryCode = "JP",
                Description = "Japanise branch"
            };
        }
    }
}
