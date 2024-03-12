using KolevDiamonds.Core.Contracts.Necklace;
using KolevDiamonds.Core.Models.Necklace;
using Microsoft.AspNetCore.Mvc;

namespace KolevDiamonds.Controllers
{
    public class NecklaceController : Controller
    {
        private readonly INecklaceService _necklaceService;

        public NecklaceController(INecklaceService necklaceService)
        {
            this._necklaceService = necklaceService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await this._necklaceService.AllNecklaces();

            ViewBag.PriceFilter = 0;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var necklace = await _necklaceService.GetByIdAsync(id);

            var model = new NecklaceDetailsServiceModel
            {
                NecklaceId = necklace.Id,
                NecklaceName = necklace.Name,
                NecklaceImagePath = necklace.ImagePath,
                Price = necklace.Price,
                Metal = necklace.Metal,
                Carats = necklace.Carats,
                Colour = necklace.Colour,
                Clarity = necklace.Clarity,
                Cut = necklace.Cut,
                Purity = necklace.Purity,
                Length = necklace.Length
            };

            return View(model);
        }
    }
}
