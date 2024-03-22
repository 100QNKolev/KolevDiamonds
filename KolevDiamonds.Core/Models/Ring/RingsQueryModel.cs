using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Models.Ring
{
    public class RingsQueryModel
    {
        public int RingsPerPage { get; } = 2;

        public decimal? PriceFilter { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalRingsCount { get; set; }

        public IEnumerable<ProductIndexServiceModel> Rings { get; set; } = new List<ProductIndexServiceModel>();
    }
}
