using KolevDiamonds.Core.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using static KolevDiamonds.Areas.Admin.Constants.JewelryConstants;
using KolevDiamonds.Core.Contracts.InvestmentCoin;
using KolevDiamonds.Core.Contracts.InvestmentDiamond;
using KolevDiamonds.Core.Contracts.MetalBar;
using KolevDiamonds.Core.Contracts.Necklace;
using KolevDiamonds.Core.Contracts.Ring;
using KolevDiamonds.Areas.Admin.Contracts;

namespace KolevDiamonds.Areas.Admin.Services
{
    public class AdminJewelryServices : IAdminJewelryServiceContract
    {
        private readonly IRingService _ringService;
        private readonly INecklaceService _necklaceService;
        private readonly IMetalBarService _metalBarService;
        private readonly IInvestmentDiamondService _investmentDiamondService;
        private readonly IInvestmentCoinService _investmentCoinService;

        public AdminJewelryServices(
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

        public async Task<IEnumerable<ProductIndexServiceModel>> GetAllJewelry(ProductQueryModel query)
        {
            var rings = await this._ringService.GetFilteredRingsAsync(
                    query.PriceFilter,
                    query.CurrentPage,
                    JewelryTypeItemPerPage,
                    query.IsForSale
            );

            var necklaces = await this._necklaceService.GetFilteredNecklacesAsync(
                query.PriceFilter,
                query.CurrentPage,
                JewelryTypeItemPerPage,
                query.IsForSale
            );

            var metalBars = await this._metalBarService.GetFilteredMetalBarsAsync(
                query.PriceFilter,
                query.CurrentPage,
                JewelryTypeItemPerPage,
                query.IsForSale
            );

            var investmentCoins = await this._investmentCoinService.GetFilteredInvestmentCoinsAsync(
                query.PriceFilter,
                query.CurrentPage,
                JewelryTypeItemPerPage,
                query.IsForSale
            );

            var investmentDiamonds = await this._investmentDiamondService.GetFilteredInvestmentDiamondsAsync(
                query.PriceFilter,
                query.CurrentPage,
                JewelryTypeItemPerPage,
                query.IsForSale
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
