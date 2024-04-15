using KolevDiamonds.Controllers;
using KolevDiamonds.Core.Contracts.Necklace;
using KolevDiamonds.Core.Models.Necklace;
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
    public class NecklaceControllerTests
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
                ProductType = "necklaces"
            };

            var necklaceServiceMock = new Mock<INecklaceService>();
            necklaceServiceMock.Setup(service => service.GetFilteredNecklacesAsync(
                    query.PriceFilter,
                    query.CurrentPage,
                    query.ProductsPerPage,
                    true))
                .ReturnsAsync(expectedModel);

            var controller = new NecklaceController(necklaceServiceMock.Object);

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
        public async Task Details_Returns_View_With_Model_When_Necklace_Exists()
        {
            // Arrange
            var necklaceId = 1;
            var information = "Test-Necklace100";
            var expectedNecklace = new Necklace
            {
                Id = necklaceId,
                Name = "Test Necklace",
                ImagePath = "/path/to/image",
                Price = 100,
                Metal = MetalVariation.WhiteGold,
                Carats = 1,
                Colour = DiamondColor.Q,
                Clarity = DiamondClarity.I2,
                Cut = DiamondCut.Good,
                Purity = "high",
                Length = 16
            };

            var necklaceServiceMock = new Mock<INecklaceService>();
            necklaceServiceMock.Setup(service => service.GetByIdAsync(necklaceId))
                .ReturnsAsync(expectedNecklace);

            var controller = new NecklaceController(necklaceServiceMock.Object);

            // Act
            var actionResult = await controller.Details(necklaceId, information);

            // Assert
            var viewResult = actionResult as ViewResult;
            Assert.IsNotNull(viewResult);

            var model = viewResult.Model as NecklaceDetailsServiceModel;
            Assert.IsNotNull(model);
            Assert.That(model.Id, Is.EqualTo(expectedNecklace.Id));
            Assert.That(model.Name, Is.EqualTo(expectedNecklace.Name));
            Assert.That(model.ImagePath, Is.EqualTo(expectedNecklace.ImagePath));
            Assert.That(model.Price, Is.EqualTo(expectedNecklace.Price));
            Assert.That(model.Metal, Is.EqualTo(expectedNecklace.Metal));
            Assert.That(model.Carats, Is.EqualTo(expectedNecklace.Carats));
            Assert.That(model.Colour, Is.EqualTo(expectedNecklace.Colour));
            Assert.That(model.Clarity, Is.EqualTo(expectedNecklace.Clarity));
            Assert.That(model.Cut, Is.EqualTo(expectedNecklace.Cut));
            Assert.That(model.Purity, Is.EqualTo(expectedNecklace.Purity));
            Assert.That(model.Length, Is.EqualTo(expectedNecklace.Length));
        }

        [Test]
        public async Task Details_Returns_NotFound_When_Necklace_Does_Not_Exist()
        {
            // Arrange
            var necklaceId = 1;
            var information = "info";

            var necklaceServiceMock = new Mock<INecklaceService>();
            necklaceServiceMock.Setup(service => service.GetByIdAsync(necklaceId))
                .ReturnsAsync((Necklace)null);

            var controller = new NecklaceController(necklaceServiceMock.Object);

            // Act
            var actionResult = await controller.Details(necklaceId, information);

            // Assert
            var notFoundResult = actionResult as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
        }

        [Test]
        public async Task Details_Returns_NotFound_When_Information_Mismatch()
        {
            // Arrange
            var necklaceId = 1;
            var expectedNecklace = new Necklace { Id = necklaceId };

            var necklaceServiceMock = new Mock<INecklaceService>();
            necklaceServiceMock.Setup(service => service.GetByIdAsync(necklaceId))
                .ReturnsAsync(expectedNecklace);

            var controller = new NecklaceController(necklaceServiceMock.Object);

            // Act
            var actionResult = await controller.Details(necklaceId, "other_info");

            // Assert
            var notFoundResult = actionResult as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
        }
    }
}
