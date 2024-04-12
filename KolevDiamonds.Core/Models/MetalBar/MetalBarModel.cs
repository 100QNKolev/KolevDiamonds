using KolevDiamonds.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;
using static KolevDiamonds.Infrastructure.Constants.DataConstants;

namespace KolevDiamonds.Core.Models.MetalBar
{
    public class MetalBarModel
    {
        [Required]
        [StringLength(MetalBarNameMaximumLength, MinimumLength = MetalBarNameMinimumLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string ImagePath { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public MetalVariation Metal { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        [StringLength(MetalBarDimentionsMaximumLength, MinimumLength = MetalBarDimentionsMinumumLength)]
        public string Dimensions { get; set; } = string.Empty;

        [Required]
        [StringLength(MetalBarPurityMaximumLength, MinimumLength = MetalBarPurityMinumumLength)]
        public string Purity { get; set; } = string.Empty;

        [Required]
        public bool IsForSale { get; set; } = true;
    }
}
