using KolevDiamonds.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static KolevDiamonds.Infrastructure.Constants.DataConstants;

namespace KolevDiamonds.Infrastructure.Data.Models
{
    [Comment("Investment diamond specifications")]
    public class InvestmentDiamond
    {
        [Key]
        [Comment("Diamond unique identifier")]
        public int DiamondId { get; set; }

        [Required]
        [Comment("Name of the diamond")]
        [MaxLength(InvestmentDiamondNameMaximumLength)]
        public string DiamondName { get; set; } = string.Empty;

        [Required]
        [Comment("Server file system image path")]
        public string DiamondImagePath { get; set; } = string.Empty;

        [Required]
        [Comment("Price of the product")]
        public decimal Price { get; set; }

        [Required]
        [Comment("How much carats is the diamond")]
        public double Carats { get; set; }

        [Required]
        [Comment("What color is the diamond")]
        public DiamondColor Colour { get; set; }

        [Required]
        [Comment("What clarity is the diamond")]
        public DiamondClarity Clarity { get; set; }

        [Required]
        [Comment("How well the diamond is cut")]
        public DiamondCut Cut { get; set; }

        [Required]
        [Comment("The certifying gemological laboratory")]
        [MaxLength(InvestmentDiamondCertifyingLaboratoryMaximumLength)]
        public string CertifyingLaboratory { get; set; } = string.Empty;

        [Required]
        [Comment("The proportions of the diamond")]
        [MaxLength(InvestmentDiamondProportionsMaximumLength)]
        public string Proportions { get; set; } = string.Empty;
    }
}
