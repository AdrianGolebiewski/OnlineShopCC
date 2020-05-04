using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;

namespace OnlineShopCMSMySql.DAL
{
    class ProductRespository : IProductRepository
    {
        private MySqlConnection _db = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);


        bool IProductRepository.DeleteProduct(int productId)
        {
            int rowsAffected = this._db.Execute($"DELETE FROM Products WHERE product_id = @product_id", new { product_id = productId });

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        List<Products> IProductRepository.GetAllProducts()
        {
            return this._db.Query<Products>("SELECT * FROM Products").ToList();
        }
     
        Products IProductRepository.GetSingleProduct(int productId)
        {
            return _db.Query<Products>($"SELECT product_id, category, manufacturer, color, size, price, quantity, description, product_index FROM Products WHERE product_id = @product_id", new { product_id = productId }).SingleOrDefault();
        }

        List<Products> IProductRepository.GetFewProducts(string amount)
        {
            return this._db.Query<Products>($"SELECT product_id, category, manufacturer, color, size, price, quantity, description, product_index FROM Products LIMIT {amount}").ToList();
        }

        bool IProductRepository.AddProduct(Products ourProducts)
        {
            int rowsAffected = this._db.Execute("INSERT INTO Products (category, manufacturer, color, size, price, quantity, description, product_index) VALUES (@category, @manufacturer, @color, @size, @price, @quantity, @description, @product_index)", new { product_id = ourProducts.product_id, category = ourProducts.category, manufacturer = ourProducts.manufacturer, color = ourProducts.color, size = ourProducts.size, price = ourProducts.price, quantity = ourProducts.quantity, description = ourProducts.description, product_index = ourProducts.product_index});
 
            if (rowsAffected > 0)
            {
                return true; 
            }
            return false;
        }
        
        bool IProductRepository.UpdateProduct(Products ourProducts)
        {
            int rowsAffected = this._db.Execute("UPDATE Products SET category = @category, manufacturer = @manufacturer, color = @color, size = @size, price = @price, quantity = @quantity, description = @description, product_index = @product_index WHERE product_id = " + ourProducts.product_id, ourProducts);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
    }
}
