using KolevDiamonds.Core.Models;

namespace KolevDiamonds.Core.Contracts
{
    public interface IAdminJewelryServiceContract
    {
       Task<IEnumerable<ProductIndexServiceModel>> GetAllJewelry(ProductQueryModel query);
    }
}
