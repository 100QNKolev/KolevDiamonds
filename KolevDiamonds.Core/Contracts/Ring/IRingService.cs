using KolevDiamonds.Core.Models;
using KolevDiamonds.Core.Models.Ring;

namespace KolevDiamonds.Core.Contracts.Ring
{
    public interface IRingService
    {
       Task<IEnumerable<ProductIndexServiceModel>> AllRings();

       Task<IEnumerable<ProductIndexServiceModel>> AllRingsReadOnly();

       Task<Infrastructure.Data.Models.Ring> GetByIdAsync(int id);
    }
}
