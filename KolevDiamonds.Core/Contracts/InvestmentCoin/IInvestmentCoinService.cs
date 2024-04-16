using KolevDiamonds.Core.Models;
using KolevDiamonds.Core.Models.InvestmentCoin;
using KolevDiamonds.Core.Models.Ring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Contracts.InvestmentCoin
{
    public interface IInvestmentCoinService : IService<InvestmentCoinModel>
    {
        Task<Infrastructure.Data.Models.InvestmentCoin?> GetByIdAsync(int id);

        Task<Infrastructure.Data.Models.InvestmentCoin?> GetByIdAsyncAsTracking(int id);

        Task<ProductQueryModel> GetFilteredInvestmentCoinsAsync(decimal? priceFilter, int currentPage, int productsPerPage, bool isForSale = true);
    }
}
