using KolevDiamonds.Core.Models;
using KolevDiamonds.Core.Models.MetalBar;
using KolevDiamonds.Core.Models.Ring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Contracts.MetalBar
{
    public interface IMetalBarService : IService<MetalBarModel>
    {
        Task<IEnumerable<ProductIndexServiceModel>> AllMetalBars();

        Task<Infrastructure.Data.Models.MetalBar?> GetByIdAsync(int id);

        Task<Infrastructure.Data.Models.MetalBar?> GetByIdAsyncAsTracking(int id);

        Task<ProductQueryModel> GetFilteredMetalBarsAsync(decimal? priceFilter, int currentPage, int productsPerPage, bool isForSale = true);

        Task Delete(int metalBarId);
    }
}
