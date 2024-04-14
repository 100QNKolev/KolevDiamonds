using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Contracts
{
    public interface IProductModel
    {
        string Name { get; set; }
        decimal Price { get; set; }
    }
}
