using KolevDiamonds.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static KolevDiamonds.Infrastructure.Constants.DataConstants;

namespace KolevDiamonds.Core.Models.Ring
{
    public class RingModel
    {
        [Required]
        [StringLength(RingNameMaximumLength, MinimumLength = RingNameMinimumLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string ImagePath { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public MetalVariation Metal { get; set; }

        [Required]
        public double Carats { get; set; }

        [Required]
        public DiamondColor Colour { get; set; }

        [Required]
        public DiamondClarity Clarity { get; set; }

        [Required]
        public DiamondCut Cut { get; set; }

        [Required]
        [StringLength(RingPurityMaximumLength, MinimumLength = RingPurityMinumumLength)]
        public string Purity { get; set; } = string.Empty;

        [Required]
        public bool IsForSale { get; set; } = true;
    }
}
