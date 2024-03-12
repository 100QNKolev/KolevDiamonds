using KolevDiamonds.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Models.Ring
{
    public class RingDetailsServiceModel
    {
        public int RingId { get; set; }

        public string RingName { get; set; } = string.Empty;

        public string RingImagePath { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public MetalVariation Metal { get; set; }

        public double Carats { get; set; }

        public DiamondColor Colour { get; set; }

        public DiamondClarity Clarity { get; set; }

        public DiamondCut Cut { get; set; }

        public string Purity { get; set; } = string.Empty;
    }
}
