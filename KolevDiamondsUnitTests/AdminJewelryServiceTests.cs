using KolevDiamonds.Areas.Admin.Services;
using KolevDiamonds.Core.Contracts.InvestmentCoin;
using KolevDiamonds.Core.Contracts.InvestmentDiamond;
using KolevDiamonds.Core.Contracts.MetalBar;
using KolevDiamonds.Core.Contracts.Necklace;
using KolevDiamonds.Core.Contracts.Ring;
using KolevDiamonds.Core.Models;
using MockQueryable.Moq;
using Moq;
using static KolevDiamonds.Core.Constants.JewelryConstants;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolevDiamondsUnitTests
{

    [TestFixture]
    public class AdminJewelryServiceTests
    {
        private Mock<IRingService> _mockRingService;
        private Mock<INecklaceService> _mockNecklaceService;
        private Mock<IMetalBarService> _mockMetalBarService;
        private Mock<IInvestmentDiamondService> _mockInvestmentDiamondService;
        private Mock<IInvestmentCoinService> _mockInvestmentCoinService;
        private AdminJewelryService _adminJewelryService;

        [SetUp]
        public void Setup()
        {
            _mockRingService = new Mock<IRingService>();
            _mockNecklaceService = new Mock<INecklaceService>();
            _mockMetalBarService = new Mock<IMetalBarService>();
            _mockInvestmentDiamondService = new Mock<IInvestmentDiamondService>();
            _mockInvestmentCoinService = new Mock<IInvestmentCoinService>();

            _adminJewelryService = new AdminJewelryService(
                _mockRingService.Object,
                _mockNecklaceService.Object,
                _mockMetalBarService.Object,
                _mockInvestmentDiamondService.Object,
                _mockInvestmentCoinService.Object
            );
        }

        [Test]
        public async Task GetAllJewelry_ReturnsCombinedProducts()
        {
            // Arrange
            var query = new ProductQueryModel
            {
                PriceFilter = 200,
                CurrentPage = 1,
                IsForSale = true
            };

            var rings = new List<ProductIndexServiceModel>
            {
                new ProductIndexServiceModel { Id = 1, Name = "Ring 1" },
               
            };
            var necklaces = new List<ProductIndexServiceModel>
            {
              new ProductIndexServiceModel { Id = 2, Name = "Necklace 1" },
            };
            var metalBars = new List<ProductIndexServiceModel>
            {
                new ProductIndexServiceModel { Id = 3, Name = "Metal Bar 1" },

            };
            var investmentDiamonds = new List<ProductIndexServiceModel>
            {
                new ProductIndexServiceModel { Id = 4, Name = "Coin 1" },

            };
            var InvestmentCoins = new List<ProductIndexServiceModel>
            {
                new ProductIndexServiceModel { Id = 5, Name = "Diamond 1" }

            };
                
            _mockRingService.Setup(s => s.GetFilteredRingsAsync(query.PriceFilter, query.CurrentPage, JewelryTypeItemPerPage, query.IsForSale))
                .Returns(Task.FromResult(new ProductQueryModel { Products = rings }));

            _mockNecklaceService.Setup(s => s.GetFilteredNecklacesAsync(query.PriceFilter, query.CurrentPage, JewelryTypeItemPerPage, query.IsForSale))
                                .Returns(Task.FromResult(new ProductQueryModel { Products = necklaces }));

            _mockMetalBarService.Setup(s => s.GetFilteredMetalBarsAsync(query.PriceFilter, query.CurrentPage, JewelryTypeItemPerPage, query.IsForSale))
                                .Returns(Task.FromResult(new ProductQueryModel { Products = metalBars }));

            _mockInvestmentCoinService.Setup(s => s.GetFilteredInvestmentCoinsAsync(query.PriceFilter, query.CurrentPage, JewelryTypeItemPerPage, query.IsForSale))
                                      .Returns(Task.FromResult(new ProductQueryModel { Products = investmentDiamonds }));

            _mockInvestmentDiamondService.Setup(s => s.GetFilteredInvestmentDiamondsAsync(query.PriceFilter, query.CurrentPage, JewelryTypeItemPerPage, query.IsForSale))
                                         .Returns(Task.FromResult(new ProductQueryModel { Products = InvestmentCoins }));

            // Act
            var result = await _adminJewelryService.GetAllJewelry(query);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(5));
            Assert.IsTrue(result.Any(p => p.Name == "Ring 1"));
            Assert.IsTrue(result.Any(p => p.Name == "Necklace 1"));
            Assert.IsTrue(result.Any(p => p.Name == "Metal Bar 1"));
            Assert.IsTrue(result.Any(p => p.Name == "Coin 1"));
            Assert.IsTrue(result.Any(p => p.Name == "Diamond 1"));
        }
    }
}
