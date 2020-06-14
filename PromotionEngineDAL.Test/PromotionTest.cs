using PromotionEngineDAL.PromotioonCalculator;
using System;
using System.Collections.Generic;
using Xunit;

namespace PromotionEngineDAL.Test
{
    public class PromotionTest
    {
        List<SkuToOrder> skuToOrder = new List<SkuToOrder>() {
            new SkuToOrder(){ SKUID=1,Name="A",Price=50,Quantity=3 },
            new SkuToOrder(){ SKUID=2,Name="B",Price=30,Quantity=5 },
            new SkuToOrder(){ SKUID=3,Name="C",Price=20,Quantity=1},
            new SkuToOrder(){ SKUID=4,Name="D",Price=15,Quantity=1 },
        };

        List<SkuToOrder> expectedskuToOrder = new List<SkuToOrder>() {
            new SkuToOrder(){ SKUID=1,Name="A",Price=130,Quantity=3 },
            new SkuToOrder(){ SKUID=2,Name="B",Price=120,Quantity=5 },
            new SkuToOrder(){ SKUID=3,Name="C",Price=0,Quantity=1},
            new SkuToOrder(){ SKUID=4,Name="D",Price=30,Quantity=1 },
        };


        [Fact]
        public void Promotion1()
        {
            var promotion1 = new Promotion1();
            var result = promotion1.CalculatePromotion(skuToOrder);
            Assert.Equal(expectedskuToOrder[0].Price, result[0].Price);
        }

        [Fact]
        public void Promotion2()
        {
            var promotion2 = new Promotion2();
            var result = promotion2.CalculatePromotion(skuToOrder);
            Assert.Equal(expectedskuToOrder[1].Price, result[1].Price);
        }

        [Fact]
        public void Promotion3()
        {
            var promotion3 = new Promotion3();
            var result = promotion3.CalculatePromotion(skuToOrder);
            Assert.Equal(expectedskuToOrder[2].Price, result[2].Price);
            Assert.Equal(expectedskuToOrder[3].Price, result[3].Price);

        }
    }
}
