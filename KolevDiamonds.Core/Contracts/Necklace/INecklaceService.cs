using KolevDiamonds.Core.Models;
using KolevDiamonds.Core.Models.Necklace;
using KolevDiamonds.Core.Models.Ring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Contracts.Necklace
{
    public interface INecklaceService : IService<NecklaceModel>
    {
        Task<IEnumerable<ProductIndexServiceModel>> AllNecklaces();

        Task<Infrastructure.Data.Models.Necklace?> GetByIdAsync(int id);

        Task<Infrastructure.Data.Models.Necklace?> GetByIdAsyncAsTracking(int id);

        Task<ProductQueryModel> GetFilteredNecklacesAsync(decimal? priceFilter, int currentPage, int productsPerPage, bool isForSale = true);

        Task Delete(int necklaceId);
    }
}
