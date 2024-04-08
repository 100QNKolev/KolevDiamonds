using KolevDiamonds.Core.Contracts.InvestmentCoin;
using KolevDiamonds.Core.Contracts.InvestmentDiamond;
using KolevDiamonds.Core.Contracts.MetalBar;
using KolevDiamonds.Core.Contracts.Necklace;
using KolevDiamonds.Core.Contracts.Ring;
using KolevDiamonds.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static KolevDiamonds.Areas.Admin.Constants.JewelryConstants;

namespace KolevDiamonds.Areas.Admin.Controllers
{
    public class JewelryController : AdminBaseController
    {
        private readonly IRingService _ringService;
        private readonly INecklaceService _necklaceService;
        private readonly IMetalBarService _metalBarService;
        private readonly IInvestmentDiamondService _investmentDiamondService;
        private readonly IInvestmentCoinService _investmentCoinService;

        public JewelryController(
            IRingService ringService,
            INecklaceService necklaceService,
            IMetalBarService metalBarService,
            IInvestmentDiamondService investmentDiamondService,
            IInvestmentCoinService investmentCoinService
            )
        {
            this._ringService = ringService;
            this._necklaceService = necklaceService;
            this._metalBarService = metalBarService;
            this._investmentCoinService = investmentCoinService;
            this._investmentDiamondService = investmentDiamondService;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] ProductQueryModel query)
        {
            var model = new ProductQueryModel { Products = await GetAllJewelry(query) };

            query.TotalProductCount = model.TotalProductCount;
            query.Products = model.Products;
            query.ProductType = JewelryQueryProductType;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, string productType)
        {
            if (User.isAdmin())
            {
                switch (productType)
                {
                    case "Ring":
                        await this._ringService.Delete(id);
                        break;

                    case "Necklace":
                        await this._necklaceService.Delete(id);
                        break;

                    case "MetalBar":
                        await this._metalBarService.Delete(id);
                        break;

                    case "InvestmentDiamond":
                        await this._investmentDiamondService.Delete(id);
                        break;

                    case "InvestmentCoin":
                        await this._investmentCoinService.Delete(id);
                        break;
                    default:
                        return BadRequest();
                }
            }

            return RedirectToAction(nameof(All));
        }

        [NonAction]
        public async Task<IEnumerable<ProductIndexServiceModel>> GetAllJewelry(ProductQueryModel query)
        {
            var rings = await this._ringService.GetFilteredRingsAsync(
                    query.PriceFilter,
                    query.CurrentPage,
                    JewelryTypeItemPerPage
            );

            var necklaces = await this._necklaceService.GetFilteredNecklacesAsync(
                query.PriceFilter,
                query.CurrentPage,
                JewelryTypeItemPerPage
            );

            var metalBars = await this._metalBarService.GetFilteredMetalBarsAsync(
                query.PriceFilter,
                query.CurrentPage,
                JewelryTypeItemPerPage
            );

            var investmentCoins = await this._investmentCoinService.GetFilteredInvestmentCoinsAsync(
                query.PriceFilter,
                query.CurrentPage,
                JewelryTypeItemPerPage
            );

            var investmentDiamonds = await this._investmentDiamondService.GetFilteredInvestmentDiamondsAsync(
                query.PriceFilter,
                query.CurrentPage,
                JewelryTypeItemPerPage
            );

            var allProducts = rings.Products
             .Concat(necklaces.Products)
             .Concat(metalBars.Products)
             .Concat(investmentCoins.Products)
             .Concat(investmentDiamonds.Products);

            return allProducts;
        }
    }
}
