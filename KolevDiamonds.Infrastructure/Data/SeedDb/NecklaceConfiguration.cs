using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KolevDiamonds.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KolevDiamonds.Infrastructure.Data.SeedDb
{
    public class NecklaceConfiguration : IEntityTypeConfiguration<Necklace>
    {
        public void Configure(EntityTypeBuilder<Necklace> builder)
        {
            var data = new SeedData();

            builder.HasData(new Necklace[] { data.FirstNecklace, data.SecondNecklace, data.ThirdNecklace });
        }
    }
}
