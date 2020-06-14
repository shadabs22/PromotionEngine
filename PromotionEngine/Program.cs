using System;
using System.Collections.Generic;
using System.Linq;
using PromotionEngineDAL;
using PromotionEngineDAL.PromotioonCalculator;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            PromotionContext promotionContext = new PromotionContext();
            Cart cart = new Cart();
            cart.SkuList = new List<SkuToOrder>();

            var skulist = promotionContext.Skus.ToList();
            if (skulist.Count() > 0)
            {
                for (int i=0;i<skulist.Count();i++)
                {
                    cart.SkuList.Add(new SkuToOrder() { SKUID= skulist[i].SKUID,
                        Name = skulist[i].Name, Price=skulist[i].Price });
                    Console.WriteLine("Enter the product " + skulist[i].Name + " quantity.");
                    cart.SkuList[i].Quantity = Convert.ToInt32(Console.ReadLine());

                }

                if (cart.SkuList.Where(e => e.Quantity > 0).Count() > 0)
                {


                    Console.WriteLine("-----------------------");
                    Console.WriteLine("SKU's\tQty\tPrice");
                    Console.WriteLine("-----------------------");

                    FinalPromotion fp = new FinalPromotion();
                    cart.SkuList = fp.CalculatePromotion(cart.SkuList);
                    for (int i = 0; i < cart.SkuList.Count(); i++)
                    {
                        if (cart.SkuList[i].Quantity > 0)
                        {
                            Console.WriteLine(cart.SkuList[i].Name + "\t" + cart.SkuList[i].Quantity
                                //+ "*" 
                                //+ cart.SkuList[i].Price 
                                + "\t" + (cart.SkuList[i].Price == 0 ? "-" : "" + cart.SkuList[i].Price));
                        }
                    }
                    Console.WriteLine("-----------------------");
                    float totalPrice = cart.SkuList.Sum(x => Convert.ToInt32(x.Price));
                    Console.WriteLine("Total\t\t" + totalPrice);

                }
            }
            else
            {
                Console.WriteLine("No SKU available.");
            }
        }
    }
}
