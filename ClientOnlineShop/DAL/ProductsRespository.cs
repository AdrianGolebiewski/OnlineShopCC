using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;

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


    }
}
