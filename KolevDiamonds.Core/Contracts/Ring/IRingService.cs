using KolevDiamonds.Core.Models;
using KolevDiamonds.Core.Models.Ring;

namespace KolevDiamonds.Core.Contracts.Ring
{
    public interface IRingService
    {
       Task<IEnumerable<ProductIndexServiceModel>> AllRings();

       Task<Infrastructure.Data.Models.Ring?> GetByIdAsync(int id);

       Task<ProductQueryModel> GetFilteredRingsAsync(decimal? priceFilter, int currentPage, int ringsPerPage);
    }
}
