using CacheInMemory.Helpers;

namespace CacheInMemoryTests.Helpers
{
    public class CountriesHelperTests
    {
        [Theory]
        [InlineData("Resources\\countries_es.csv")]
        public void CorrectFileTransformation(string filePath)
        {
           var countries = CountriesHelper.GetCountiesFromStaticCsv(filePath);

            Assert.Multiple(() =>
            {
                Assert.NotNull(countries);
                Assert.NotNull(countries?.Count.Equals(253));
            });
        }
    }
}
