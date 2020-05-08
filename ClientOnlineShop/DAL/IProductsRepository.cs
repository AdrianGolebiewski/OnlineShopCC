using System.Collections.Generic;

namespace ClientOnlineShop.DAL
{
    internal interface IProductsRepository
    {
        List<Products> GetAllProducts();
        // List<Products> GetFewProducts(string amount);
        //  Products GetSingleProduct(int productId);
        bool UpdateProduct(Products ourProducts);


    }
}
