using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngineDAL.PromotioonCalculator
{
    public class FinalPromotion
    {
        public List<SkuToOrder> CalculatePromotion(List<SkuToOrder> list)
        {
            if (list.Count() > 0)
            {
                list = new Promotion1().CalculatePromotion(list);
                list = new Promotion2().CalculatePromotion(list);
                list = new Promotion3().CalculatePromotion(list);
            }
            return list;
        }
    }
}
