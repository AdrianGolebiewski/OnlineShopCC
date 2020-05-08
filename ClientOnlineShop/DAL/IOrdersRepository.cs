using System;
using System.Collections.Generic;
using System.Text;

namespace ClientOnlineShop.DAL
{
    internal interface IOrdersRepository
    {
        List<Orders> GetAllOrders(UInt64 order);
        List<Orders> GetFewOrders(string amount);
        Orders GetSingleOrder(int productId);
        bool AddOrder(Orders ourProducts);
        bool DeleteOrder(int productId);
        bool UpdateOrder(Orders ourProducts);
        Orders GetOrderId(int customerId);

    }
}
