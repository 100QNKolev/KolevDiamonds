using KolevDiamonds.Areas.Admin.Controllers;
using KolevDiamonds.Core.Contracts.InvestmentCoin;
using KolevDiamonds.Core.Contracts.InvestmentDiamond;
using KolevDiamonds.Core.Contracts.MetalBar;
using KolevDiamonds.Core.Contracts.Necklace;
using KolevDiamonds.Core.Contracts.Ring;
using KolevDiamonds.Core.Contracts;
using KolevDiamonds.Core.Models.Admin;
using KolevDiamonds.Core.Models;
using Microsoft.AspNetCore.Mvc;
using MockQueryable.Moq;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using KolevDiamonds.Core.Models.InvestmentCoin;
using KolevDiamonds.Core.Models.InvestmentDiamond;
using KolevDiamonds.Core.Models.MetalBar;
using KolevDiamonds.Core.Models.Necklace;
using KolevDiamonds.Core.Models.Ring;
using KolevDiamonds.Core.Services.InvestmentCoin;
using KolevDiamonds.Core.Services.InvestmentDiamond;
using KolevDiamonds.Core.Services.MetalBar;
using KolevDiamonds.Core.Services.Necklace;
using KolevDiamonds.Core.Services.Ring;
using KolevDiamonds.Infrastructure.Data.Models;
using KolevDiamonds.Infrastructure.Enums;

namespace KolevDiamondsUnitTests
{
    [TestFixture]
    public class JewelryControllerTests
    {
        private Mock<IRingService> _mockRingService;
        private Mock<INecklaceService> _mockNecklaceService;
        private Mock<IMetalBarService> _mockMetalBarService;
        private Mock<IInvestmentDiamondService> _mockInvestmentDiamondService;
        private Mock<IInvestmentCoinService> _mockInvestmentCoinService;
        private Mock<IAdminJewelryServiceContract> _mockAdminJewelryService;
        private JewelryController _controller;

        [SetUp]
        public void Setup()
        {
            _mockRingService = new Mock<IRingService>();
            _mockNecklaceService = new Mock<INecklaceService>();
            _mockMetalBarService = new Mock<IMetalBarService>();
            _mockInvestmentDiamondService = new Mock<IInvestmentDiamondService>();
            _mockInvestmentCoinService = new Mock<IInvestmentCoinService>();
            _mockAdminJewelryService = new Mock<IAdminJewelryServiceContract>();

            _controller = new JewelryController(
                _mockRingService.Object,
                _mockNecklaceService.Object,
                _mockMetalBarService.Object,
                _mockInvestmentDiamondService.Object,
                _mockInvestmentCoinService.Object,
                _mockAdminJewelryService.Object
            );
        }

        [Test]
        public async Task All_ReturnsViewWithCorrectModel()
        {
            // Arrange
            var query = new ProductQueryModel();

            var products = new List<ProductIndexServiceModel>
    {
        new ProductIndexServiceModel { Id = 1, Name = "Ring 1" },
        new ProductIndexServiceModel { Id = 2, Name = "Necklace 1" },
        new ProductIndexServiceModel { Id = 3, Name = "Metal Bar 1" },
        new ProductIndexServiceModel { Id = 4, Name = "Coin 1" },
        new ProductIndexServiceModel { Id = 5, Name = "Diamond 1" }
    };

            _mockAdminJewelryService.Setup(s => s.GetAllJewelry(query))
                                    .ReturnsAsync(products);

            // Act
            var result = await _controller.All(query) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ProductQueryModel>(result.Model);
            Assert.That(((ProductQueryModel)result.Model).Products.Count(), Is.EqualTo(products.Count));
        }

        [Test]
        public async Task Delete_ReturnsBadRequest_WhenUserIsNotAdmin()
        {
            // Arrange
            var id = 1;
            var productType = "Ring";

            // Mock the User object
            var userMock = new Mock<ClaimsPrincipal>();
            userMock.Setup(u => u.IsInRole("Admin")).Returns(false);
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = userMock.Object }
            };

            // Act
            var result = await _controller.Delete(id, productType) as BadRequestResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task Add_ReturnsViewWithCorrectModel()
        {
            // Act
            var result = await _controller.Add(new AdminQueryModel()) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<AdminQueryModel>(result.Model);
        }

        [Test]
        public async Task Edit_ReturnsBadRequest_WhenUserIsNotAdmin()
        {
            // Arrange
            var id = 1;
            var productType = "Ring";
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
            // Create a non-admin claim
            new Claim(ClaimTypes.Role, "User"),
                    // Add other necessary claims
                    // new Claim(ClaimTypes.NameIdentifier, "123"),
                    // new Claim(ClaimTypes.Name, "username"),
                    // Add more claims if necessary
                }, "mock"))
            };

            // Act
            var result = await _controller.Edit(id, productType) as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Value, Is.EqualTo("User is not authorized."));
        }

        [Test]
        public async Task Edit_InvalidModel_ReturnsViewWithError()
        {
            // Arrange
            var model = new RingModel { /* Populate model with invalid data */ };
            _controller.ModelState.AddModelError("Name", "Name is required");

            // Act
            var result = await _controller.EditRing(model);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.That(viewResult.ViewName, Is.EqualTo("_RingDetailsProductCardPartial"));
        }

        [Test]
        public async Task Edit_ReturnsViewWithError_WhenModelStateIsNotValid()
        {
            // Arrange
            var model = new NecklaceModel();
            _controller.ModelState.AddModelError("PropertyName", "Error Message");

            // Act
            var result = await _controller.EditNecklace(model) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.That(result.ViewName, Is.EqualTo("_NecklaceDetailsProductCardPartial"));
            Assert.That(result.Model, Is.EqualTo(model)); // Check if model is passed back to the view
        }

    }
}
