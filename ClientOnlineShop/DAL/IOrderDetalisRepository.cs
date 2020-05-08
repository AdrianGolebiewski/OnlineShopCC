using System;
using System.Collections.Generic;
using System.Text;

namespace ClientOnlineShop.DAL
{
    internal interface IOrderDetalisRepository
    {
        bool DeleteOrderDetalis(UInt64 orderId);
        bool UpdateOrderDetalis(OrderDetalis ourOrder);
        bool AddOrderDetalis(OrderDetalis ourOrder);
        List<OrderDetalis> GetAllOrdersDetalis(UInt64 orderId);
        bool UpdatePrice(OrderDetalis ourOrder);


    }
}
