using KolevDiamonds.Core.Models;

namespace KolevDiamonds.Areas.Admin.Contracts
{
    public interface IAdminJewelryServiceContract
    {
       Task<IEnumerable<ProductIndexServiceModel>> GetAllJewelry(ProductQueryModel query);
    }
}
