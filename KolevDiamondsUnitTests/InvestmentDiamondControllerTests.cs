using KolevDiamonds.Controllers;
using KolevDiamonds.Core.Contracts.InvestmentDiamond;
using KolevDiamonds.Core.Models.InvestmentDiamond;
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
    public class InvestmentDiamondControllerTests
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
                ProductType = "investmentdiamonds"
            };

            var investmentDiamondServiceMock = new Mock<IInvestmentDiamondService>();
            investmentDiamondServiceMock.Setup(service => service.GetFilteredInvestmentDiamondsAsync(
                    query.PriceFilter,
                    query.CurrentPage,
                    query.ProductsPerPage,
                    true))
                .ReturnsAsync(expectedModel);

            var controller = new InvestmentDiamondController(investmentDiamondServiceMock.Object);

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
        public async Task Details_Returns_View_With_Model_When_InvestmentDiamond_Exists()
        {
            // Arrange
            var investmentDiamondId = 1;
            var information = "Test-InvestmentDiamond100";
            var expectedInvestmentDiamond = new InvestmentDiamond
            {
                Id = investmentDiamondId,
                Name = "Test InvestmentDiamond",
                ImagePath = "/path/to/image",
                Price = 100,
                Carats = 1,
                Colour = DiamondColor.Q,
                Clarity = DiamondClarity.I2,
                Cut = DiamondCut.Good,
                CertifyingLaboratory = "GIA",
                Proportions = "Excellent"
            };

            var investmentDiamondServiceMock = new Mock<IInvestmentDiamondService>();
            investmentDiamondServiceMock.Setup(service => service.GetByIdAsync(investmentDiamondId))
                .ReturnsAsync(expectedInvestmentDiamond);

            var controller = new InvestmentDiamondController(investmentDiamondServiceMock.Object);

            // Act
            var actionResult = await controller.Details(investmentDiamondId, information);

            // Assert
            var viewResult = actionResult as ViewResult;
            Assert.IsNotNull(viewResult);

            var model = viewResult.Model as InvestmentDiamondDetailsServiceModel;
            Assert.IsNotNull(model);
            Assert.That(model.Id, Is.EqualTo(expectedInvestmentDiamond.Id));
            Assert.That(model.Name, Is.EqualTo(expectedInvestmentDiamond.Name));
            Assert.That(model.ImagePath, Is.EqualTo(expectedInvestmentDiamond.ImagePath));
            Assert.That(model.Price, Is.EqualTo(expectedInvestmentDiamond.Price));
            Assert.That(model.Carats, Is.EqualTo(expectedInvestmentDiamond.Carats));
            Assert.That(model.Colour, Is.EqualTo(expectedInvestmentDiamond.Colour));
            Assert.That(model.Clarity, Is.EqualTo(expectedInvestmentDiamond.Clarity));
            Assert.That(model.Cut, Is.EqualTo(expectedInvestmentDiamond.Cut));
            Assert.That(model.CertifyingLaboratory, Is.EqualTo(expectedInvestmentDiamond.CertifyingLaboratory));
            Assert.That(model.Proportions, Is.EqualTo(expectedInvestmentDiamond.Proportions));
        }

        [Test]
        public async Task Details_Returns_NotFound_When_InvestmentDiamond_Does_Not_Exist()
        {
            // Arrange
            var investmentDiamondId = 1;
            var information = "info";

            var investmentDiamondServiceMock = new Mock<IInvestmentDiamondService>();
            investmentDiamondServiceMock.Setup(service => service.GetByIdAsync(investmentDiamondId))
                .ReturnsAsync((InvestmentDiamond)null);

            var controller = new InvestmentDiamondController(investmentDiamondServiceMock.Object);

            // Act
            var actionResult = await controller.Details(investmentDiamondId, information);

            // Assert
            var notFoundResult = actionResult as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
        }

        [Test]
        public async Task Details_Returns_NotFound_When_Information_Mismatch()
        {
            // Arrange
            var investmentDiamondId = 1;
            var expectedInvestmentDiamond = new InvestmentDiamond { Id = investmentDiamondId };

            var investmentDiamondServiceMock = new Mock<IInvestmentDiamondService>();
            investmentDiamondServiceMock.Setup(service => service.GetByIdAsync(investmentDiamondId))
                .ReturnsAsync(expectedInvestmentDiamond);

            var controller = new InvestmentDiamondController(investmentDiamondServiceMock.Object);

            // Act
            var actionResult = await controller.Details(investmentDiamondId, "other_info");

            // Assert
            var notFoundResult = actionResult as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
        }
    }
}
