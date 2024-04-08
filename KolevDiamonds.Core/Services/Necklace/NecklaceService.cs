using KolevDiamonds.Core.Contracts.Necklace;
using KolevDiamonds.Core.Models;
using KolevDiamonds.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Services.Necklace
{
    public class NecklaceService : INecklaceService
    {
        private readonly IRepository _repository;

        public NecklaceService(IRepository repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<ProductIndexServiceModel>> AllNecklaces()
        {
            return await this._repository
                .AllReadOnly<Infrastructure.Data.Models.Necklace>()
                .OrderByDescending(r => r.Id)
                .Select(r => new ProductIndexServiceModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    ImagePath = r.ImagePath,
                    Price = r.Price,
                    ProductType = nameof(Necklace)
                })
                .ToListAsync();
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
    }
}
