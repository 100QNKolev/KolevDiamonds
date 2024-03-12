using KolevDiamonds.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Contracts.Necklace
{
    public interface INecklaceService
    {
        Task<IEnumerable<ProductIndexServiceModel>> AllNecklaces();

        Task<Infrastructure.Data.Models.Necklace?> GetByIdAsync(int id);

        Task<IEnumerable<ProductIndexServiceModel>> GetFilteredRingsAsync(decimal priceFilter);
    }
}
