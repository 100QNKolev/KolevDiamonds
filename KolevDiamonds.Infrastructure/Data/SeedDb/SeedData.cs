﻿using KolevDiamonds.Infrastructure.Data.Models;
using KolevDiamonds.Infrastructure.Enums;
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

        public Necklace FirstNecklace { get; set; }

        public Necklace SecondNecklace { get; set; }

        public Necklace ThirdNecklace { get; set; }

        public MetalBar FirstMetalBar { get; set; }

        public MetalBar SecondMetalBar { get; set; }

        public MetalBar ThirdMetalBar { get; set; }

        public InvestmentDiamond FirstInvestmentDiamond { get; set; }

        public InvestmentDiamond SecondInvestmentDiamond { get; set; }

        public InvestmentDiamond ThirdInvestmentDiamond  { get; set; }

        public InvestmentCoin FirstInvestmentCoin { get; set; }

        public InvestmentCoin SecondInvestmentCoin { get; set; }

        public InvestmentCoin ThirdInvestmentCoin { get; set; }

        public SeedData() 
        {
            SeedRings();
            SeedNecklaces();
            SeedMetalBars();
            SeedInvestmentDiamond();
            SeedInvestmentCoin();
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

        private void SeedNecklaces() 
        {
            FirstNecklace = new Necklace()
            {
                NecklaceId = 1,
                NecklaceName = "Diamond Solitaire Necklace",
                NecklaceImagePath = "https://i.etsystatic.com/6244698/r/il/8121e9/1697727663/il_570xN.1697727663_9elj.jpg",
                Price = 1500.00m,
                Metal = MetalVariation.Gold,
                Carats = 2.5,
                Colour = DiamondColor.G,
                Clarity = DiamondClarity.VS1,
                Cut = DiamondCut.Excellent,
                Purity = "18K",
                Length = 450
            };

            SecondNecklace = new Necklace()
            {
                NecklaceId = 2,
                NecklaceName = "Sapphire Halo Necklace",
                NecklaceImagePath = "https://media.beaverbrooks.co.uk/i/beaverbrooks/G105854_0",
                Price = 2000.00m,
                Metal = MetalVariation.Silver,
                Carats = 3.0,
                Colour = DiamondColor.Q,
                Clarity = DiamondClarity.SI1,
                Cut = DiamondCut.VeryGood,
                Purity = "925",
                Length = 500
            };

            ThirdNecklace = new Necklace()
            {
                NecklaceId = 3,
                NecklaceName = "Emerald Pendant Necklace",
                NecklaceImagePath = "https://haverhill.com/cdn/shop/products/image_11085d78-83fb-429b-a153-15a90bc9ee30_1200x1200.jpg?v=1705428203",
                Price = 1800.00m,
                Metal = MetalVariation.Silver,
                Carats = 2.8,
                Colour = DiamondColor.D,
                Clarity = DiamondClarity.VVS2,
                Cut = DiamondCut.Excellent,
                Purity = "925",
                Length = 480
            };

        }

        private void SeedMetalBars() 
        {
            FirstMetalBar = new MetalBar()
            {
                BarId = 1,
                MetalBarName = "Gold Bar",
                MetalBarImagePath = "https://m.media-amazon.com/images/I/61ICiCEk3TL._AC_UF894,1000_QL80_.jpg",
                Price = 15000.00m,
                Metal = MetalVariation.Gold,
                Weight = 1000.0,
                Dimensions = "27 x 47 mm",
                Purity = "24 Karat"
            };

            SecondMetalBar = new MetalBar()
            {
                BarId = 2,
                MetalBarName = "Silver Bar",
                MetalBarImagePath = "https://www.monex.com/wp-content/uploads/2023/06/1-kilo-silver-bar-side.png",
                Price = 500.00m,
                Metal = MetalVariation.Silver,
                Weight = 1000.0,
                Dimensions = "20 x 40 mm",
                Purity = "999.9/1000"
            };

            ThirdMetalBar = new MetalBar()
            {
                BarId = 3,
                MetalBarName = "Rose Gold Bar",
                MetalBarImagePath = "https://images.squarespace-cdn.com/content/v1/5719f32620c64744b886bcd2/1612970177011-TLIGBQ4ZDOODFX0TOR42/rose-gold-bar.png",
                Price = 20000.00m,
                Metal = MetalVariation.RoseGold,
                Weight = 1000.0,
                Dimensions = "25 x 50 mm",
                Purity = "24 Karat"
            };
        }

        private void SeedInvestmentDiamond() 
        {
            FirstInvestmentDiamond = new InvestmentDiamond
            {
                DiamondId = 1,
                DiamondName = "Round Brilliant Diamond",
                DiamondImagePath = "https://www.diamondbanc.com/wp-content/uploads/2019/01/shutterstock_32731492-1024x681.jpg",
                Price = 5000.00m,
                Carats = 1.0,
                Colour = DiamondColor.E,
                Clarity = DiamondClarity.VVS1,
                Cut = DiamondCut.Excellent,
                CertifyingLaboratory = "GIA",
                Proportions = "Excellent"
            };

            SecondInvestmentDiamond = new InvestmentDiamond
            {
                DiamondId = 2,
                DiamondName = "Princess Cut Diamond",
                DiamondImagePath = "https://www.qualitydiamonds.co.uk/media/1132/princess-diamond-top.png",
                Price = 7000.00m,
                Carats = 1.5,
                Colour = DiamondColor.G,
                Clarity = DiamondClarity.VS2,
                Cut = DiamondCut.VeryGood,
                CertifyingLaboratory = "IGI",
                Proportions = "Very Good"
            };

            ThirdInvestmentDiamond = new InvestmentDiamond
            {
                DiamondId = 3,
                DiamondName = "Emerald Cut Diamond",
                DiamondImagePath = "https://www.capediamonds.co.za/wp-content/uploads/2020/09/Emerald-Cut-Diamonds-Cape-Diamonds-Cape-Town-South-Africa.jpg",
                Price = 10000.00m,
                Carats = 2.0,
                Colour = DiamondColor.F,
                Clarity = DiamondClarity.SI1,
                Cut = DiamondCut.Good,
                CertifyingLaboratory = "HRD",
                Proportions = "Good"
            };
        }

        private void SeedInvestmentCoin() 
        {
            FirstInvestmentCoin = new InvestmentCoin()
            {
                CoinId = 1,
                CoinName = "Gold Sovereign",
                CoinImagePath = "https://upload.wikimedia.org/wikipedia/commons/3/3a/1959_sovereign_Elizabeth_II_obverse.jpg",
                Price = 1000.00m,
                Metal = MetalVariation.Gold,
                Weight = 7.98,
                Purity = 0.9167,
                Quality = GoldQuality.ProofLike,
                Circulation = 10000,
                Diameter = 22.05,
                LegalTender = "GBP 1",
                Manufacturer = "The Royal Mint",
                Packaging = "Protective Capsule"
            };

            SecondInvestmentCoin = new InvestmentCoin()
            {
                CoinId = 2,
                CoinName = "Silver Eagle",
                CoinImagePath = "https://assets.goldeneaglecoin.com/resource/productimages/2020-SE-obv.jpg",
                Price = 50.00m,
                Metal = MetalVariation.Silver,
                Weight = 31.1,
                Purity = 0.999,
                Quality = GoldQuality.ProofLike,
                Circulation = 5000,
                Diameter = 40.6,
                LegalTender = "USD 1",
                Manufacturer = "United States Mint",
                Packaging = "Plastic Tube"
            };

            ThirdInvestmentCoin = new InvestmentCoin()
            {
                CoinId = 3,
                CoinName = "Silver Maple Leaf",
                CoinImagePath = "https://media.tavid.ee/v7/_product_catalog_/1-oz-canadian-maple-leaf-silver-coin/canadian_maple_leaf_1oz_silver_coin_reverse.jpg?height=960&width=960&func=cropfit",
                Price = 500.00m,
                Metal = MetalVariation.Silver,
                Weight = 31.1,
                Purity = 0.9995,
                Quality = GoldQuality.BrilliantUncirculated,
                Circulation = 1000,
                Diameter = 30.0,
                LegalTender = "CAD 50",
                Manufacturer = "Royal Canadian Mint",
                Packaging = "Assay Card"
            };
        }

    }
}
