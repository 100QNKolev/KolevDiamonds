using KolevDiamonds.Core.Contracts.Ring;
using KolevDiamonds.Core.Models;
using KolevDiamonds.Core.Models.Ring;
using KolevDiamonds.Infrastructure.Data;
using KolevDiamonds.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace KolevDiamonds.Core.Services.Ring
{
    public class RingService : IRingService
    {
        private readonly IRepository _repository;

        public RingService(IRepository repository)
        {
            this._repository = repository;
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
                    Price = r.Price
                })
                .ToListAsync();
        }

        public async Task<Infrastructure.Data.Models.Ring?> GetByIdAsync(int id)
        {
            return await this._repository
                .AllReadOnly<Infrastructure.Data.Models.Ring>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<ProductQueryModel> GetFilteredRingsAsync(decimal? priceFilter, int currentPage = 1, int productsPerPage = 1) 
        {
            var rings = this._repository
                .AllReadOnly<Infrastructure.Data.Models.Ring>()
                .OrderByDescending(r => r.Id)
                .Select(r => new ProductIndexServiceModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    ImagePath = r.ImagePath,
                    Price = r.Price,
                    ProductType = nameof(Ring)
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
    }
}
