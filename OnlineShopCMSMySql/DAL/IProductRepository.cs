using System.Collections.Generic;

namespace OnlineShopCMSMySql.DAL
{
    internal interface IProductRepository
    {
        List<Products> GetAllProducts();
        List<Products> GetFewProducts(int amount);
        Products GetSingleProduct(int productId);
        bool AddProduct(Products ourProducts);
        bool DeleteProduct(int productId);
        bool UpdateProduct(Products ourProducts);
    }
}
