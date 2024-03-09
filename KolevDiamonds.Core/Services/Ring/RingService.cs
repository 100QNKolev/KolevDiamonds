using KolevDiamonds.Core.Contracts.Ring;
using KolevDiamonds.Core.Models;
using KolevDiamonds.Infrastructure.Data;
using KolevDiamonds.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace KolevDiamonds.Core.Services.Ring
{
    public class RingService : IRingService
    {
        private readonly IRepository _repository;

        public RingService(IRepository repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<RingIndexServiceModel>> AllRings()
        {
            return await this._repository
                .AllReadOnly<Infrastructure.Data.Models.Ring>()
                .OrderByDescending(r => r.RingId)
                .Select(r => new RingIndexServiceModel() 
                {
                
                })
                .ToListAsync();
        }
    }
}
