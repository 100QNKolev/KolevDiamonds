using KolevDiamonds.Core.Models;
using KolevDiamonds.Core.Models.InvestmentDiamond;
using KolevDiamonds.Core.Models.Ring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Contracts.InvestmentDiamond
{
    public interface IInvestmentDiamondService : IService<InvestmentDiamondModel>
    {
        Task<Infrastructure.Data.Models.InvestmentDiamond?> GetByIdAsync(int id);

        Task<Infrastructure.Data.Models.InvestmentDiamond?> GetByIdAsyncAsTracking(int id);

        Task<ProductQueryModel> GetFilteredInvestmentDiamondsAsync(decimal? priceFilter, int currentPage, int productsPerPage, bool isForSale = true);
    }
}
