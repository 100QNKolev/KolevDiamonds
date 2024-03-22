using KolevDiamonds.Core.Contracts.InvestmentCoin;
using KolevDiamonds.Core.Models;
using KolevDiamonds.Core.Models.InvestmentCoin;
using KolevDiamonds.Infrastructure.Data.Models;
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
        public async Task<IActionResult> All([FromQuery] ProductQueryModel query)
        {
            var model = await this._investmentCoinService.GetFilteredInvestmentCoinsAsync(
                query.PriceFilter,
                query.CurrentPage,
                query.ProductsPerPage
                );

            query.TotalProductCount = model.TotalProductCount;
            query.Products = model.Products;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var investmentCoin = await _investmentCoinService.GetByIdAsync(id);

            if (investmentCoin == null)
            {
                return RedirectToAction(nameof(NotFoundError));
            }

            var model = new InvestmentCoinDetailsServiceModel
            {
                Id = investmentCoin.Id,
                Name = investmentCoin.Name,
                ImagePath = investmentCoin.ImagePath,
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

        [HttpGet]
        public IActionResult NotFoundError()
        {
            // Redirect to the custom error page for 500 Internal Server Error
            return View("Error404");
        }

        [HttpGet]
        public IActionResult InternalServerError()
        {
            // Redirect to the custom error page for 500 Internal Server Error
            return View("Error500");
        }
    }
}
