﻿using KolevDiamonds.Core.Contracts.Necklace;
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
                .OrderByDescending(r => r.Id)
                .Select(r => new ProductIndexServiceModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    ImagePath = r.ImagePath,
                    Price = r.Price
                })
                .ToListAsync();
        }

        public async Task<Infrastructure.Data.Models.Necklace?> GetByIdAsync(int id)
        {
            return await this._repository
                .AllReadOnly<Infrastructure.Data.Models.Necklace>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<ProductIndexServiceModel>> GetFilteredRingsAsync(decimal priceFilter)
        {
            return await this._repository
                .AllReadOnly<Infrastructure.Data.Models.Necklace>()
                .Where(r => r.Price <= priceFilter)
                .OrderByDescending(r => r.Id)
                .Select(r => new ProductIndexServiceModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    ImagePath = r.ImagePath,
                    Price = r.Price
                })
                .ToListAsync();
        }
    }
}
