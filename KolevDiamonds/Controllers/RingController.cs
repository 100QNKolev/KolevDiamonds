using KolevDiamonds.Core.Contracts.Ring;
using KolevDiamonds.Core.Models;
using KolevDiamonds.Core.Models.Necklace;
using KolevDiamonds.Core.Models.Ring;
using KolevDiamonds.Core.Services.Ring;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Diagnostics;

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
        public async Task<IActionResult> All([FromQuery] ProductQueryModel query)
        {
            var model = await this._ringService.GetFilteredRingsAsync(
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
        public async Task<IActionResult> Details(int id)
        {
            var ring = await _ringService.GetByIdAsync(id);

            if (ring == null)
            {
                return NotFound();
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
                Purity = ring.Purity,
            };

            return View(model);
        }

    }
}
