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
    }
}
