using KolevDiamonds.Controllers;
using KolevDiamonds.Core.Contracts.Ring;
using KolevDiamonds.Core.Models;
using KolevDiamonds.Core.Models.Ring;
using KolevDiamonds.Infrastructure.Data.Models;
using KolevDiamonds.Infrastructure.Enums;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace KolevDiamondsUnitTests
{
    [TestFixture]
    public class RingControllerTests
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
                ProductType = "rings"
            };

            var ringServiceMock = new Mock<IRingService>();
            ringServiceMock.Setup(service => service.GetFilteredRingsAsync(
                    query.PriceFilter,
                    query.CurrentPage,
                    query.ProductsPerPage,
                    true))
                .ReturnsAsync(expectedModel);

            var controller = new RingController(ringServiceMock.Object);

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
        public async Task Details_Returns_View_With_Model_When_Ring_Exists()
        {
            // Arrange
            var ringId = 1;
            var information = "Test-Ring100";
            var expectedRing = new Ring
            {
                Id = ringId,
                Name = "Test Ring",
                ImagePath = "/path/to/image",
                Price = 100,
                Metal = MetalVariation.WhiteGold,
                Carats = 1,
                Colour = DiamondColor.Q,
                Clarity = DiamondClarity.I2,
                Cut = DiamondCut.Good,
                Purity = "high"
            };

            var ringServiceMock = new Mock<IRingService>();
            ringServiceMock.Setup(service => service.GetByIdAsync(ringId))
                .ReturnsAsync(expectedRing);

            var controller = new RingController(ringServiceMock.Object);

            // Act
            var actionResult = await controller.Details(ringId, information);

            // Assert
            var viewResult = actionResult as ViewResult;
            Assert.IsNotNull(viewResult);

            var model = viewResult.Model as RingDetailsServiceModel;
            Assert.IsNotNull(model);
            Assert.That(model.Id, Is.EqualTo(expectedRing.Id));
            Assert.That(model.Name, Is.EqualTo(expectedRing.Name));
            Assert.That(model.ImagePath, Is.EqualTo(expectedRing.ImagePath));
            Assert.That(model.Price, Is.EqualTo(expectedRing.Price));
            Assert.That(model.Metal, Is.EqualTo(expectedRing.Metal));
            Assert.That(model.Carats, Is.EqualTo(expectedRing.Carats));
            Assert.That(model.Colour, Is.EqualTo(expectedRing.Colour));
            Assert.That(model.Clarity, Is.EqualTo(expectedRing.Clarity));
            Assert.That(model.Cut, Is.EqualTo(expectedRing.Cut));
            Assert.That(model.Purity, Is.EqualTo(expectedRing.Purity));
        }

        [Test]
        public async Task Details_Returns_NotFound_When_Ring_Does_Not_Exist()
        {
            // Arrange
            var ringId = 1;
            var information = "info";

            var ringServiceMock = new Mock<IRingService>();
            ringServiceMock.Setup(service => service.GetByIdAsync(ringId))
                .ReturnsAsync((Ring)null);

            var controller = new RingController(ringServiceMock.Object);

            // Act
            var actionResult = await controller.Details(ringId, information);

            // Assert
            var notFoundResult = actionResult as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
        }

        [Test]
        public async Task Details_Returns_NotFound_When_Information_Mismatch()
        {
            // Arrange
            var ringId = 1;
            var expectedRing = new Ring { Id = ringId };

            var ringServiceMock = new Mock<IRingService>();
            ringServiceMock.Setup(service => service.GetByIdAsync(ringId))
                .ReturnsAsync(expectedRing);

            var controller = new RingController(ringServiceMock.Object);

            // Act
            var actionResult = await controller.Details(ringId, "other_info");

            // Assert
            var notFoundResult = actionResult as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
        }
    }
}
