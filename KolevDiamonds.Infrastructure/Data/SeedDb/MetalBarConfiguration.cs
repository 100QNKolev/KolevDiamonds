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
    public class MetalBarConfiguration : IEntityTypeConfiguration<MetalBar>
    {
        public void Configure(EntityTypeBuilder<MetalBar> builder)
        {
            var data = new SeedData();

            builder.HasData(new MetalBar[] { data.FirstMetalBar, data.SecondMetalBar, data.ThirdMetalBar });
        }
    }
}
