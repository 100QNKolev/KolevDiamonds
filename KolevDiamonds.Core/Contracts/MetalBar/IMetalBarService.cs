using KolevDiamonds.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Contracts.MetalBar
{
    public interface IMetalBarService
    {
        Task<IEnumerable<ProductIndexServiceModel>> AllMetalBars();

        Task<Infrastructure.Data.Models.MetalBar?> GetByIdAsync(int id);

        Task<Infrastructure.Data.Models.MetalBar?> GetByIdAsyncAsTracking(int id);

        Task<ProductQueryModel> GetFilteredMetalBarsAsync(decimal? priceFilter, int currentPage, int productsPerPage);

        Task Delete(int ringId);
    }
}
