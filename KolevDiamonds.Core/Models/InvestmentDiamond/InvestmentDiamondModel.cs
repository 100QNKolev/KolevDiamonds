using KolevDiamonds.Core.Constants;
using KolevDiamonds.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;
using static KolevDiamonds.Infrastructure.Constants.DataConstants;

namespace KolevDiamonds.Core.Models.InvestmentDiamond
{
    public class InvestmentDiamondModel
    {
        [Required(ErrorMessage = InvestmentDiamondValidationMessagesConstants.NameRequired)]
        [StringLength(InvestmentDiamondNameMaximumLength, MinimumLength = InvestmentDiamondNameMinimumLength, ErrorMessage = InvestmentDiamondValidationMessagesConstants.NameLength)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = InvestmentDiamondValidationMessagesConstants.ImagePathRequired)]
        public string ImagePath { get; set; } = string.Empty;

        [Required(ErrorMessage = InvestmentDiamondValidationMessagesConstants.PriceRequired)]
        [Range(0, double.MaxValue, ErrorMessage = InvestmentDiamondValidationMessagesConstants.PriceRange)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = InvestmentDiamondValidationMessagesConstants.CaratsRequired)]
        [Range(0, double.MaxValue, ErrorMessage = InvestmentDiamondValidationMessagesConstants.CaratsRange)]
        public double Carats { get; set; }

        [Required(ErrorMessage = InvestmentDiamondValidationMessagesConstants.ColourRequired)]
        public DiamondColor Colour { get; set; }
        
        [Required(ErrorMessage = InvestmentDiamondValidationMessagesConstants.ClarityRequired)]
        public DiamondClarity Clarity { get; set; }

        [Required(ErrorMessage = InvestmentDiamondValidationMessagesConstants.CutRequired)]
        public DiamondCut Cut { get; set; }

        [Required(ErrorMessage = InvestmentDiamondValidationMessagesConstants.CertifyingLaboratoryRequired)]
        [StringLength(InvestmentDiamondCertifyingLaboratoryMaximumLength, MinimumLength = InvestmentDiamondCertifyingLaboratoryMinumumLength, ErrorMessage = InvestmentDiamondValidationMessagesConstants.CertifyingLaboratoryLength)]
        public string CertifyingLaboratory { get; set; } = string.Empty;

        [Required(ErrorMessage = InvestmentDiamondValidationMessagesConstants.ProportionsRequired)]
        [StringLength(InvestmentDiamondProportionsMaximumLength, MinimumLength = InvestmentDiamondProportionsMinumumLength, ErrorMessage = InvestmentDiamondValidationMessagesConstants.ProportionsLength)]
        public string Proportions { get; set; } = string.Empty;

        [Required(ErrorMessage = InvestmentDiamondValidationMessagesConstants.IsForSaleRequired)]
        public bool IsForSale { get; set; } = true;
    }
}
