using KolevDiamonds.Core.Constants;
using KolevDiamonds.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;
using static KolevDiamonds.Infrastructure.Constants.DataConstants;

namespace KolevDiamonds.Core.Models.Necklace
{
    public class NecklaceModel
    {
        [Required(ErrorMessage = ValidationMessagesConstants.NameRequired)]
        [StringLength(NecklaceNameMaximumLength, MinimumLength = NecklaceNameMinimumLength, ErrorMessage = ValidationMessagesConstants.NameLength)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessagesConstants.ImagePathRequired)]
        public string ImagePath { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessagesConstants.PriceRequired)]
        [Range(0, double.MaxValue, ErrorMessage = ValidationMessagesConstants.PriceRange)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = ValidationMessagesConstants.MetalRequired)]
        public MetalVariation Metal { get; set; }

        [Required(ErrorMessage = ValidationMessagesConstants.CaratsRequired)]
        [Range(0, double.MaxValue, ErrorMessage = ValidationMessagesConstants.CaratsRange)]
        public double Carats { get; set; }

        [Required(ErrorMessage = ValidationMessagesConstants.ColourRequired)]
        public DiamondColor Colour { get; set; }

        [Required(ErrorMessage = ValidationMessagesConstants.ClarityRequired)]
        public DiamondClarity Clarity { get; set; }

        [Required(ErrorMessage = ValidationMessagesConstants.CutRequired)]
        public DiamondCut Cut { get; set; }

        [Required(ErrorMessage = ValidationMessagesConstants.PurityRequired)]
        [StringLength(NecklacePurityMaximumLength, MinimumLength = NecklacePurityMinumumLength, ErrorMessage = ValidationMessagesConstants.PurityLength)]
        public string Purity { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessagesConstants.LengthRequired)]
        [Range(0, double.MaxValue, ErrorMessage = ValidationMessagesConstants.LengthRange)]
        public double Length { get; set; }

        [Required(ErrorMessage = ValidationMessagesConstants.IsForSaleRequired)]
        public bool IsForSale { get; set; } = true;
    }
}
