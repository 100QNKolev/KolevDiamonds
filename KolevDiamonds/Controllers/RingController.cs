﻿using KolevDiamonds.Core.Contracts.Ring;
using KolevDiamonds.Core.Models;
using KolevDiamonds.Core.Models.Ring;
using KolevDiamonds.Core.Services.Ring;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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
        public async Task<IActionResult> All(decimal? priceFilter)
        {
            if (priceFilter != null) 
            {
                var models = await this._ringService.GetFilteredRingsAsync((decimal)priceFilter);

                return View(models);
            }

            var model = await this._ringService
                .AllRings();

            ViewBag.PriceFilter = 0;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var ring = await _ringService.GetByIdAsync(id);

            if (ring == null) 
            {
                return RedirectToAction(nameof(NotFoundError));
            }

            var model = new RingDetailsServiceModel
            {
                Id = ring.Id,
                Name = ring.Name,
                ImagePath = ring.ImagePath,
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

        //[HttpPost]
        //public async Task<IActionResult> Buy(int id) 
        //{
            
        //}

        [HttpGet]
        public IActionResult NotFoundError()
        {
            // Redirect to the custom error page for 500 Internal Server Error
            return View("Error404");
        }
    }
}
