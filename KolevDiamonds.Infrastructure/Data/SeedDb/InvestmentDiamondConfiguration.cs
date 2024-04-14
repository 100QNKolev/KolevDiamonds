﻿using KolevDiamonds.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KolevDiamonds.Infrastructure.Data.SeedDb
{
    public class InvestmentDiamondConfiguration : IEntityTypeConfiguration<InvestmentDiamond>
    {
        public void Configure(EntityTypeBuilder<InvestmentDiamond> builder)
        {
            var data = new SeedData();

            builder.HasData(new InvestmentDiamond[] { data.FirstInvestmentDiamond, data.SecondInvestmentDiamond, data.ThirdInvestmentDiamond });
        }
    }
}
