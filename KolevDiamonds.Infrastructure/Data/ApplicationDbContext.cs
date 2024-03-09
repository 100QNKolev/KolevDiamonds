using KolevDiamonds.Infrastructure.Data.Models;
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

        public DbSet<Ring> Rings { get; set; }
        public DbSet<Necklace> Necklaces { get; set; }
        public DbSet<InvestmentDiamond> InvestmentDiamonds { get; set; }
        public DbSet<InvestmentCoin> InvestmentCoins { get; set; }
        public DbSet<MetalBar> MetalBars { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
