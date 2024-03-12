using KolevDiamonds.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Models.InvestmentCoin
{
    public class InvestmentCoinDetailsServiceModel
    {
        public int CoinId { get; set; }

        public string CoinName { get; set; } = string.Empty;

        public string CoinImagePath { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public MetalVariation Metal { get; set; }

        public double Weight { get; set; }

        public double Purity { get; set; }

        public GoldQuality Quality { get; set; }

        public int Circulation { get; set; }

        public double Diameter { get; set; }

        public string LegalTender { get; set; } = string.Empty;

        public string Manufacturer { get; set; } = string.Empty;

        public string Packaging { get; set; } = string.Empty;
    }
}
