using KolevDiamonds.Infrastructure.Data.Models;
using KolevDiamonds.Infrastructure.Data.SeedDb;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

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
            builder.ApplyConfiguration(new RingConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
