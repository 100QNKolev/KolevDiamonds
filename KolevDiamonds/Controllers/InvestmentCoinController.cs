using KolevDiamonds.Core.Contracts.InvestmentCoin;
using KolevDiamonds.Core.Models.InvestmentCoin;
using Microsoft.AspNetCore.Mvc;

namespace KolevDiamonds.Controllers
{
    public class InvestmentCoinController : Controller
    {
        private readonly IInvestmentCoinService _investmentCoinService;

        public InvestmentCoinController(IInvestmentCoinService investmentCoinService)
        {
            this._investmentCoinService = investmentCoinService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await this._investmentCoinService.AllInvestmentCoins();

            ViewBag.PriceFilter = 0;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var investmentCoin = await _investmentCoinService.GetByIdAsync(id);

            var model = new InvestmentCoinDetailsServiceModel
            {
                CoinId = investmentCoin.Id,
                CoinName = investmentCoin.Name,
                CoinImagePath = investmentCoin.ImagePath,
                Price = investmentCoin.Price,
                Metal = investmentCoin.Metal,
                Weight = investmentCoin.Weight,
                Purity = investmentCoin.Purity,
                Quality = investmentCoin.Quality,
                Circulation = investmentCoin.Circulation,
                Diameter = investmentCoin.Diameter,
                LegalTender = investmentCoin.LegalTender,
                Manufacturer = investmentCoin.Manufacturer,
                Packaging = investmentCoin.Packaging
            };

            return View(model);
        }

    }
}
