using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;

namespace ClientOnlineShop.DAL
{
    class OrdersRespository : IOrdersRepository
    {
        private MySqlConnection _db = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);


        bool IOrdersRepository.DeleteOrder(int productId)
        {
            int rowsAffected = this._db.Execute($"DELETE FROM Products WHERE product_id = @product_id", new { product_id = productId });

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;

        }
        List<Orders> IOrdersRepository.GetAllOrders(UInt64 order)
        {
            return this._db.Query<Orders>("SELECT product_id, UnitePrice, Amount, category, color, size, price, quantity, description, manufacturer FROM OrderDetalis LEFT OUTER JOIN Products USING (product_id) WHERE OrderDetalis.OrderID = @orederId ", new {@orderId = order}).ToList();
        }

        Orders IOrdersRepository.GetSingleOrder(int productId)
        {
            return _db.Query<Orders>($"SELECT product_id, category, manufacturer, color, size, price, quantity, description, product_index FROM Products WHERE product_id = @product_id", new { product_id = productId }).SingleOrDefault();
        }

        List<Orders> IOrdersRepository.GetFewOrders(string amount)
        {
            return this._db.Query<Orders>($"SELECT product_id, category, manufacturer, color, size, price, quantity, description, product_index FROM Products LIMIT {amount}").ToList();
        }

        bool IOrdersRepository.AddOrder(Orders ourOrder)
        {
           int rowsAffected = this._db.Execute("INSERT INTO Orders (CustomerID) VALUES (@CustomerID)", new { CustomerId = ourOrder.CustomerId});

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        bool IOrdersRepository.UpdateOrder(Orders ourOrder)
        {
          int rowsAffected = this._db.Execute("UPDATE Orders SET Status = @status WHERE OrderID = " + ourOrder.OrderId, ourOrder);

            
           
            //  if (rowsAffected > 0)
            //  {
            //      return true;
            //  }
            return false;
        }

        Orders IOrdersRepository.GetOrderId(int customerId)
        {
            return _db.Query<Orders>($"SELECT OrderID FROM Orders WHERE CustomerID = @customer_id", new { customer_id = customerId }).SingleOrDefault();
        }
    }
}
