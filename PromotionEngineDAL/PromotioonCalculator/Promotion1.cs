﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngineDAL.PromotioonCalculator
{
    public class Promotion1 : IPromotionCalculation
    {
        public List<SkuToOrder> CalculatePromotion(List<SkuToOrder> list)
        {
            if (list.Where(f => f.SKUID == 1 && f.Quantity > 0).Count() > 0)
            {
                var sku = list.Where(f => f.SKUID == 1 && f.Quantity > 0).First();
                if (sku.Quantity > 2)
                {
                    int quotient = sku.Quantity / 3;
                    int remainder = sku.Quantity % 3;
                    int index = list.IndexOf(sku);
                    sku.Price = (quotient * 130) + ((remainder) * 50);
                    list[index].Price = sku.Price;
                    //return (quotient * 130) + ((remainder) * 50);
                }
            }
            else
            {
                if (list.Where(f => f.SKUID == 1 && f.Quantity > 0).Count() == 0)// && list.Where(f => f.SKUID == 4 && f.Quantity > 0).Count() > 0)
                {
                    var skuA = list.Where(f => f.SKUID == 1).First();
                    int skuAIndex = list.IndexOf(skuA);
                    list[skuAIndex].Price = 0;
                }
            }
            return list;
        }
    }
}
