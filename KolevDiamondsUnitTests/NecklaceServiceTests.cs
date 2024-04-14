﻿using KolevDiamonds.Core.Models.Necklace;
using KolevDiamonds.Core.Services.Necklace;
using KolevDiamonds.Infrastructure.Data.Common;
using KolevDiamonds.Infrastructure.Data.Models;
using Microsoft.Extensions.Logging;
using MockQueryable.Moq;
using Moq;
using KolevDiamonds.Infrastructure.Enums;

namespace KolevDiamondsUnitTests
{
    [TestFixture]
    public class NecklaceServiceTests
    {
        private NecklaceService _necklaceService;
        private Mock<IRepository> _mockRepository;
        private Mock<ILogger<NecklaceService>> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();
            _mockLogger = new Mock<ILogger<NecklaceService>>();
            _necklaceService = new NecklaceService(_mockRepository.Object, _mockLogger.Object);
        }

        [Test]
        public async Task GetByIdAsync_ReturnsCorrectNecklace()
        {
            // Arrange
            int id = 1;
            var necklace = new Necklace { Id = id, Name = "Necklace 1", Price = 100 };
            var data = new List<Necklace> { necklace }.AsQueryable().BuildMock();
            _mockRepository.Setup(r => r.AllReadOnly<Necklace>())
                           .Returns(data);

            // Act
            var result = await _necklaceService.GetByIdAsync(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.Name, Is.EqualTo("Necklace 1"));
            Assert.That(result.Price, Is.EqualTo(100));
        }

        [Test]
        public async Task GetByIdAsyncAsTracking_ReturnsCorrectNecklace()
        {
            // Arrange
            int id = 1;
            var necklace = new Necklace { Id = id, Name = "Necklace 1", Price = 100 };
            var data = new List<Necklace> { necklace }.AsQueryable().BuildMock();
            _mockRepository.Setup(r => r.All<Necklace>())
                           .Returns(data);

            // Act
            var result = await _necklaceService.GetByIdAsyncAsTracking(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.Name, Is.EqualTo("Necklace 1"));
            Assert.That(result.Price, Is.EqualTo(100));
        }

        [Test]
        public async Task GetFilteredNecklacesAsync_ReturnsFilteredNecklaces()
        {
            // Arrange
            decimal priceFilter = 200;
            int currentPage = 1;
            int productsPerPage = 10;
            bool isForSale = true;
            var necklaces = new List<Necklace>
            {
                new Necklace { Id = 1, Name = "Necklace 1", Price = 100, IsForSale = true },
                new Necklace { Id = 2, Name = "Necklace 2", Price = 300, IsForSale = true },
                new Necklace { Id = 3, Name = "Necklace 3", Price = 150, IsForSale = true },
                new Necklace { Id = 4, Name = "Necklace 4", Price = 250, IsForSale = false }
            };
            var data = necklaces.AsQueryable().BuildMock();
            _mockRepository.Setup(r => r.AllReadOnly<Necklace>())
                           .Returns(data);

            // Act
            var result = await _necklaceService.GetFilteredNecklacesAsync(priceFilter, currentPage, productsPerPage, isForSale);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Products.Count(), Is.EqualTo(2));
            Assert.That(result.TotalProductCount, Is.EqualTo(2));
        }

        [Test]
        public async Task Delete_SetsNecklaceNotForSale()
        {
            // Arrange
            int necklaceId = 1;
            var necklace = new Necklace { Id = necklaceId, Name = "Necklace 1", IsForSale = true };
            var data = new List<Necklace> { necklace }.AsQueryable().BuildMock();
            _mockRepository.Setup(r => r.All<Necklace>())
                           .Returns(data);

            // Act
            await _necklaceService.Delete(necklaceId);

            // Assert
            Assert.IsFalse(necklace.IsForSale);
        }

        [Test]
        public async Task Create_AddsNecklaceToRepository()
        {
            // Arrange
            var model = new NecklaceModel
            {
                Name = "New Necklace",
                ImagePath = "path/to/image",
                Price = 200,
                Carats = 1.5,
                Colour = DiamondColor.W,
                Clarity = DiamondClarity.I1,
                Cut = DiamondCut.Excellent,
                Metal = MetalVariation.RoseGold,
                Purity = "18K",
                IsForSale = true,
                Length = 20
            };

            // Act
            await _necklaceService.Create(model);

            // Assert
            _mockRepository.Verify(r => r.AddAsync(It.IsAny<Necklace>()), Times.Once);
            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }
    }
}
