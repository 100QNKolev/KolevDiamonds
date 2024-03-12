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

        public async Task<Infrastructure.Data.Models.InvestmentCoin> GetByIdAsync(int id)
        {
            return await this._repository
                .AllReadOnly<Infrastructure.Data.Models.InvestmentCoin>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
