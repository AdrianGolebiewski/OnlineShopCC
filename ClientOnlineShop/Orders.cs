using System;
using System.Collections.Generic;
using System.Text;

namespace ClientOnlineShop
{
    class Orders
    {
        public UInt64 OrderId { get; set; }
        public int CustomerId { get; set; }
        public string OrderDate { get; set; }
     
        public Orders(int customerId)
        {
            
            this.CustomerId = customerId;
           
        }

        public Orders(UInt64 orderId)
        {

            this.OrderId = orderId;
           

        }

        

    }
}
