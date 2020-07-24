using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyBestPractices
{
   public class ProductRepository
    {
        public int productID { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int categoryId { get; set; }
        public int onSale { get; set; }
        public int stockLevel { get; set; }
    }
}
