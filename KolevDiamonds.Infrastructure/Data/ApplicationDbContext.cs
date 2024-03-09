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
        public DbSet<InvestmentDiamond> investmentDiamonds { get; set; }
        public DbSet<InvestmentCoin> investmentCoins { get; set; }
        public DbSet<MetalBar> metalBars { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
