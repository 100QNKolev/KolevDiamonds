using KolevDiamonds.Core.Constants;
using KolevDiamonds.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;
using static KolevDiamonds.Infrastructure.Constants.DataConstants;

namespace KolevDiamonds.Core.Models.InvestmentDiamond
{
    public class InvestmentDiamondModel
    {
        [Required(ErrorMessage = ValidationMessagesConstants.NameRequired)]
        [StringLength(InvestmentDiamondNameMaximumLength, MinimumLength = InvestmentDiamondNameMinimumLength, ErrorMessage = ValidationMessagesConstants.NameLength)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessagesConstants.ImagePathRequired)]
        public string ImagePath { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessagesConstants.PriceRequired)]
        [Range(0, double.MaxValue, ErrorMessage = ValidationMessagesConstants.PriceRange)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = ValidationMessagesConstants.CaratsRequired)]
        [Range(0, double.MaxValue, ErrorMessage = ValidationMessagesConstants.CaratsRange)]
        public double Carats { get; set; }

        [Required(ErrorMessage = ValidationMessagesConstants.ColourRequired)]
        public DiamondColor Colour { get; set; }
        
        [Required(ErrorMessage = ValidationMessagesConstants.ClarityRequired)]
        public DiamondClarity Clarity { get; set; }

        [Required(ErrorMessage = ValidationMessagesConstants.CutRequired)]
        public DiamondCut Cut { get; set; }

        [Required(ErrorMessage = ValidationMessagesConstants.CertifyingLaboratoryRequired)]
        [StringLength(InvestmentDiamondCertifyingLaboratoryMaximumLength, MinimumLength = InvestmentDiamondCertifyingLaboratoryMinumumLength, ErrorMessage = ValidationMessagesConstants.CertifyingLaboratoryLength)]
        public string CertifyingLaboratory { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessagesConstants.ProportionsRequired)]
        [StringLength(InvestmentDiamondProportionsMaximumLength, MinimumLength = InvestmentDiamondProportionsMinumumLength, ErrorMessage = ValidationMessagesConstants.ProportionsLength)]
        public string Proportions { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessagesConstants.IsForSaleRequired)]
        public bool IsForSale { get; set; } = true;
    }
}
