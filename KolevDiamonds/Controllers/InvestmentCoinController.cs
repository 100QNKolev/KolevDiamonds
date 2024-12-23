﻿using KolevDiamonds.Core.Contracts.InvestmentCoin;
using KolevDiamonds.Core.Models;
using KolevDiamonds.Core.Models.InvestmentCoin;
using KolevDiamonds.Core.Extensions;
using KolevDiamonds.Core.Extensions;
using KolevDiamonds.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace KolevDiamonds.Controllers
{
    public class InvestmentCoinController : Controller
    {
        private readonly IInvestmentCoinService _investmentCoinService;

        public InvestmentCoinController(IInvestmentCoinService investmentCoinService)
        {
            this._investmentCoinService = investmentCoinService;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] ProductQueryModel query)
        {
            var model = await this._investmentCoinService.GetFilteredInvestmentCoinsAsync(
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
        public async Task<IActionResult> Details(int id, string information)
        {
            var investmentCoin = await _investmentCoinService.GetByIdAsync(id);

            if (investmentCoin == null)
            {
                return NotFound();
            }

            var model = new InvestmentCoinDetailsServiceModel
            {
                Id = investmentCoin.Id,
                Name = investmentCoin.Name,
                ImagePath = investmentCoin.ImagePath,
                Price = investmentCoin.Price,
                Metal = investmentCoin.Metal,
                Weight = investmentCoin.Weight,
                Purity = investmentCoin.Purity,
                Quality = investmentCoin.Quality,
                Circulation = investmentCoin.Circulation,
                Diameter = investmentCoin.Diameter,
                LegalTender = investmentCoin.LegalTender,
                Manufacturer = investmentCoin.Manufacturer,
                Packaging = investmentCoin.Packaging
            };

            if (model.GetInformation() != information)
            {
                return NotFound();
            }

            return View(model);
        }

    }
}
