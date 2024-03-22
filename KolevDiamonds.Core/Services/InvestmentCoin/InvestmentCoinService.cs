using KolevDiamonds.Core.Contracts.InvestmentCoin;
using KolevDiamonds.Core.Models;
using KolevDiamonds.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Services.InvestmentCoin
{
    public class InvestmentCoinService : IInvestmentCoinService
    {
        private readonly IRepository _repository;

        public InvestmentCoinService(IRepository repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<ProductIndexServiceModel>> AllInvestmentCoins()
        {
            return await this._repository
                .AllReadOnly<Infrastructure.Data.Models.InvestmentCoin>()
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

        public async Task<Infrastructure.Data.Models.InvestmentCoin?> GetByIdAsync(int id)
        {
            return await this._repository
                .AllReadOnly<Infrastructure.Data.Models.InvestmentCoin>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<ProductQueryModel> GetFilteredInvestmentCoinsAsync(decimal? priceFilter, int currentPage = 1, int productsPerPage = 1)
        {
            var InvestmentCoins = this._repository
                .AllReadOnly<Infrastructure.Data.Models.InvestmentCoin>()
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
                InvestmentCoins = InvestmentCoins
                        .Where(r => r.Price <= priceFilter);
            }

            var InvestmentCoinsToShow = await InvestmentCoins
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .ToListAsync();

            return new ProductQueryModel()
            {
                Products = InvestmentCoinsToShow,
                TotalProductCount = InvestmentCoins.Count(),
                ProductType = nameof(InvestmentCoin)
            };
        }
    }
}
