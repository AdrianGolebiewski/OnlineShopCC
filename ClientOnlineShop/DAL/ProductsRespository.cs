using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using System;

namespace ClientOnlineShop.DAL
{
    class ProductsRespository : IProductsRepository
    {
        private MySqlConnection _db = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);    

        List<Products> IProductsRepository.GetAllProducts()
        {
            return this._db.Query<Products>("SELECT * FROM Products").ToList();
        }

        bool IProductsRepository.UpdateProduct(Products ourProducts)
        {
            int rowsAffected = this._db.Execute("UPDATE Products SET quantity = quantity - @quantity WHERE product_id = " + ourProducts.product_id, ourProducts);
            
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
        bool IProductsRepository.UpdateProductUp(OrderDetalis amount)
       {
                       
            int rowsAffected = this._db.Execute($"UPDATE Products SET quantity = quantity + {amount.Amount} WHERE product_id = {amount.product_id}");

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        bool IProductsRepository.UpdatePriceWhenDelete(int productId, int Amount)
        {

            int rowsAffected = this._db.Execute($"UPDATE Products SET quantity = quantity + '{Amount}'  WHERE product_id = " + productId);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        int[] IProductsRepository.GetAllProductId()
        {

            return this._db.Query<int>("SELECT product_id FROM Products").ToArray();

        }

        string IProductsRepository.GetAmount(OrderDetalis order)
        {

            return this._db.Query<string>($"SELECT quantity FROM Products WHERE product_id = {order.product_id}").Single();
   
        }


    }
}
