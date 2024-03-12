﻿using KolevDiamonds.Core.Contracts.InvestmentDiamond;
using KolevDiamonds.Core.Models;
using KolevDiamonds.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Services.InvestmentDiamond
{
    public class InvestmentDiamondService : IInvestmentDiamondService
    {
        private readonly IRepository _repository;

        public InvestmentDiamondService(IRepository repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<ProductIndexServiceModel>> AllInvestmentDiamonds()
        {
            return await this._repository
                .AllReadOnly<Infrastructure.Data.Models.InvestmentDiamond>()
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

        public async Task<Infrastructure.Data.Models.InvestmentDiamond?> GetByIdAsync(int id)
        {
            return await this._repository
                .AllReadOnly<Infrastructure.Data.Models.InvestmentDiamond>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<ProductIndexServiceModel>> GetFilteredRingsAsync(decimal priceFilter)
        {
            return await this._repository
                .AllReadOnly<Infrastructure.Data.Models.InvestmentDiamond>()
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
