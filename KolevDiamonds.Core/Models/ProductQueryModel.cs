using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Models
{
    public class ProductQueryModel
    {
        public int ProductsPerPage { get; } = 2;

        public decimal? PriceFilter { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalProductCount { get; set; }

        public IEnumerable<ProductIndexServiceModel> Products { get; set; } = new List<ProductIndexServiceModel>();
    }
}
