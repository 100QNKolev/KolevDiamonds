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
    [Comment("Ring specifications")]
    public class Ring
    {
        [Key]
        [Comment("Ring unique identifier")]
        public int RingId { get; set; }

        [Required]
        [Comment("Name of the ring")]
        [MaxLength(RingNameMaximumLength)]
        public string RingName { get; set; } = string.Empty;

        [Required]
        [Comment("Server file system image path")]
        public string RingImagePath { get; set; } = string.Empty;

        [Required]
        [Comment("Price of the product")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Metal, which ring is made of")]
        public MetalVariation Metal { get; set; }

        [Required]
        [Comment("How much carats is the main diamond used in the ring")]
        public double Carats { get; set; }

        [Required]
        [Comment("What color is the main diamond")]
        public DiamondColor Colour { get; set; }

        [Required]
        [Comment("What clarity is the main diamond in the ring")]
        public DiamondClarity Clarity { get; set; }

        [Required]
        [Comment("How well the diamond is cut")]
        public DiamondCut Cut { get; set; }

        [Required]
        [Comment("Purity of the metal expressed in carat for gold or sample for silver")]
        [MaxLength(RingPurityMaximumLength)]
        public string Purity { get; set; } = string.Empty;
    }
}
