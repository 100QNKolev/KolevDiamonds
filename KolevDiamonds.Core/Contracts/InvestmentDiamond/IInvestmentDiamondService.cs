using KolevDiamonds.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Contracts.InvestmentDiamond
{
    public interface IInvestmentDiamondService
    {
        Task<IEnumerable<RingIndexServiceModel>> AllInvestmentDiamonds();
    }
}
