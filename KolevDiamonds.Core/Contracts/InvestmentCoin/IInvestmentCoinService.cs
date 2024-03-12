using KolevDiamonds.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Contracts.InvestmentCoin
{
    public interface IInvestmentCoinService
    {
        Task<IEnumerable<ProductIndexServiceModel>> AllInvestmentCoins();

        Task<Infrastructure.Data.Models.InvestmentCoin> GetByIdAsync(int id);
    }
}
