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

        Task<Infrastructure.Data.Models.MetalBar> GetByIdAsync(int id);

        Task<IEnumerable<ProductIndexServiceModel>> GetFilteredRingsAsync(decimal priceFilter);
    }
}
