using KolevDiamonds.Core.Models.MetalBar;
using KolevDiamonds.Core.Services.MetalBar;
using KolevDiamonds.Infrastructure.Data.Common;
using KolevDiamonds.Infrastructure.Data.Models;
using KolevDiamonds.Infrastructure.Enums;
using Microsoft.Extensions.Logging;
using MockQueryable.Moq;
using Moq;

namespace KolevDiamondsUnitTests
{
    [TestFixture]
    public class MetalBarServiceTests
    {
        private MetalBarService _metalBarService;
        private Mock<IRepository> _mockRepository;
        private Mock<ILogger<MetalBarService>> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();
            _mockLogger = new Mock<ILogger<MetalBarService>>();
            _metalBarService = new MetalBarService(_mockRepository.Object, _mockLogger.Object);
        }

        [Test]
        public async Task GetByIdAsync_ReturnsCorrectMetalBar()
        {
            // Arrange
            int id = 1;
            var metalBar = new MetalBar { Id = id, Name = "MetalBar 1", Price = 100 };
            var data = new List<MetalBar> { metalBar }.AsQueryable().BuildMock();
            _mockRepository.Setup(r => r.AllReadOnly<MetalBar>())
                           .Returns(data);

            // Act
            var result = await _metalBarService.GetByIdAsync(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.Name, Is.EqualTo("MetalBar 1"));
            Assert.That(result.Price, Is.EqualTo(100));
        }

        [Test]
        public async Task GetByIdAsyncAsTracking_ReturnsCorrectMetalBar()
        {
            // Arrange
            int id = 1;
            var metalBar = new MetalBar { Id = id, Name = "MetalBar 1", Price = 100 };
            var data = new List<MetalBar> { metalBar }.AsQueryable().BuildMock();
            _mockRepository.Setup(r => r.All<MetalBar>())
                           .Returns(data);

            // Act
            var result = await _metalBarService.GetByIdAsyncAsTracking(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.Name, Is.EqualTo("MetalBar 1"));
            Assert.That(result.Price, Is.EqualTo(100));
        }

        [Test]
        public async Task GetFilteredMetalBarsAsync_ReturnsFilteredMetalBars()
        {
            // Arrange
            decimal priceFilter = 200;
            int currentPage = 1;
            int productsPerPage = 10;
            bool isForSale = true;
            var metalBars = new List<MetalBar>
            {
                new MetalBar { Id = 1, Name = "MetalBar 1", Price = 100, IsForSale = true },
                new MetalBar { Id = 2, Name = "MetalBar 2", Price = 300, IsForSale = true },
                new MetalBar { Id = 3, Name = "MetalBar 3", Price = 150, IsForSale = true },
                new MetalBar { Id = 4, Name = "MetalBar 4", Price = 250, IsForSale = false }
            };
            var data = metalBars.AsQueryable().BuildMock();
            _mockRepository.Setup(r => r.AllReadOnly<MetalBar>())
                           .Returns(data);

            // Act
            var result = await _metalBarService.GetFilteredMetalBarsAsync(priceFilter, currentPage, productsPerPage, isForSale);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Products.Count(), Is.EqualTo(2));
            Assert.That(result.TotalProductCount, Is.EqualTo(2));
        }

        [Test]
        public async Task Delete_SetsMetalBarNotForSale()
        {
            // Arrange
            int metalBarId = 1;
            var metalBar = new MetalBar { Id = metalBarId, Name = "MetalBar 1", IsForSale = true };
            var data = new List<MetalBar> { metalBar }.AsQueryable().BuildMock();
            _mockRepository.Setup(r => r.All<MetalBar>())
                           .Returns(data);

            // Act
            await _metalBarService.Delete(metalBarId);

            // Assert
            Assert.IsFalse(metalBar.IsForSale);
        }

        [Test]
        public async Task Create_AddsMetalBarToRepository()
        {
            // Arrange
            var model = new MetalBarModel
            {
                Name = "New MetalBar",
                ImagePath = "path/to/image",
                Price = 200,
                Metal = MetalVariation.Silver,
                Purity = "18K",
                IsForSale = true,
                Weight = 50,
                Dimensions = "10x10x10"
            };

            // Act
            await _metalBarService.Create(model);

            // Assert
            _mockRepository.Verify(r => r.AddAsync(It.IsAny<MetalBar>()), Times.Once);
            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task Update_UpdatesMetalBarInRepository()
        {
            // Arrange
            int id = 1;
            var model = new MetalBarModel
            {
                Name = "Updated MetalBar",
                ImagePath = "path/to/updated/image",
                Price = 300,
                Metal = MetalVariation.Gold,
                Purity = "24K",
                IsForSale = true,
                Weight = 60,
                Dimensions = "12x12x12"
            };

            var existingMetalBar = new MetalBar
            {
                Id = id,
                Name = "Existing MetalBar",
                ImagePath = "path/to/image",
                Price = 200,
                Metal = MetalVariation.Silver,
                Purity = "18K",
                IsForSale = true,
                Weight = 50,
                Dimensions = "10x10x10"
            };

            var data = new List<MetalBar> { existingMetalBar }.AsQueryable().BuildMock();
            _mockRepository.Setup(r => r.All<MetalBar>())
                           .Returns(data);

            // Act
            await _metalBarService.Update(id, model);

            // Assert
            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
            Assert.That(existingMetalBar.Name, Is.EqualTo(model.Name));
            Assert.That(existingMetalBar.ImagePath, Is.EqualTo(model.ImagePath));
            Assert.That(existingMetalBar.Price, Is.EqualTo(model.Price));
            Assert.That(existingMetalBar.Metal, Is.EqualTo(model.Metal));
            Assert.That(existingMetalBar.Purity, Is.EqualTo(model.Purity));
            Assert.That(existingMetalBar.IsForSale, Is.EqualTo(model.IsForSale));
            Assert.That(existingMetalBar.Weight, Is.EqualTo(model.Weight));
            Assert.That(existingMetalBar.Dimensions, Is.EqualTo(model.Dimensions));
        }
    }
}
