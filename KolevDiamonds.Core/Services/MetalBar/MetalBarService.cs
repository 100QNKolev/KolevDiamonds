using KolevDiamonds.Core.Contracts.MetalBar;
using KolevDiamonds.Core.Models;
using KolevDiamonds.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Services.MetalBar
{
    public class MetalBarService : IMetalBarService
    {
        private readonly IRepository _repository;

        public MetalBarService(IRepository repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<ProductIndexServiceModel>> AllMetalBars()
        {
            return await this._repository
                .AllReadOnly<Infrastructure.Data.Models.MetalBar>()
                .OrderByDescending(r => r.BarId)
                .Select(r => new ProductIndexServiceModel()
                {
                    Id = r.BarId,
                    Name = r.MetalBarName,
                    ImagePath = r.MetalBarImagePath,
                    Price = r.Price
                })
                .ToListAsync();
        }
    }
}
