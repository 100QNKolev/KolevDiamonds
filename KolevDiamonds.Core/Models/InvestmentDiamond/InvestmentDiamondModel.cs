using KolevDiamonds.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static KolevDiamonds.Infrastructure.Constants.DataConstants;

namespace KolevDiamonds.Core.Models.InvestmentDiamond
{
    public class InvestmentDiamondModel
    {
        [Required]
        [StringLength(InvestmentDiamondNameMaximumLength, MinimumLength = InvestmentDiamondNameMinimumLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string ImagePath { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public double Carats { get; set; }

        [Required]
        public DiamondColor Colour { get; set; }

        [Required]
        public DiamondClarity Clarity { get; set; }

        [Required]
        public DiamondCut Cut { get; set; }

        [Required]
        [StringLength(InvestmentDiamondCertifyingLaboratoryMaximumLength, MinimumLength = InvestmentDiamondCertifyingLaboratoryMinumumLength)]
        public string CertifyingLaboratory { get; set; } = string.Empty;

        [Required]
        [StringLength(InvestmentDiamondProportionsMaximumLength, MinimumLength = InvestmentDiamondProportionsMinumumLength)]
        public string Proportions { get; set; } = string.Empty;

        [Required]
        public bool IsForSale { get; set; } = true;
    }
}
