using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Core.Constants
{
    public static class InvestmentDiamondValidationMessagesConstants
    {
        public const string NameRequired = "Name is required";
        public const string NameLength = "Name must be between {2} and {1} characters";
        public const string ImagePathRequired = "Image path is required";
        public const string PriceRequired = "Price is required";
        public const string PriceRange = "Price must be greater than or equal to 0";
        public const string CaratsRequired = "Carats is required";
        public const string CaratsRange = "Carats must be greater than or equal to 0";
        public const string ColourRequired = "Colour is required";
        public const string ClarityRequired = "Clarity is required";
        public const string CutRequired = "Cut is required";
        public const string CertifyingLaboratoryRequired = "Certifying laboratory is required";
        public const string CertifyingLaboratoryLength = "Certifying laboratory must be between {2} and {1} characters";
        public const string ProportionsRequired = "Proportions is required";
        public const string ProportionsLength = "Proportions must be between {2} and {1} characters";
        public const string IsForSaleRequired = "Is for sale is required";
    }
}
