using KolevDiamonds.Core.Contracts.InvestmentDiamond;
using KolevDiamonds.Core.Models;
using KolevDiamonds.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Services.InvestmentDiamond
{
    public class InvestmentDiamondService : IInvestmentDiamondService
    {
        private readonly IRepository _repository;

        public InvestmentDiamondService(IRepository repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<ProductIndexServiceModel>> AllInvestmentDiamonds()
        {
            return await this._repository
                .AllReadOnly<Infrastructure.Data.Models.InvestmentDiamond>()
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

        public async Task<Infrastructure.Data.Models.InvestmentDiamond?> GetByIdAsync(int id)
        {
            return await this._repository
                .AllReadOnly<Infrastructure.Data.Models.InvestmentDiamond>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<ProductQueryModel> GetFilteredInvestmentDiamondsAsync(decimal? priceFilter, int currentPage = 1, int productsPerPage = 1)
        {
            var InvestmentDiamonds = this._repository
                .AllReadOnly<Infrastructure.Data.Models.InvestmentDiamond>()
                .OrderByDescending(r => r.Id)
                .Select(r => new ProductIndexServiceModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    ImagePath = r.ImagePath,
                    Price = r.Price
                });

            if (priceFilter != null)
            {
                InvestmentDiamonds = InvestmentDiamonds
                        .Where(r => r.Price <= priceFilter);
            }

            var InvestmentDiamondsToShow = await InvestmentDiamonds
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .ToListAsync();

            return new ProductQueryModel()
            {
                Products = InvestmentDiamondsToShow,
                TotalProductCount = InvestmentDiamonds.Count(),
                ProductType = nameof(InvestmentDiamond)
            };
        }
    }
}
