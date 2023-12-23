using CacheInMemory.Cache;
using CacheInMemory.Model;
using CacheInMemory.Tests.Utils;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Moq;

namespace CacheInMemory.Tests.Cache
{
    public class CacheContextTests
    {
        private Mock<IDataContext> mockDbContext;
        private Mock<IConfiguration> mockConfig;

        public CacheContextTests()
        {
            mockConfig = new Mock<IConfiguration>();
            mockDbContext = new Mock<IDataContext>();
        }

        [Fact]
        public async Task Cache_Die_InTime()
        {
        }

            [Fact]
        public async Task GetCountries_FromDbContext_ValidAsync()
        {
            // Arrange
            var cacheLiveInMin = 1;
            using var fakeDbContext = new FakeDataContext();
            using var memoryCache = new MemoryCache(new MemoryCacheOptions());

            fakeDbContext.Countries.Add(new Country { CountryCode = "UK", CountryName = "United Kindom" });
            fakeDbContext.SaveChanges();

            mockDbContext.Setup(x => x.Countries).Returns(fakeDbContext.Countries);
            mockConfig.Setup(x => x["Cache:LiveInMinutes"]).Returns(cacheLiveInMin.ToString());

            var cache = new CacheContext(memoryCache, mockDbContext.Object, mockConfig.Object);

            // Act & Assert

            Assert.Null(memoryCache.Get("Country"));

            await cache.GetCountriesAsync();

            Assert.NotNull(memoryCache.Get("Country"));
        }
    }
}
