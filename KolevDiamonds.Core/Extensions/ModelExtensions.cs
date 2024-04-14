using KolevDiamonds.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IProductModel model) 
        {
            string info = model.Name.Replace(" ", "-") + GetPrice(model);
            Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

            return info;
        }

        private static string GetPrice(IProductModel model)
        {
            return model.Price.ToString();
        }
    }
}
