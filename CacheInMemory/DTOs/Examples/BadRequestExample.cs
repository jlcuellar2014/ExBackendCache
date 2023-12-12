using Swashbuckle.AspNetCore.Filters;

namespace CacheInMemory.DTOs.Examples
{
    public class BadRequestExample : IExamplesProvider<string>
    {
        public string GetExamples()
        {
            return "Message";
        }
    }
}
