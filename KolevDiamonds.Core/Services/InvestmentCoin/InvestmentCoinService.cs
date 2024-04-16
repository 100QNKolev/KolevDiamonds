using KolevDiamonds.Core.Contracts.InvestmentCoin;
using KolevDiamonds.Core.Models;
using KolevDiamonds.Core.Models.InvestmentCoin;
using KolevDiamonds.Core.Models.MetalBar;
using KolevDiamonds.Core.Models.Necklace;
using KolevDiamonds.Core.Services.Ring;
using KolevDiamonds.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KolevDiamonds.Core.Services.InvestmentCoin
{
    public class InvestmentCoinService : IInvestmentCoinService
    {
        private readonly IRepository _repository;
        private readonly ILogger logger;

        public InvestmentCoinService(IRepository repository, ILogger<InvestmentCoinService> _logger)
        {
            this._repository = repository;
            this.logger = _logger;
        }

        public async Task<Infrastructure.Data.Models.InvestmentCoin?> GetByIdAsync(int id)
        {
            return await this._repository
                .AllReadOnly<Infrastructure.Data.Models.InvestmentCoin>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Infrastructure.Data.Models.InvestmentCoin?> GetByIdAsyncAsTracking(int id)
        {
            return await this._repository
                .All<Infrastructure.Data.Models.InvestmentCoin>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<ProductQueryModel> GetFilteredInvestmentCoinsAsync(decimal? priceFilter, int currentPage = 1, int productsPerPage = 1, bool isForSale = true)
        {
            var InvestmentCoins = this._repository
                .AllReadOnly<Infrastructure.Data.Models.InvestmentCoin>()
                .Where(r => r.IsForSale == isForSale)
                .OrderByDescending(r => r.Id)
                .Select(r => new ProductIndexServiceModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    ImagePath = r.ImagePath,
                    Price = r.Price,
                    ProductType = nameof(InvestmentCoin),
                    IsForSale = r.IsForSale
                });

            if (priceFilter != null)
            {
                InvestmentCoins = InvestmentCoins
                        .Where(r => r.Price <= priceFilter);
            }

            var InvestmentCoinsToShow = await InvestmentCoins
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .ToListAsync();

            return new ProductQueryModel()
            {
                Products = InvestmentCoinsToShow,
                TotalProductCount = InvestmentCoins.Count(),
                ProductType = nameof(InvestmentCoin)
            };

        }

        public async Task Delete(int Id)
        {
            var InvestmentCoin = await GetByIdAsyncAsTracking(Id);

            if (InvestmentCoin != null)
            {
                InvestmentCoin.IsForSale = false;

                await _repository.SaveChangesAsync();
            }
        }

        public async Task Create(InvestmentCoinModel model)
        {
            var investmentCoin = new Infrastructure.Data.Models.InvestmentCoin
            {
                Name = model.Name,
                ImagePath = model.ImagePath,
                Price = model.Price,
                Metal = model.Metal,
                Purity = model.Purity,
                Weight = model.Weight,
                Quality = model.Quality,
                Circulation = model.Circulation,
                Diameter = model.Diameter,
                LegalTender = model.LegalTender,
                Manufacturer = model.Manufacturer,
                Packaging = model.Packaging,
                IsForSale = model.IsForSale
            };

            try
            {
                await _repository.AddAsync(investmentCoin);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Create), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }
        }

        public async Task Update(int id, InvestmentCoinModel model)
        {
            var investmentCoin = await GetByIdAsyncAsTracking(id);

            if (investmentCoin == null)
            {
                throw new ApplicationException("Database failed to find investment coin info");
            }

            investmentCoin.Name = model.Name;
            investmentCoin.ImagePath = model.ImagePath;
            investmentCoin.Price = model.Price;
            investmentCoin.Metal = model.Metal;
            investmentCoin.Purity = model.Purity;
            investmentCoin.Weight = model.Weight;
            investmentCoin.Quality = model.Quality;
            investmentCoin.Circulation = model.Circulation;
            investmentCoin.Diameter = model.Diameter;
            investmentCoin.LegalTender = model.LegalTender;
            investmentCoin.Manufacturer = model.Manufacturer;
            investmentCoin.Packaging = model.Packaging;
            investmentCoin.IsForSale = model.IsForSale;

            try
            {
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Create), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }
        }
    }
}
