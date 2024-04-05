using KolevDiamonds.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Infrastructure.Data.SeedDb
{
    public class InvestmentCoinConfiguration : IEntityTypeConfiguration<InvestmentCoin>
    {
        public void Configure(EntityTypeBuilder<InvestmentCoin> builder)
        {
            var data = new SeedData();

            builder.HasData(new InvestmentCoin[] { data.FirstInvestmentCoin, data.SecondInvestmentCoin, data.ThirdInvestmentCoin });
        }
    }
}
