using KolevDiamonds.Core.Contracts.InvestmentDiamond;
using KolevDiamonds.Core.Models;
using KolevDiamonds.Core.Models.InvestmentDiamond;
using KolevDiamonds.Core.Extensions;
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
            query.ProductType = model.ProductType;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, string information)
        {
            var investmentDiamond = await _investmentDiamondService.GetByIdAsync(id);

            if (investmentDiamond == null)
            {
                return NotFound();
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

            if (model.GetInformation() != information)
            {
                return NotFound();
            }

            return View(model);
        }

    }
}
