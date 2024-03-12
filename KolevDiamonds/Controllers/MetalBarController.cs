﻿using KolevDiamonds.Core.Contracts.MetalBar;
using KolevDiamonds.Core.Models.MetalBar;
using KolevDiamonds.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
        public async Task<IActionResult> All(decimal? priceFilter)
        {
            if (priceFilter != null)
            {
                var models = await this._metalBarService.GetFilteredRingsAsync((decimal)priceFilter);

                return View(models);
            }

            var model = await this._metalBarService.AllMetalBars();

            ViewBag.PriceFilter = 0;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var metalBar = await _metalBarService.GetByIdAsync(id);

            if (metalBar == null)
            {
                return RedirectToAction(nameof(NotFoundError));
            }

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
