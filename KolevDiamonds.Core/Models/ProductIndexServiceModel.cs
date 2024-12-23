﻿using KolevDiamonds.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Models
{
    public class ProductIndexServiceModel : IProductModel
    {
        public int Id { get; set; }

        public string ImagePath { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string ProductType { get; set; } = string.Empty;

        public bool IsForSale { get; set; }
    }
}
