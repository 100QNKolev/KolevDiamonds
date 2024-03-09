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
    [Comment("Metal bar specifications")]
    public class MetalBar
    {
        [Key]
        [Comment("Metal bar unique identifier")]
        public int BarId { get; set; }

        [Required]
        [Comment("Name of the metal bar")]
        [MaxLength(MetalBarNameMaximumLength)]
        public string MetalBarName { get; set; } = string.Empty;

        [Required]
        [Comment("Type of metal")]
        public MetalVariation Metal { get; set; }

        [Required]
        [Comment("Weight of the metal bar")]
        public double Weight { get; set; }

        [Required]
        [Comment("Dimensions of the metal bar (length x width)")]
        [MaxLength(MetalBarDimentionsMaximumLength)]
        public string Dimensions { get; set; } = string.Empty;

        [Required]
        [Comment("Purity of the metal expressed in carat for gold or sample for silver")]
        [MaxLength(MetalBarPurityMaximumLength)]
        public string Purity { get; set; } = string.Empty;
    }
}
