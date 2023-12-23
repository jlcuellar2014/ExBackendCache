using CacheInMemory.Model;
using CacheInMemory.Repositories;
using Moq;
using CacheInMemory.Services;
using CacheInMemory.DTOs;
using Mapster;

namespace CacheInMemory.Tests.Services
{
    public class BranchesServiceUnitTests
    {

        [Fact]
        public async Task GetAsync_HaveData_Valid()
        {
            // Arrange
            var repoMock = new Mock<IBranchesRespository>();

            repoMock.Setup(x => x.GetAsync()).ReturnsAsync(new List<Branch> {
                new Branch
                {
                    BranchId = 1,
                    Name = "Mercedes-Benz",
                    CountryCode = "DE",
                    Description = "German Branch"
                },
                new Branch
                {
                    BranchId = 2,
                    Name = "Peugueot",
                    CountryCode = "FR",
                    Description = "French Branch"
                }
            });

            var service = new BranchesService(repoMock.Object);

            // Act
            var resp = await service.GetAsync();

            // Assert
            Assert.Multiple(() =>
            {
                repoMock.Verify(x => x.GetAsync(), Times.Once);
                Assert.Equal(2, resp.Count);
            });
        }

        [Fact]
        public async Task GetAsync_NotHaveData_Valid()
        {
            // Arrange
            var repoMock = new Mock<IBranchesRespository>();

            repoMock.Setup(x => x.GetAsync()).ReturnsAsync(new List<Branch>());

            var service = new BranchesService(repoMock.Object);

            // Act
            var resp = await service.GetAsync();

            // Assert
            Assert.Multiple(() =>
            {
                repoMock.Verify(x => x.GetAsync(), Times.Once);
                Assert.NotNull(resp);
                Assert.Empty(resp);
            });   
        }

        [Theory]
        [InlineData("Mercedes-Benz", "DE", "German Branch")]
        [InlineData("Mercedes-Benz", "DE", null)]
        public async Task CreateAsync_CorretData_Valid(string brachName, string countryCode, string? brachDescription)
        {
            // Arrange
            var newBrancheDTO = new BranchCreateDTO { 
                Name = brachName,
                CountryCode = countryCode,
                Description = brachDescription
            };

            var repoMock = new Mock<IBranchesRespository>();
            repoMock.Setup(x => x.CreateAsync(It.IsAny<Branch>()));

            var service = new BranchesService(repoMock.Object);

            // Act
            await service.CreateAsync(newBrancheDTO);

            // Assert
            repoMock.Verify(x => x.CreateAsync(It.IsAny<Branch>()), Times.Once);
        }
    }
}
