using Swashbuckle.AspNetCore.Filters;

namespace CacheInMemory.DTOs.Examples
{
    public class BadRequestDTOExample : IExamplesProvider<BadRequestDTO>
    {
        public BadRequestDTO GetExamples()
        {
            return new BadRequestDTO { Message = "The request is invalid or missing required parameters." };
        }
    }
}
