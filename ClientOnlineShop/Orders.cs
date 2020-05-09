using System;

namespace ClientOnlineShop
{
    class Orders
    {
        public UInt64 OrderId { get; set; }
        public int CustomerId { get; set; }
        public string OrderDate { get; set; }
        public int Status { get; set; }


        public Orders(int customerId)
        {
            
            this.CustomerId = customerId;
           
        }

        public Orders(UInt64 orderId)
        {

            this.OrderId = orderId;
           

        }

        public Orders()
        {

           


        }



    }
}
