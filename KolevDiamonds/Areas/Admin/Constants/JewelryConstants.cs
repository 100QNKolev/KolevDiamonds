using Microsoft.EntityFrameworkCore;

namespace KolevDiamonds.Areas.Admin.Constants
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

        [Comment("The method type used to process jewelry creation forms")]
        public const string JewelryFormCreationType = "Create";

        [Comment("The method type used to process jewelry edit forms")]
        public const string JewelryFormEditType = "Edit";
    }
}
