using KolevDiamonds.Core.Contracts.InvestmentDiamond;
using KolevDiamonds.Core.Models;
using KolevDiamonds.Core.Models.InvestmentDiamond;
using KolevDiamonds.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace KolevDiamonds.Controllers
{
    public class InvestmentDiamondController : Controller
    {
        private readonly IInvestmentDiamondService _investmentDiamondService;

        public InvestmentDiamondController(IInvestmentDiamondService investmentDiamondService)
        {
            this._investmentDiamondService = investmentDiamondService;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] ProductQueryModel query)
        {
            var model = await this._investmentDiamondService.GetFilteredInvestmentDiamondsAsync(
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
            var investmentDiamond = await _investmentDiamondService.GetByIdAsync(id);

            if (investmentDiamond == null)
            {
                return RedirectToAction(nameof(NotFoundError));
            }

            var model = new InvestmentDiamondDetailsServiceModel
            {
                Id = investmentDiamond.Id,
                Name = investmentDiamond.Name,
                ImagePath = investmentDiamond.ImagePath,
                Price = investmentDiamond.Price,
                Carats = investmentDiamond.Carats,
                Colour = investmentDiamond.Colour,
                Clarity = investmentDiamond.Clarity,
                Cut = investmentDiamond.Cut,
                CertifyingLaboratory = investmentDiamond.CertifyingLaboratory,
                Proportions = investmentDiamond.Proportions
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
