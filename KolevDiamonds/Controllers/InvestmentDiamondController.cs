using KolevDiamonds.Core.Contracts.InvestmentDiamond;
using KolevDiamonds.Core.Models.InvestmentDiamond;
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
        public async Task<IActionResult> Index()
        {
            var model = await this._investmentDiamondService.AllInvestmentDiamonds();

            ViewBag.PriceFilter = 0;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var investmentDiamond = await _investmentDiamondService.GetByIdAsync(id);

            var model = new InvestmentDiamondDetailsServiceModel
            {
                DiamondId = investmentDiamond.Id,
                DiamondName = investmentDiamond.Name,
                DiamondImagePath = investmentDiamond.ImagePath,
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

    }
}
