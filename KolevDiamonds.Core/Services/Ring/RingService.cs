using KolevDiamonds.Core.Contracts.Ring;
using KolevDiamonds.Core.Models;
using KolevDiamonds.Core.Models.Ring;
using KolevDiamonds.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KolevDiamonds.Core.Services.Ring
{
    public class RingService : IRingService
    {
        private readonly IRepository _repository;
        private readonly ILogger logger;

        public RingService(IRepository repository, ILogger<RingService> _logger)
        {
            this._repository = repository;
            this.logger = _logger;
        }

        public async Task<IEnumerable<ProductIndexServiceModel>> AllRings()
        {
            return await this._repository
                .AllReadOnly<Infrastructure.Data.Models.Ring>()
                .OrderByDescending(r => r.Id)
                .Select(r => new ProductIndexServiceModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    ImagePath = r.ImagePath,
                    Price = r.Price,
                    ProductType = nameof(Ring)
                })
                .ToListAsync();
        }

        public async Task<Infrastructure.Data.Models.Ring?> GetByIdAsync(int id)
        {
            return await this._repository
                .AllReadOnly<Infrastructure.Data.Models.Ring>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Infrastructure.Data.Models.Ring?> GetByIdAsyncAsTracking(int id)
        {
            return await this._repository
                .All<Infrastructure.Data.Models.Ring>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<ProductQueryModel> GetFilteredRingsAsync(decimal? priceFilter, int currentPage = 1, int productsPerPage = 1, bool isForSale = true) 
        {
            var rings = this._repository
                .AllReadOnly<Infrastructure.Data.Models.Ring>()
                .Where(r => r.IsForSale == isForSale)
                .OrderByDescending(r => r.Id)
                .Select(r => new ProductIndexServiceModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    ImagePath = r.ImagePath,
                    Price = r.Price,
                    ProductType = nameof(Ring),
                    IsForSale = r.IsForSale
                });

            if (priceFilter != null)
            {
                rings = rings
                        .Where(r => r.Price <= priceFilter);
            }

            var ringsToShow = await rings
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .ToListAsync();
                
            return new ProductQueryModel()
            {
                Products = ringsToShow,
                TotalProductCount = rings.Count(),
                ProductType = nameof(Ring)
            };
        }

        public async Task Delete(int ringId)
        {
            var ring = await GetByIdAsyncAsTracking(ringId);

            if (ring != null) 
            {
                ring.IsForSale = false;

                await _repository.SaveChangesAsync();
            }
        }

        public async Task Create(RingModel model)
        {
            var ring = new Infrastructure.Data.Models.Ring
            {
                Name = model.Name,
                ImagePath = model.ImagePath,
                Price = model.Price,
                Carats = model.Carats,
                Colour = model.Colour,
                Clarity = model.Clarity,
                Cut = model.Cut,
                Metal = model.Metal,
                Purity = model.Purity,
                IsForSale = model.IsForSale
            };

            try
            {
                await _repository.AddAsync(ring);
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
