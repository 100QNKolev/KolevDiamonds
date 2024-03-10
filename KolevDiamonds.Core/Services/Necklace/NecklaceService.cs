using KolevDiamonds.Core.Contracts.Necklace;
using KolevDiamonds.Core.Models;
using KolevDiamonds.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Services.Necklace
{
    public class NecklaceService : INecklaceService
    {
        private readonly IRepository _repository;

        public NecklaceService(IRepository repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<ProductIndexServiceModel>> AllNecklaces()
        {
            return await this._repository
                .AllReadOnly<Infrastructure.Data.Models.Necklace>()
                .OrderByDescending(r => r.NecklaceId)
                .Select(r => new ProductIndexServiceModel()
                {
                    Id = r.NecklaceId,
                    Name = r.NecklaceName,
                    ImagePath = r.NecklaceImagePath,
                    Price = r.Price
                })
                .ToListAsync();
        }
    }
}
