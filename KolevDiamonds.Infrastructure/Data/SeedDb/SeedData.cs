using KolevDiamonds.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public Ring FirstRing { get; set; }

        public Ring SecondRing { get; set; }

        public Ring ThirdRing { get; set; }

        public SeedData() 
        {
            SeedRings();
        }

        private void SeedRings() 
        {
            FirstRing = new Ring() 
            {
                RingId = 1,
                RingName = "Gold Diamond Ring",
                RingImagePath = "https://www.tanishq.co.in/on/demandware.static/-/Sites-Tanishq-product-catalog/default/dw5721e8ec/images/hi-res/50D2FFFFRAA02_1.jpg",
                Price = 1000.00m,
                Metal = Enums.MetalVariation.Gold,
                Carats = 1.5,
                Colour = Enums.DiamondColor.G,
                Clarity = Enums.DiamondClarity.VS1,
                Cut = Enums.DiamondCut.VeryGood,
                Purity = "18K"
            };

            SecondRing = new Ring()
            {
                RingId = 2,
                RingName = "Gold Ring With Crown Diamond",
                RingImagePath = "https://4.imimg.com/data4/QW/YU/FUSIONI-3520335/prod-image.jpg",
                Price = 10020.00m,
                Metal = Enums.MetalVariation.Gold,
                Carats = 4,
                Colour = Enums.DiamondColor.G,
                Clarity = Enums.DiamondClarity.VVS1,
                Cut = Enums.DiamondCut.Excellent,
                Purity = "18K"
            };

            ThirdRing = new Ring()
            {
                RingId = 3,
                RingName = "Rose Gold Diamond Ring",
                RingImagePath = "https://love-and-co.com/cdn/shop/files/CR591-LGD_lifestyle.jpg?v=1697793277&width=2000",
                Price = 12000.00m,
                Metal = Enums.MetalVariation.RoseGold,
                Carats = 3,
                Colour = Enums.DiamondColor.G,
                Clarity = Enums.DiamondClarity.VS1,
                Cut = Enums.DiamondCut.Excellent,
                Purity = "18K"
            };
        }

    }
}
