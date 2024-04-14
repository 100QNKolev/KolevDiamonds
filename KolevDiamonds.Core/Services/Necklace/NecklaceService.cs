using KolevDiamonds.Core.Contracts.Necklace;
using KolevDiamonds.Core.Models;
using KolevDiamonds.Core.Models.Necklace;
using KolevDiamonds.Core.Services.Ring;
using KolevDiamonds.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KolevDiamonds.Core.Services.Necklace
{
    public class NecklaceService : INecklaceService
    {
        private readonly IRepository _repository;
        private readonly ILogger logger;

        public NecklaceService(IRepository repository, ILogger<RingService> _logger)
        {
            this._repository = repository;
            this.logger = _logger;
        }

        public async Task<Infrastructure.Data.Models.Necklace?> GetByIdAsync(int id)
        {
            return await this._repository
                .AllReadOnly<Infrastructure.Data.Models.Necklace>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Infrastructure.Data.Models.Necklace?> GetByIdAsyncAsTracking(int id)
        {
            return await this._repository
                .All<Infrastructure.Data.Models.Necklace>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<ProductQueryModel> GetFilteredNecklacesAsync(decimal? priceFilter, int currentPage = 1, int productsPerPage = 1, bool isForSale = true)
        {
            var necklaces = this._repository
                .AllReadOnly<Infrastructure.Data.Models.Necklace>()
                .Where(r => r.IsForSale == isForSale)
                .OrderByDescending(r => r.Id)
                .Select(r => new ProductIndexServiceModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    ImagePath = r.ImagePath,
                    Price = r.Price,
                    ProductType = nameof(Necklace),
                    IsForSale = r.IsForSale
                });

            if (priceFilter != null)
            {
                necklaces = necklaces
                        .Where(r => r.Price <= priceFilter);
            }

            var necklacesToShow = await necklaces
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .ToListAsync();

            return new ProductQueryModel()
            {
                Products = necklacesToShow,
                TotalProductCount = necklaces.Count(),
                ProductType = nameof(Necklace)
            };
        }

        public async Task Delete(int necklaceId)
        {
            var necklace = await GetByIdAsyncAsTracking(necklaceId);

            if (necklace != null)
            {
                necklace.IsForSale = false;

                await _repository.SaveChangesAsync();
            }
        }

        public async Task Create(NecklaceModel model)
        {
            var necklace = new Infrastructure.Data.Models.Necklace
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
                IsForSale = model.IsForSale,
                Length = model.Length,
            };

            try
            {
                await _repository.AddAsync(necklace);
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
