using KolevDiamonds.Core.Contracts.Necklace;
using KolevDiamonds.Core.Models.Necklace;
using KolevDiamonds.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
        public async Task<IActionResult> All(decimal? priceFilter)
        {
            if (priceFilter != null)
            {
                var models = await this._necklaceService.GetFilteredRingsAsync((decimal)priceFilter);

                return View(models);
            }

            var model = await this._necklaceService.AllNecklaces();

            ViewBag.PriceFilter = 0;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var necklace = await _necklaceService.GetByIdAsync(id);

            if (necklace == null)
            {
                return RedirectToAction(nameof(NotFoundError));
            }

            var model = new NecklaceDetailsServiceModel
            {
                Id = necklace.Id,
                Name = necklace.Name,
                ImagePath = necklace.ImagePath,
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
