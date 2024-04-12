using KolevDiamonds.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;
using static KolevDiamonds.Infrastructure.Constants.DataConstants;

namespace KolevDiamonds.Core.Models.Necklace
{
    public class NecklaceModel
    {
        [Required]
        [StringLength(NecklaceNameMaximumLength, MinimumLength = NecklaceNameMinimumLength)]
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
        [StringLength(NecklacePurityMaximumLength, MinimumLength = NecklacePurityMinumumLength)]
        public string Purity { get; set; } = string.Empty;

        [Required]
        public double Length { get; set; }

        [Required]
        public bool IsForSale { get; set; } = true;
    }
}
