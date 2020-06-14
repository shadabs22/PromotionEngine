using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngineDAL.PromotioonCalculator
{
    public interface IPromotionCalculation
    {
        List<SkuToOrder> CalculatePromotion(List<SkuToOrder> list);
    }
}
