using KolevDiamonds.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;
using static KolevDiamonds.Infrastructure.Constants.DataConstants;

namespace KolevDiamonds.Core.Models.InvestmentCoin
{
    public class InvestmentCoinModel
    {
        [Required]
        [StringLength(InvestmentCoinNameMaximumLength, MinimumLength = InvestmentCoinNameMinimumLength)]
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
        public double Purity { get; set; }

        [Required]
        public GoldQuality Quality { get; set; }

        [Required]
        public int Circulation { get; set; }

        [Required]
        public double Diameter { get; set; }

        [Required]
        [StringLength(InvestmentCoinLegalTenderMaximumLength, MinimumLength = InvestmentCoinLegalTenderMinimumLength)]
        public string LegalTender { get; set; } = string.Empty;

        [Required]
        [StringLength(InvestmentCoinManufacturerMaximumLength, MinimumLength = InvestmentCoinManufacturerMinimumLength)]
        public string Manufacturer { get; set; } = string.Empty;

        [Required]
        [StringLength(InvestmentCoinPackagingMaximumLength, MinimumLength = InvestmentCoinPackagingMinimumLength)]
        public string Packaging { get; set; } = string.Empty;

        [Required]
        public bool IsForSale { get; set; } = true;
    }
}
