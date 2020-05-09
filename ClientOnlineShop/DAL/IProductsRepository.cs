using System.Collections.Generic;
using System;

namespace ClientOnlineShop.DAL
{
    internal interface IProductsRepository
    {
        List<Products> GetAllProducts();
        bool UpdateProduct(Products ourProducts);
        bool UpdatePriceWhenDelete(int productId, int Amount);
        bool UpdateProductUp(OrderDetalis amount);
        int[] GetAllProductId();
        string GetAmount(OrderDetalis order);




    }
}
