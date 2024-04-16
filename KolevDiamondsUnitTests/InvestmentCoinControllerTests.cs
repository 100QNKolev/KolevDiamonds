using KolevDiamonds.Controllers;
using KolevDiamonds.Core.Contracts.InvestmentCoin;
using KolevDiamonds.Core.Models.InvestmentCoin;
using KolevDiamonds.Core.Models;
using KolevDiamonds.Infrastructure.Data.Models;
using KolevDiamonds.Infrastructure.Enums;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamondsUnitTests
{
    [TestFixture]
    public class InvestmentCoinControllerTests
    {
        [Test]
        public async Task All_Returns_View_With_Query_Model()
        {
            // Arrange
            var query = new ProductQueryModel
            {
                PriceFilter = 2000m,
                CurrentPage = 1
            };

            var expectedModel = new ProductQueryModel
            {
                TotalProductCount = 20,
                Products = new List<ProductIndexServiceModel>(),
                ProductType = "investmentcoins"
            };

            var investmentCoinServiceMock = new Mock<IInvestmentCoinService>();
            investmentCoinServiceMock.Setup(service => service.GetFilteredInvestmentCoinsAsync(
                    query.PriceFilter,
                    query.CurrentPage,
                    query.ProductsPerPage,
                    true))
                .ReturnsAsync(expectedModel);

            var controller = new InvestmentCoinController(investmentCoinServiceMock.Object);

            // Act
            var actionResult = await controller.All(query);

            // Assert
            var viewResult = actionResult as ViewResult;
            Assert.IsNotNull(viewResult);

            var resultQuery = viewResult.Model as ProductQueryModel;
            Assert.IsNotNull(resultQuery);
            Assert.That(resultQuery.TotalProductCount, Is.EqualTo(expectedModel.TotalProductCount));
            Assert.That(resultQuery.Products, Is.EqualTo(expectedModel.Products));
            Assert.That(resultQuery.ProductType, Is.EqualTo(expectedModel.ProductType));
        }

        [Test]
        public async Task Details_Returns_View_With_Model_When_InvestmentCoin_Exists()
        {
            // Arrange
            var investmentCoinId = 1;
            var information = "Test-InvestmentCoin100";
            var expectedInvestmentCoin = new InvestmentCoin
            {
                Id = investmentCoinId,
                Name = "Test InvestmentCoin",
                ImagePath = "/path/to/image",
                Price = 100,
                Metal = MetalVariation.WhiteGold,
                Weight = 10,
                Purity = 100,
                Quality = GoldQuality.Uncirculated,
                Circulation = 1000,
                Diameter = 30,
                LegalTender = "yes",
                Manufacturer = "ABC Inc.",
                Packaging = "Boxed"
            };

            var investmentCoinServiceMock = new Mock<IInvestmentCoinService>();
            investmentCoinServiceMock.Setup(service => service.GetByIdAsync(investmentCoinId))
                .ReturnsAsync(expectedInvestmentCoin);

            var controller = new InvestmentCoinController(investmentCoinServiceMock.Object);

            // Act
            var actionResult = await controller.Details(investmentCoinId, information);

            // Assert
            var viewResult = actionResult as ViewResult;
            Assert.IsNotNull(viewResult);

            var model = viewResult.Model as InvestmentCoinDetailsServiceModel;
            Assert.IsNotNull(model);
            Assert.That(model.Id, Is.EqualTo(expectedInvestmentCoin.Id));
            Assert.That(model.Name, Is.EqualTo(expectedInvestmentCoin.Name));
            Assert.That(model.ImagePath, Is.EqualTo(expectedInvestmentCoin.ImagePath));
            Assert.That(model.Price, Is.EqualTo(expectedInvestmentCoin.Price));
            Assert.That(model.Metal, Is.EqualTo(expectedInvestmentCoin.Metal));
            Assert.That(model.Weight, Is.EqualTo(expectedInvestmentCoin.Weight));
            Assert.That(model.Purity, Is.EqualTo(expectedInvestmentCoin.Purity));
            Assert.That(model.Quality, Is.EqualTo(expectedInvestmentCoin.Quality));
            Assert.That(model.Circulation, Is.EqualTo(expectedInvestmentCoin.Circulation));
            Assert.That(model.Diameter, Is.EqualTo(expectedInvestmentCoin.Diameter));
            Assert.That(model.LegalTender, Is.EqualTo(expectedInvestmentCoin.LegalTender));
            Assert.That(model.Manufacturer, Is.EqualTo(expectedInvestmentCoin.Manufacturer));
            Assert.That(model.Packaging, Is.EqualTo(expectedInvestmentCoin.Packaging));
        }

        [Test]
        public async Task Details_Returns_NotFound_When_InvestmentCoin_Does_Not_Exist()
        {
            // Arrange
            var investmentCoinId = 1;
            var information = "info";

            var investmentCoinServiceMock = new Mock<IInvestmentCoinService>();
            investmentCoinServiceMock.Setup(service => service.GetByIdAsync(investmentCoinId))
                .ReturnsAsync((InvestmentCoin)null);

            var controller = new InvestmentCoinController(investmentCoinServiceMock.Object);

            // Act
            var actionResult = await controller.Details(investmentCoinId, information);

            // Assert
            var notFoundResult = actionResult as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
        }

        [Test]
        public async Task Details_Returns_NotFound_When_Information_Mismatch()
        {
            // Arrange
            var investmentCoinId = 1;
            var expectedInvestmentCoin = new InvestmentCoin { Id = investmentCoinId };

            var investmentCoinServiceMock = new Mock<IInvestmentCoinService>();
            investmentCoinServiceMock.Setup(service => service.GetByIdAsync(investmentCoinId))
                .ReturnsAsync(expectedInvestmentCoin);

            var controller = new InvestmentCoinController(investmentCoinServiceMock.Object);

            // Act
            var actionResult = await controller.Details(investmentCoinId, "other_info");

            // Assert
            var notFoundResult = actionResult as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
        }
    }
}
