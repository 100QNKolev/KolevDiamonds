using KolevDiamonds.Core.Contracts.Ring;
using KolevDiamonds.Core.Models;
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
                .AllRings();

            ViewBag.PriceFilter = 0;

            return View(model);
        }
    }
}
