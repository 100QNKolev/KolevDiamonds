using KolevDiamonds.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Infrastructure.Data.Models
{
    [Comment("Investment gold specifications")]
    public class InvestmentCoin
    {
        [Key]
        [Comment("Coin unique identifier")]
        public int CoindId { get; set; }

        [Required]
        [Comment("Type of metal")]
        public MetalVariation Metal { get; set; }

        [Required]
        [Comment("Weight of the gold in grams")]
        public double Weight { get; set; }

        [Required]
        [Comment("Purity of the gold expressed as a ratio")]
        public double Purity { get; set; }

        [Required]
        [Comment("Quality of the gold")]
        public GoldQuality Quality { get; set; }

        [Required]
        [Comment("Number of pieces in circulation")]
        public int Circulation { get; set; }

        [Required]
        [Comment("Diameter of the gold piece in millimeters")]
        public double Diameter { get; set; }

        [Required]
        [Comment("Legal tender value in the specified currency")]
        public string LegalTender { get; set; } = string.Empty;

        [Required]
        [Comment("Manufacturer of the gold")]
        public string Manufacturer { get; set; } = string.Empty;

        [Required]
        [Comment("Packaging for the gold")]
        public string Packaging { get; set; } = string.Empty;
    }
}
