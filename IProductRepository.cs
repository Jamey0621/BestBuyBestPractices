using System.Collections.Generic;

namespace BestBuyBestPractices
{
    interface IProductRepository
    {
        IEnumerable<ProductRepository> GetAllProducts();

        void CreatProduct(string name, int price, int CategoryID);

    }
}
