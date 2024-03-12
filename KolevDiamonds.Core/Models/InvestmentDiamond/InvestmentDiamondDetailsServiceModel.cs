using KolevDiamonds.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Models.InvestmentDiamond
{
    public class InvestmentDiamondDetailsServiceModel
    {
        public int DiamondId { get; set; }

        public string DiamondName { get; set; } = string.Empty;

        public string DiamondImagePath { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public double Carats { get; set; }

        public DiamondColor Colour { get; set; }

        public DiamondClarity Clarity { get; set; }

        public DiamondCut Cut { get; set; }

        public string CertifyingLaboratory { get; set; } = string.Empty;

        public string Proportions { get; set; } = string.Empty;
    }
}
