using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using System;
namespace ClientOnlineShop.DAL
{
    class OrderDetalisRepository : IOrderDetalisRepository
    {
        private MySqlConnection _db = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        bool IOrderDetalisRepository.AddOrderDetalis(OrderDetalis ourOrder)
        {
            int rowsAffected = this._db.Execute("INSERT INTO OrderDetalis (OrderID, product_id, Amount) VALUES (@orderID, @productID, @amount)", new { orderID = ourOrder.OrderId, productID = ourOrder.product_id, amount = ourOrder.Amount });

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        bool IOrderDetalisRepository.DeleteOrderDetalis(UInt64 orderId)
        {
            int rowsAffected = this._db.Execute($"UPDATE OrderDetalis SET UnitePrice = 0 WHERE OrderID = " + orderId);
            int rowsAffected1 = this._db.Execute($"UPDATE OrderDetalis SET Amount = 0 WHERE OrderID = " + orderId);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;

        }

        List<OrderDetalis> IOrderDetalisRepository.GetAllOrdersDetalis(UInt64 orderId)
        {
            return this._db.Query<OrderDetalis>("SELECT product_id, UnitePrice, Amount, category, color, size, price, manufacturer FROM OrderDetalis LEFT OUTER JOIN Products USING (product_id) WHERE OrderDetalis.OrderID = " + orderId).ToList();

        }

        bool IOrderDetalisRepository.UpdateOrderDetalis(OrderDetalis ourOrder)
        {
            int rowsAffected = this._db.Execute("UPDATE OrderDetalis SET Amount = @Amount WHERE product_id = " + ourOrder.product_id, ourOrder);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;

        }

        bool IOrderDetalisRepository.UpdatePrice(OrderDetalis ourProducts)
        {
            
            var price = this._db.Query<Products>("SELECT price FROM `Products` WHERE product_id =" + ourProducts.product_id).SingleOrDefault(); 
          
            int rowsAffected = this._db.Execute($"UPDATE OrderDetalis SET UnitePrice = '{price.price}' * Amount WHERE OrderID = " + ourProducts.OrderId, ourProducts);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
    }
}
