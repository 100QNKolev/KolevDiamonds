using KolevDiamonds.Core.Contracts.Ring;
using KolevDiamonds.Core.Models;
using KolevDiamonds.Core.Models.Ring;
using KolevDiamonds.Core.Services.Ring;
using Microsoft.AspNetCore.Mvc;

namespace KolevDiamonds.Controllers
{
    public class RingController : Controller
    {
        private readonly IRingService _ringService;

        public RingController(IRingService ringService)
        {
            this._ringService = ringService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await this._ringService
                .AllRingsReadOnly();

            ViewBag.PriceFilter = 0;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var ring = await _ringService.GetByIdAsync(id);

            var model = new RingDetailsServiceModel
            {
                RingId = ring.RingId,
                RingName = ring.RingName,
                RingImagePath = ring.RingImagePath,
                Price = ring.Price,
                Metal = ring.Metal,
                Carats = ring.Carats,
                Colour = ring.Colour,
                Clarity = ring.Clarity,
                Cut = ring.Cut,
                Purity = ring.Purity
            };

            return View(model);
        }
    }
}
