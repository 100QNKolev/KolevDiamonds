using KolevDiamonds.Core.Contracts.MetalBar;
using KolevDiamonds.Core.Models;
using KolevDiamonds.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Services.MetalBar
{
    public class MetalBarService : IMetalBarService
    {
        private readonly IRepository _repository;

        public MetalBarService(IRepository repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<ProductIndexServiceModel>> AllMetalBars()
        {
            return await this._repository
                .AllReadOnly<Infrastructure.Data.Models.MetalBar>()
                .OrderByDescending(r => r.Id)
                .Select(r => new ProductIndexServiceModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    ImagePath = r.ImagePath,
                    Price = r.Price,
                    ProductType = nameof(MetalBar)
                })
                .ToListAsync();
        }

        public async Task<Infrastructure.Data.Models.MetalBar?> GetByIdAsync(int id)
        {
            return await this._repository
                .AllReadOnly<Infrastructure.Data.Models.MetalBar>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Infrastructure.Data.Models.MetalBar?> GetByIdAsyncAsTracking(int id)
        {
            return await this._repository
                .All<Infrastructure.Data.Models.MetalBar>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<ProductQueryModel> GetFilteredMetalBarsAsync(decimal? priceFilter, int currentPage = 1, int productsPerPage = 1, bool isForSale = true)
        {
            var metalBars = this._repository
                .AllReadOnly<Infrastructure.Data.Models.MetalBar>()
                .Where(r => r.IsForSale == isForSale)
                .OrderByDescending(r => r.Id)
                .Select(r => new ProductIndexServiceModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    ImagePath = r.ImagePath,
                    Price = r.Price,
                    ProductType = nameof(MetalBar),
                    IsForSale = r.IsForSale
                });

            if (priceFilter != null)
            {
                metalBars = metalBars
                        .Where(r => r.Price <= priceFilter);
            }

            var metalBarsToShow = await metalBars
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .ToListAsync();

            return new ProductQueryModel()
            {
                Products = metalBarsToShow,
                TotalProductCount = metalBars.Count(),
                ProductType = nameof(MetalBar)
            };
        }

        public async Task Delete(int metalBarId)
        {
            var metalBar = await GetByIdAsyncAsTracking(metalBarId);

            if (metalBar != null)
            {
                metalBar.IsForSale = false;

                await _repository.SaveChangesAsync();
            }
        }
    }
}
