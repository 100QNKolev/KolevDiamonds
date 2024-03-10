using KolevDiamonds.Infrastructure.Data.Models;
using KolevDiamonds.Infrastructure.Data.SeedDb;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KolevDiamonds.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ring> Rings { get; set; } = null!;
        public DbSet<Necklace> Necklaces { get; set; } = null!;
        public DbSet<InvestmentDiamond> InvestmentDiamonds { get; set; } = null!;
        public DbSet<InvestmentCoin> InvestmentCoins { get; set; } = null!;
        public DbSet<MetalBar> MetalBars { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var data = new SeedData();

            builder.Entity<Ring>().HasData(data.FirstRing, data.SecondRing, data.ThirdRing);
            builder.Entity<Necklace>().HasData(data.FirstNecklace, data.SecondNecklace, data.ThirdNecklace);
            builder.Entity<MetalBar>().HasData(data.FirstMetalBar, data.SecondMetalBar, data.ThirdMetalBar);
            builder.Entity<InvestmentDiamond>().HasData(data.FirstInvestmentDiamond, data.SecondInvestmentDiamond, data.ThirdInvestmentDiamond);
            builder.Entity<InvestmentCoin>().HasData(data.FirstInvestmentCoin, data.SecondInvestmentCoin, data.ThirdInvestmentCoin);

            base.OnModelCreating(builder);
        }
    }
}
