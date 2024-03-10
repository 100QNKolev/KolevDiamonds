using KolevDiamonds.Core.Models;

namespace KolevDiamonds.Core.Contracts.Ring
{
    public interface IRingService
    {
       Task<IEnumerable<ProductIndexServiceModel>> AllRings();
    }
}
