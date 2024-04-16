using Microsoft.EntityFrameworkCore;

namespace KolevDiamonds.Core.Constants
{
    [Comment("Jewelry constants")]
    public static class JewelryConstants
    {
        //It must be divided exactly by the number of types of jewelry.
        [Comment("Jewelry items per page")]
        public const int JewelryPerPage = 15;

        [Comment("The exact number of items, each jewelry type will display on page")]
        public const int JewelryTypeItemPerPage = 2;

        [Comment("The product type used in the query model")]
        public const string JewelryQueryProductType = "Jewelry";
    }
}
