using KolevDiamonds.Core.Contracts.MetalBar;
using KolevDiamonds.Core.Models;
using KolevDiamonds.Core.Models.MetalBar;
using KolevDiamonds.Core.Models.Necklace;
using KolevDiamonds.Core.Services.Ring;
using KolevDiamonds.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger logger;

        public MetalBarService(IRepository repository, ILogger<MetalBarService> _logger)
        {
            this._repository = repository;
            this.logger = _logger;
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

        public async Task Delete(int Id)
        {
            var metalBar = await GetByIdAsyncAsTracking(Id);

            if (metalBar != null)
            {
                metalBar.IsForSale = false;

                await _repository.SaveChangesAsync();
            }
        }

        public async Task Create(MetalBarModel model)
        {
            var metalBar = new Infrastructure.Data.Models.MetalBar
            {
                Name = model.Name,
                ImagePath = model.ImagePath,
                Price = model.Price,
                Metal = model.Metal,
                Purity = model.Purity,
                IsForSale = model.IsForSale,
                Weight = model.Weight,
                Dimensions = model.Dimensions,
            };

            try
            {
                await _repository.AddAsync(metalBar);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Create), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }
        }
    }
}
