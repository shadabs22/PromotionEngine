using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngineDAL
{
    public class Cart
    {
        public int CartID { get; set; }
        public List<SkuToOrder> SkuList { get; set; }  
    }
}
