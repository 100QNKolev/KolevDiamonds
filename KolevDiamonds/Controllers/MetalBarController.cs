using KolevDiamonds.Core.Contracts.MetalBar;
using KolevDiamonds.Core.Models.MetalBar;
using Microsoft.AspNetCore.Mvc;

namespace KolevDiamonds.Controllers
{
    public class MetalBarController : Controller
    {
        private readonly IMetalBarService _metalBarService;

        public MetalBarController(IMetalBarService metalBarService)
        {
            this._metalBarService = metalBarService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await this._metalBarService.AllMetalBars();

            ViewBag.PriceFilter = 0;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var metalBar = await _metalBarService.GetByIdAsync(id);

            var model = new MetalBarDetailsServiceModel
            {
                Id = metalBar.Id,
                Name = metalBar.Name,
                ImagePath = metalBar.ImagePath,
                Price = metalBar.Price,
                Metal = metalBar.Metal,
                Weight = metalBar.Weight,
                Dimensions = metalBar.Dimensions,
                Purity = metalBar.Purity
            };

            return View(model);
        }

    }
}
