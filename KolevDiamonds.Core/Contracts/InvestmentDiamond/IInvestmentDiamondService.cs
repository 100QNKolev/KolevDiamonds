using KolevDiamonds.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Contracts.InvestmentDiamond
{
    public interface IInvestmentDiamondService
    {
        Task<IEnumerable<ProductIndexServiceModel>> AllInvestmentDiamonds();

        Task<Infrastructure.Data.Models.InvestmentDiamond?> GetByIdAsync(int id);

        Task<Infrastructure.Data.Models.InvestmentDiamond?> GetByIdAsyncAsTracking(int id);

        Task<ProductQueryModel> GetFilteredInvestmentDiamondsAsync(decimal? priceFilter, int currentPage, int productsPerPage, bool isForSale = true);

        Task Delete(int ringId);
    }
}
