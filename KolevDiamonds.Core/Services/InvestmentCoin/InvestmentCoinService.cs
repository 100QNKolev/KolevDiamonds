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
                .OrderByDescending(r => r.CoinId)
                .Select(r => new ProductIndexServiceModel()
                {
                    Id = r.CoinId,
                    Name = r.CoinName,
                    ImagePath = r.CoinImagePath,
                    Price = r.Price
                })
                .ToListAsync();
        }
    }
}
