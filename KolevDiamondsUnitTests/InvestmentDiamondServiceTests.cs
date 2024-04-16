using KolevDiamonds.Core.Models.InvestmentDiamond;
using KolevDiamonds.Core.Services.InvestmentDiamond;
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
    public class InvestmentDiamondServiceTests
    {
        private InvestmentDiamondService _investmentDiamondService;
        private Mock<IRepository> _mockRepository;
        private Mock<ILogger<InvestmentDiamondService>> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();
            _mockLogger = new Mock<ILogger<InvestmentDiamondService>>();
            _investmentDiamondService = new InvestmentDiamondService(_mockRepository.Object, _mockLogger.Object);
        }

        [Test]
        public async Task GetByIdAsync_ReturnsCorrectInvestmentDiamond()
        {
            // Arrange
            int id = 1;
            var diamond = new InvestmentDiamond { Id = id, Name = "Diamond 1", Price = 100 };
            var data = new List<InvestmentDiamond> { diamond }.AsQueryable().BuildMock();
            _mockRepository.Setup(r => r.AllReadOnly<InvestmentDiamond>())
                           .Returns(data);

            // Act
            var result = await _investmentDiamondService.GetByIdAsync(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.Name, Is.EqualTo("Diamond 1"));
            Assert.That(result.Price, Is.EqualTo(100));
        }

        [Test]
        public async Task GetByIdAsyncAsTracking_ReturnsCorrectInvestmentDiamond()
        {
            // Arrange
            int id = 1;
            var diamond = new InvestmentDiamond { Id = id, Name = "Diamond 1", Price = 100 };
            var data = new List<InvestmentDiamond> { diamond }.AsQueryable().BuildMock();
            _mockRepository.Setup(r => r.All<InvestmentDiamond>())
                           .Returns(data);

            // Act
            var result = await _investmentDiamondService.GetByIdAsyncAsTracking(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.Name, Is.EqualTo("Diamond 1"));
            Assert.That(result.Price, Is.EqualTo(100));
        }

        [Test]
        public async Task GetFilteredInvestmentDiamondsAsync_ReturnsFilteredInvestmentDiamonds()
        {
            // Arrange
            decimal priceFilter = 200;
            int currentPage = 1;
            int productsPerPage = 10;
            bool isForSale = true;
            var diamonds = new List<InvestmentDiamond>
            {
                new InvestmentDiamond { Id = 1, Name = "Diamond 1", Price = 100, IsForSale = true },
                new InvestmentDiamond { Id = 2, Name = "Diamond 2", Price = 300, IsForSale = true },
                new InvestmentDiamond { Id = 3, Name = "Diamond 3", Price = 150, IsForSale = true },
                new InvestmentDiamond { Id = 4, Name = "Diamond 4", Price = 250, IsForSale = false }
            };
            var data = diamonds.AsQueryable().BuildMock();
            _mockRepository.Setup(r => r.AllReadOnly<InvestmentDiamond>())
                           .Returns(data);

            // Act
            var result = await _investmentDiamondService.GetFilteredInvestmentDiamondsAsync(priceFilter, currentPage, productsPerPage, isForSale);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Products.Count(), Is.EqualTo(2));
            Assert.That(result.TotalProductCount, Is.EqualTo(2));
        }

        [Test]
        public async Task Delete_SetsInvestmentDiamondNotForSale()
        {
            // Arrange
            int diamondId = 1;
            var diamond = new InvestmentDiamond { Id = diamondId, Name = "Diamond 1", IsForSale = true };
            var data = new List<InvestmentDiamond> { diamond }.AsQueryable().BuildMock();
            _mockRepository.Setup(r => r.All<InvestmentDiamond>())
                           .Returns(data);

            // Act
            await _investmentDiamondService.Delete(diamondId);

            // Assert
            Assert.IsFalse(diamond.IsForSale);
        }

        [Test]
        public async Task Create_AddsInvestmentDiamondToRepository()
        {
            // Arrange
            var model = new InvestmentDiamondModel
            {
                Name = "New Diamond",
                ImagePath = "path/to/image",
                Price = 200,
                Carats = 1.5,
                Colour = DiamondColor.W,
                Clarity = DiamondClarity.I1,
                Cut = DiamondCut.Good,
                CertifyingLaboratory = "GIA",
                Proportions = "Excellent",
                IsForSale = true
            };

            // Act
            await _investmentDiamondService.Create(model);

            // Assert
            _mockRepository.Verify(r => r.AddAsync(It.IsAny<InvestmentDiamond>()), Times.Once);
            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task Update_UpdatesInvestmentDiamondInRepository()
        {
            // Arrange
            int id = 1;
            var model = new InvestmentDiamondModel
            {
                Name = "Updated Diamond",
                ImagePath = "path/to/updated/image",
                Price = 300,
                Carats = 2.0,
                Colour = DiamondColor.D,
                Clarity = DiamondClarity.VVS1,
                Cut = DiamondCut.Excellent,
                CertifyingLaboratory = "AGS",
                Proportions = "Ideal",
                IsForSale = true
            };

            var existingDiamond = new InvestmentDiamond
            {
                Id = id,
                Name = "Existing Diamond",
                ImagePath = "path/to/image",
                Price = 200,
                Carats = 1.5,
                Colour = DiamondColor.F,
                Clarity = DiamondClarity.VS1,
                Cut = DiamondCut.VeryGood,
                CertifyingLaboratory = "GIA",
                Proportions = "Very Good",
                IsForSale = true
            };

            var data = new List<InvestmentDiamond> { existingDiamond }.AsQueryable().BuildMock();
            _mockRepository.Setup(r => r.All<InvestmentDiamond>())
                           .Returns(data);

            // Act
            await _investmentDiamondService.Update(id, model);

            // Assert
            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
            Assert.That(existingDiamond.Name, Is.EqualTo(model.Name));
            Assert.That(existingDiamond.ImagePath, Is.EqualTo(model.ImagePath));
            Assert.That(existingDiamond.Price, Is.EqualTo(model.Price));
            Assert.That(existingDiamond.Carats, Is.EqualTo(model.Carats));
            Assert.That(existingDiamond.Colour, Is.EqualTo(model.Colour));
            Assert.That(existingDiamond.Clarity, Is.EqualTo(model.Clarity));
            Assert.That(existingDiamond.Cut, Is.EqualTo(model.Cut));
            Assert.That(existingDiamond.CertifyingLaboratory, Is.EqualTo(model.CertifyingLaboratory));
            Assert.That(existingDiamond.Proportions, Is.EqualTo(model.Proportions));
            Assert.That(existingDiamond.IsForSale, Is.EqualTo(model.IsForSale));
        }
    }
}
