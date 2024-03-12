using KolevDiamonds.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Models.Necklace
{
    public class NecklaceDetailsServiceModel
    {
        public int NecklaceId { get; set; }

        public string NecklaceName { get; set; } = string.Empty;

        public string NecklaceImagePath { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public MetalVariation Metal { get; set; }

        public double Carats { get; set; }

        public DiamondColor Colour { get; set; }

        public DiamondClarity Clarity { get; set; }

        public DiamondCut Cut { get; set; }

        public string Purity { get; set; } = string.Empty;

        public double Length { get; set; }
    }
}
