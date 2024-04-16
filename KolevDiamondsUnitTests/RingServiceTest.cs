using KolevDiamonds.Core.Models.Ring;
using KolevDiamonds.Core.Services.Ring;
using KolevDiamonds.Infrastructure.Data.Common;
using KolevDiamonds.Infrastructure.Data.Models;
using Microsoft.Extensions.Logging;
using MockQueryable.Moq;
using Moq;
using KolevDiamonds.Infrastructure.Enums;

namespace KolevDiamondsUnitTests
{
    [TestFixture]
    public class RingServiceTests
    {
        private RingService _ringService;
        private Mock<IRepository> _mockRepository;
        private Mock<ILogger<RingService>> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();
            _mockLogger = new Mock<ILogger<RingService>>();
            _ringService = new RingService(_mockRepository.Object, _mockLogger.Object);
        }

        [Test]
        public async Task GetByIdAsync_ReturnsCorrectRing()
        {
            // Arrange
            int id = 2;
            var rings = new List<Ring>
            {
               new Ring { Id = 1, Name = "Ring 1", Price = 100 },
               new Ring { Id = 2, Name = "Ring 2", Price = 200 },
               new Ring { Id = 3, Name = "Ring 3", Price = 300 }
            };
            var data = rings.AsQueryable().BuildMock();
            _mockRepository.Setup(r => r.AllReadOnly<Ring>())
                           .Returns(data);

            // Act
            var result = await _ringService.GetByIdAsync(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.Name, Is.EqualTo("Ring 2"));
            Assert.That(result.Price, Is.EqualTo(200));
        }

        [Test]
        public async Task GetFilteredRingsAsync_ReturnsFilteredRings()
        {
            // Arrange
            decimal priceFilter = 200;
            int currentPage = 1;
            int productsPerPage = 10;
            bool isForSale = true;
            var rings = new List<Ring>
            {
                new Ring { Id = 1, Name = "Ring 1", Price = 100, IsForSale = true },
                new Ring { Id = 2, Name = "Ring 2", Price = 300, IsForSale = true },
                new Ring { Id = 3, Name = "Ring 3", Price = 150, IsForSale = true },
                new Ring { Id = 4, Name = "Ring 4", Price = 250, IsForSale = false }
            };
            var data = rings.AsQueryable().BuildMock();
            _mockRepository.Setup(r => r.AllReadOnly<Ring>())
                           .Returns(data);

            // Act
            var result = await _ringService.GetFilteredRingsAsync(priceFilter, currentPage, productsPerPage, isForSale);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Products.Count(), Is.EqualTo(2));
            Assert.That(result.TotalProductCount, Is.EqualTo(2));
        }

        [Test]
        public async Task GetByIdAsyncAsTracking_ReturnsCorrectNecklace()
        {
            // Arrange
            int id = 1;
            var ring = new Ring { Id = id, Name = "Ring 1", Price = 100 };
            var data = new List<Ring> { ring }.AsQueryable().BuildMock();
            _mockRepository.Setup(r => r.All<Ring>())
                           .Returns(data);

            // Act
            var result = await _ringService.GetByIdAsyncAsTracking(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.Name, Is.EqualTo("Ring 1"));
            Assert.That(result.Price, Is.EqualTo(100));
        }

        [Test]
        public async Task Delete_SetsRingNotForSale()
        {
            // Arrange
            int ringId = 1;
            var ring = new Ring { Id = ringId, Name = "Ring 1", IsForSale = true };
            var data = new List<Ring> { ring }.AsQueryable().BuildMock();
            _mockRepository.Setup(r => r.All<Ring>())
                           .Returns(data);

            // Act
            await _ringService.Delete(ringId);

            // Assert
            Assert.IsFalse(ring.IsForSale);
        }

        [Test]
        public async Task Create_AddsRingToRepository()
        {
            // Arrange
            var model = new RingModel
            {
                Name = "New Ring",
                ImagePath = "path/to/image",
                Price = 200,
                Carats = 1.5,
                Colour = DiamondColor.Q,
                Clarity = DiamondClarity.I3,
                Cut = DiamondCut.Excellent,
                Metal = MetalVariation.Silver,
                Purity = "18K",
                IsForSale = true
            };

            // Act
            await _ringService.Create(model);

            // Assert
            _mockRepository.Verify(r => r.AddAsync(It.IsAny<Ring>()), Times.Once);
            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task Update_UpdatesRingInRepository()
        {
            // Arrange
            int id = 1;
            var model = new RingModel
            {
                Name = "Updated Ring",
                ImagePath = "path/to/updated/image",
                Price = 300,
                Carats = 2.0,
                Colour = DiamondColor.R,
                Clarity = DiamondClarity.VVS1,
                Cut = DiamondCut.VeryGood,
                Metal = MetalVariation.Gold,
                Purity = "24K",
                IsForSale = true
            };

            var existingRing = new Ring
            {
                Id = id,
                Name = "Existing Ring",
                ImagePath = "path/to/image",
                Price = 200,
                Carats = 1.5,
                Colour = DiamondColor.Q,
                Clarity = DiamondClarity.I3,
                Cut = DiamondCut.Excellent,
                Metal = MetalVariation.Silver,
                Purity = "18K",
                IsForSale = true
            };

            var data = new List<Ring> { existingRing }.AsQueryable().BuildMock();
            _mockRepository.Setup(r => r.All<Ring>())
                           .Returns(data);

            // Act
            await _ringService.Update(id, model);

            // Assert
            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
            Assert.That(existingRing.Name, Is.EqualTo(model.Name));
            Assert.That(existingRing.ImagePath, Is.EqualTo(model.ImagePath));
            Assert.That(existingRing.Price, Is.EqualTo(model.Price));
            Assert.That(existingRing.Carats, Is.EqualTo(model.Carats));
            Assert.That(existingRing.Colour, Is.EqualTo(model.Colour));
            Assert.That(existingRing.Clarity, Is.EqualTo(model.Clarity));
            Assert.That(existingRing.Cut, Is.EqualTo(model.Cut));
            Assert.That(existingRing.Metal, Is.EqualTo(model.Metal));
            Assert.That(existingRing.Purity, Is.EqualTo(model.Purity));
            Assert.That(existingRing.IsForSale, Is.EqualTo(model.IsForSale));
        }
    }
}
