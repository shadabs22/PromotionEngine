using PromotionEngineDAL.PromotioonCalculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngineDAL
{
    public class SkuToOrder : Sku
    {
        public int Quantity { get; set; }
        public IPromotionCalculation promotionCalculation { get; set; }
    }
}
