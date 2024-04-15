using KolevDiamonds.Controllers;
using KolevDiamonds.Core.Contracts.MetalBar;
using KolevDiamonds.Core.Models.MetalBar;
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
    public class MetalBarControllerTests
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
                ProductType = "metalbars"
            };

            var metalBarServiceMock = new Mock<IMetalBarService>();
            metalBarServiceMock.Setup(service => service.GetFilteredMetalBarsAsync(
                    query.PriceFilter,
                    query.CurrentPage,
                    query.ProductsPerPage,
                    true))
                .ReturnsAsync(expectedModel);

            var controller = new MetalBarController(metalBarServiceMock.Object);

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
        public async Task Details_Returns_View_With_Model_When_MetalBar_Exists()
        {
            // Arrange
            var metalBarId = 1;
            var information = "Test-Metal-Bar100";
            var expectedMetalBar = new MetalBar
            {
                Id = metalBarId,
                Name = "Test Metal Bar",
                ImagePath = "/path/to/image",
                Price = 100,
                Metal = MetalVariation.WhiteGold,
                Weight = 10,
                Dimensions = "10x5x2",
                Purity = "high"
            };

            var metalBarServiceMock = new Mock<IMetalBarService>();
            metalBarServiceMock.Setup(service => service.GetByIdAsync(metalBarId))
                .ReturnsAsync(expectedMetalBar);

            var controller = new MetalBarController(metalBarServiceMock.Object);

            // Act
            var actionResult = await controller.Details(metalBarId, information);

            // Assert
            var viewResult = actionResult as ViewResult;
            Assert.IsNotNull(viewResult);

            var model = viewResult.Model as MetalBarDetailsServiceModel;
            Assert.IsNotNull(model);
            Assert.That(model.Id, Is.EqualTo(expectedMetalBar.Id));
            Assert.That(model.Name, Is.EqualTo(expectedMetalBar.Name));
            Assert.That(model.ImagePath, Is.EqualTo(expectedMetalBar.ImagePath));
            Assert.That(model.Price, Is.EqualTo(expectedMetalBar.Price));
            Assert.That(model.Metal, Is.EqualTo(expectedMetalBar.Metal));
            Assert.That(model.Weight, Is.EqualTo(expectedMetalBar.Weight));
            Assert.That(model.Dimensions, Is.EqualTo(expectedMetalBar.Dimensions));
            Assert.That(model.Purity, Is.EqualTo(expectedMetalBar.Purity));
        }

        [Test]
        public async Task Details_Returns_NotFound_When_MetalBar_Does_Not_Exist()
        {
            // Arrange
            var metalBarId = 1;
            var information = "info";

            var metalBarServiceMock = new Mock<IMetalBarService>();
            metalBarServiceMock.Setup(service => service.GetByIdAsync(metalBarId))
                .ReturnsAsync((MetalBar)null);

            var controller = new MetalBarController(metalBarServiceMock.Object);

            // Act
            var actionResult = await controller.Details(metalBarId, information);

            // Assert
            var notFoundResult = actionResult as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
        }

        [Test]
        public async Task Details_Returns_NotFound_When_Information_Mismatch()
        {
            // Arrange
            var metalBarId = 1;
            var expectedMetalBar = new MetalBar { Id = metalBarId };

            var metalBarServiceMock = new Mock<IMetalBarService>();
            metalBarServiceMock.Setup(service => service.GetByIdAsync(metalBarId))
                .ReturnsAsync(expectedMetalBar);

            var controller = new MetalBarController(metalBarServiceMock.Object);

            // Act
            var actionResult = await controller.Details(metalBarId, "other_info");

            // Assert
            var notFoundResult = actionResult as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
        }
    }
}
