using CacheInMemory.DTOs;
using CacheInMemory.Model;
using CacheInMemory.Tests.Utils;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace CacheInMemory.Tests.IntegrationTests
{
    public class CountryIntegrationTests(
            FakeWebApplicationFactory<Program> factory
        )
        : IClassFixture<FakeWebApplicationFactory<Program>>
    {

        [Theory]
        [InlineData("/api/countries/is-alive")]
        public async Task Ok_IsAliveAsync(string url)
        {
            // Arrange
            using var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
        }

        [Theory]
        [InlineData("/api/countries")]
        public async Task GetAsync_HaveData_Valid(string url)
        {
            // Arrange
            using var client = factory.CreateClient();

            using var scope = factory.Services.CreateScope();
            using var dbContext = (FakeDataContext)scope.ServiceProvider.GetRequiredService<IDataContext>();

            dbContext.Countries.Add(new Country { CountryCode = "DE", CountryName = "Germany" });
            await dbContext.SaveChangesAsync();

            // Act
            var response = await client.GetAsync(url);

            var results = response.Content.ReadAsStringAsync().Result;
            var newList = JsonSerializer
                .Deserialize<List<CountryReadDTO>>(results, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
           
            Assert.NotNull(newList);
            Assert.Single(newList);
        }
    }
}
