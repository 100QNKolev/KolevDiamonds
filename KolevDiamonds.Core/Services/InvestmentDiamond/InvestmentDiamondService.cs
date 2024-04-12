using KolevDiamonds.Core.Contracts.InvestmentDiamond;
using KolevDiamonds.Core.Models;
using KolevDiamonds.Core.Models.InvestmentDiamond;
using KolevDiamonds.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KolevDiamonds.Core.Services.InvestmentDiamond
{
    public class InvestmentDiamondService : IInvestmentDiamondService
    {
        private readonly IRepository _repository;
        private readonly ILogger logger;

        public InvestmentDiamondService(IRepository repository, ILogger<InvestmentDiamondService> _logger)
        {
            this._repository = repository;
            this.logger = _logger;
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
                    Price = r.Price,
                    ProductType = nameof(InvestmentDiamond)
                })
                .ToListAsync();
        }

        public async Task<Infrastructure.Data.Models.InvestmentDiamond?> GetByIdAsync(int id)
        {
            return await this._repository
                .AllReadOnly<Infrastructure.Data.Models.InvestmentDiamond>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Infrastructure.Data.Models.InvestmentDiamond?> GetByIdAsyncAsTracking(int id)
        {
            return await this._repository
                .All<Infrastructure.Data.Models.InvestmentDiamond>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }
        public async Task<ProductQueryModel> GetFilteredInvestmentDiamondsAsync(decimal? priceFilter, int currentPage = 1, int productsPerPage = 1, bool isForSale = true)
        {
            var InvestmentDiamonds = this._repository
                .AllReadOnly<Infrastructure.Data.Models.InvestmentDiamond>()
                .Where(r => r.IsForSale == isForSale)
                .OrderByDescending(r => r.Id)
                .Select(r => new ProductIndexServiceModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    ImagePath = r.ImagePath,
                    Price = r.Price,
                    ProductType = nameof(InvestmentDiamond),
                    IsForSale = r.IsForSale
                });

            if (priceFilter != null)
            {
                InvestmentDiamonds = InvestmentDiamonds
                        .Where(r => r.Price <= priceFilter);
            }

            var InvestmentDiamondsToShow = await InvestmentDiamonds
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .ToListAsync();

            return new ProductQueryModel()
            {
                Products = InvestmentDiamondsToShow,
                TotalProductCount = InvestmentDiamonds.Count(),
                ProductType = nameof(InvestmentDiamond)
            };
        }

        public async Task Delete(int investmentDiamondId)
        {
            var InvestmentDiamond = await GetByIdAsyncAsTracking(investmentDiamondId);

            if (InvestmentDiamond != null)
            {
                InvestmentDiamond.IsForSale = false;

                await _repository.SaveChangesAsync();
            }
        }

        public async Task Create(InvestmentDiamondModel model)
        {
            var diamond = new Infrastructure.Data.Models.InvestmentDiamond
            {
                Name = model.Name,
                ImagePath = model.ImagePath,
                Price = model.Price,
                Carats = model.Carats,
                Colour = model.Colour,
                Clarity = model.Clarity,
                Cut = model.Cut,
                CertifyingLaboratory = model.CertifyingLaboratory,
                Proportions = model.Proportions,
                IsForSale = model.IsForSale
            };

            try
            {
                await _repository.AddAsync(diamond);
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
