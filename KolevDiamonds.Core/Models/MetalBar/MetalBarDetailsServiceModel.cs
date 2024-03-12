using KolevDiamonds.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Models.MetalBar
{
    public class MetalBarDetailsServiceModel
    {
        public int BarId { get; set; }

        public string MetalBarName { get; set; } = string.Empty;

        public string MetalBarImagePath { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public MetalVariation Metal { get; set; }

        public double Weight { get; set; }

        public string Dimensions { get; set; } = string.Empty;

        public string Purity { get; set; } = string.Empty;
    }
}
