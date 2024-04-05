using KolevDiamonds.Infrastructure.Data.Models;
using KolevDiamonds.Infrastructure.Data.SeedDb;
using Microsoft.AspNetCore.Identity;
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

        public IdentityUser AdminUser { get; set; }
        public DbSet<Ring> Rings { get; set; } = null!;
        public DbSet<Necklace> Necklaces { get; set; } = null!;
        public DbSet<InvestmentDiamond> InvestmentDiamonds { get; set; } = null!;
        public DbSet<InvestmentCoin> InvestmentCoins { get; set; } = null!;
        public DbSet<MetalBar> MetalBars { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RingConfiguration());
            builder.ApplyConfiguration(new NecklaceConfiguration());
            builder.ApplyConfiguration(new MetalBarConfiguration());
            builder.ApplyConfiguration(new InvestmentCoinConfiguration());
            builder.ApplyConfiguration(new InvestmentDiamondConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
