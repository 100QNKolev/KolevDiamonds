using KolevDiamonds.Core.Models.InvestmentCoin;
using KolevDiamonds.Core.Services.InvestmentCoin;
using KolevDiamonds.Infrastructure.Data.Common;
using KolevDiamonds.Infrastructure.Data.Models;
using KolevDiamonds.Infrastructure.Enums;
using Microsoft.Extensions.Logging;
using MockQueryable.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace KolevDiamondsUnitTests
{
    [TestFixture]
    public class InvestmentCoinServiceTests
    {
        private InvestmentCoinService _investmentCoinService;
        private Mock<IRepository> _mockRepository;
        private Mock<ILogger<InvestmentCoinService>> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();
            _mockLogger = new Mock<ILogger<InvestmentCoinService>>();
            _investmentCoinService = new InvestmentCoinService(_mockRepository.Object, _mockLogger.Object);
        }

        [Test]
        public async Task GetByIdAsync_ReturnsCorrectInvestmentCoin()
        {
            // Arrange
            int id = 1;
            var coin = new InvestmentCoin { Id = id, Name = "Coin 1", Price = 100 };
            var data = new List<InvestmentCoin> { coin }.AsQueryable().BuildMock();
            _mockRepository.Setup(r => r.AllReadOnly<InvestmentCoin>())
                           .Returns(data);

            // Act
            var result = await _investmentCoinService.GetByIdAsync(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.Name, Is.EqualTo("Coin 1"));
            Assert.That(result.Price, Is.EqualTo(100));
        }

        [Test]
        public async Task GetByIdAsyncAsTracking_ReturnsCorrectInvestmentCoin()
        {
            // Arrange
            int id = 1;
            var coin = new InvestmentCoin { Id = id, Name = "Coin 1", Price = 100 };
            var data = new List<InvestmentCoin> { coin }.AsQueryable().BuildMock();
            _mockRepository.Setup(r => r.All<InvestmentCoin>())
                           .Returns(data);

            // Act
            var result = await _investmentCoinService.GetByIdAsyncAsTracking(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.Name, Is.EqualTo("Coin 1"));
            Assert.That(result.Price, Is.EqualTo(100));
        }

        [Test]
        public async Task GetFilteredInvestmentCoinsAsync_ReturnsFilteredInvestmentCoins()
        {
            // Arrange
            decimal priceFilter = 200;
            int currentPage = 1;
            int productsPerPage = 10;
            bool isForSale = true;
            var coins = new List<InvestmentCoin>
            {
                new InvestmentCoin { Id = 1, Name = "Coin 1", Price = 100, IsForSale = true },
                new InvestmentCoin { Id = 2, Name = "Coin 2", Price = 300, IsForSale = true },
                new InvestmentCoin { Id = 3, Name = "Coin 3", Price = 150, IsForSale = true },
                new InvestmentCoin { Id = 4, Name = "Coin 4", Price = 250, IsForSale = false }
            };
            var data = coins.AsQueryable().BuildMock();
            _mockRepository.Setup(r => r.AllReadOnly<InvestmentCoin>())
                           .Returns(data);

            // Act
            var result = await _investmentCoinService.GetFilteredInvestmentCoinsAsync(priceFilter, currentPage, productsPerPage, isForSale);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Products.Count(), Is.EqualTo(2));
            Assert.That(result.TotalProductCount, Is.EqualTo(2));
        }

        [Test]
        public async Task Delete_SetsInvestmentCoinNotForSale()
        {
            // Arrange
            int coinId = 1;
            var coin = new InvestmentCoin { Id = coinId, Name = "Coin 1", IsForSale = true };
            var data = new List<InvestmentCoin> { coin }.AsQueryable().BuildMock();
            _mockRepository.Setup(r => r.All<InvestmentCoin>())
                           .Returns(data);

            // Act
            await _investmentCoinService.Delete(coinId);

            // Assert
            Assert.IsFalse(coin.IsForSale);
        }

        [Test]
        public async Task Create_AddsInvestmentCoinToRepository()
        {
            // Arrange
            var model = new InvestmentCoinModel
            {
                Name = "New Coin",
                ImagePath = "path/to/image",
                Price = 200,
                Metal = MetalVariation.Gold,
                Purity = 23.3,
                Weight = 1,
                Quality = GoldQuality.MintState,
                Circulation = 1000,
                Diameter = 30,
                LegalTender = "USD",
                Manufacturer = "Mint",
                Packaging = "Box",
                IsForSale = true
            };

            // Act
            await _investmentCoinService.Create(model);

            // Assert
            _mockRepository.Verify(r => r.AddAsync(It.IsAny<InvestmentCoin>()), Times.Once);
            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task Update_UpdatesInvestmentCoinInRepository()
        {
            // Arrange
            int id = 1;
            var model = new InvestmentCoinModel
            {
                Name = "Updated Coin",
                ImagePath = "path/to/updated/image",
                Price = 300,
                Metal = MetalVariation.Silver,
                Purity = 24.0,
                Weight = 2,
                Quality = GoldQuality.BrilliantUncirculated,
                Circulation = 2000,
                Diameter = 35,
                LegalTender = "EUR",
                Manufacturer = "Mint Updated",
                Packaging = "Capsule",
                IsForSale = true
            };

            var existingCoin = new InvestmentCoin
            {
                Id = id,
                Name = "Existing Coin",
                ImagePath = "path/to/image",
                Price = 200,
                Metal = MetalVariation.Gold,
                Purity = 22.0,
                Weight = 1,
                Quality = GoldQuality.Fine,
                Circulation = 1000,
                Diameter = 30,
                LegalTender = "USD",
                Manufacturer = "Mint",
                Packaging = "Box",
                IsForSale = true
            };

            var data = new List<InvestmentCoin> { existingCoin }.AsQueryable().BuildMock();
            _mockRepository.Setup(r => r.All<InvestmentCoin>())
                           .Returns(data);

            // Act
            await _investmentCoinService.Update(id, model);

            // Assert
            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
            Assert.That(existingCoin.Name, Is.EqualTo(model.Name));
            Assert.That(existingCoin.ImagePath, Is.EqualTo(model.ImagePath));
            Assert.That(existingCoin.Price, Is.EqualTo(model.Price));
            Assert.That(existingCoin.Metal, Is.EqualTo(model.Metal));
            Assert.That(existingCoin.Purity, Is.EqualTo(model.Purity));
            Assert.That(existingCoin.Weight, Is.EqualTo(model.Weight));
            Assert.That(existingCoin.Quality, Is.EqualTo(model.Quality));
            Assert.That(existingCoin.Circulation, Is.EqualTo(model.Circulation));
            Assert.That(existingCoin.Diameter, Is.EqualTo(model.Diameter));
            Assert.That(existingCoin.LegalTender, Is.EqualTo(model.LegalTender));
            Assert.That(existingCoin.Manufacturer, Is.EqualTo(model.Manufacturer));
            Assert.That(existingCoin.Packaging, Is.EqualTo(model.Packaging));
            Assert.That(existingCoin.IsForSale, Is.EqualTo(model.IsForSale));
        }
    }
}
