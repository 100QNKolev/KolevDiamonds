using KolevDiamonds.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static KolevDiamonds.Infrastructure.Constants.DataConstants;

namespace KolevDiamonds.Infrastructure.Data.Models
{
    [Comment("Investment coin specifications")]
    public class InvestmentCoin
    {
        [Key]
        [Comment("Coin unique identifier")]
        public int CoinId { get; set; }

        [Required]
        [Comment("Name of the coin")]
        [MaxLength(InvestmentCoinNameMaximumLength)]
        public string CoinName { get; set; } = string.Empty;

        [Required]
        [Comment("Type of metal")]
        public MetalVariation Metal { get; set; }

        [Required]
        [Comment("Weight of the metal in grams")]
        public double Weight { get; set; }

        [Required]
        [Comment("Purity of the metal expressed as a ratio")]
        public double Purity { get; set; }

        [Required]
        [Comment("Quality of the metal")]
        public GoldQuality Quality { get; set; }

        [Required]
        [Comment("Number of pieces in circulation")]
        public int Circulation { get; set; }

        [Required]
        [Comment("Diameter of the coin in millimeters")]
        public double Diameter { get; set; }

        [Required]
        [Comment("Legal tender value in the specified currency")]
        [MaxLength(InvestmentCoinLegalTenderMaximumLength)]
        public string LegalTender { get; set; } = string.Empty;

        [Required]
        [Comment("Manufacturer of the coin")]
        [MaxLength(InvestmentCoinManufacturerMaximumLength)]
        public string Manufacturer { get; set; } = string.Empty;

        [Required]
        [Comment("Packaging for the coin")]
        [MaxLength(InvestmentCoinPackagingMaximumLength)]
        public string Packaging { get; set; } = string.Empty;
    }
}
