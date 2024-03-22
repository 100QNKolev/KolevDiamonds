using KolevDiamonds.Core.Contracts.MetalBar;
using KolevDiamonds.Core.Models;
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
        public async Task<IActionResult> All([FromQuery] ProductQueryModel query)
        {
            var model = await this._metalBarService.GetFilteredMetalBarsAsync(
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
