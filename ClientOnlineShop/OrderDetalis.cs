using System;
using System.Collections.Generic;
using System.Text;

namespace ClientOnlineShop
{
    class OrderDetalis
    {
        public UInt64 OrderId { get; set; }
        public int product_id { get; set; }
        public int Amount { get; set; }
        public float UnitPrice { get; set; }
        public string category { get; set; }
        public string manufacturer { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public float price { get; set; }
        public int quantity { get; set; }

        public OrderDetalis()
        {
            
        }

        public OrderDetalis(UInt64 orderId, int productId, int Amount)
        {
            this.OrderId = orderId;
            this.product_id = productId;
            this.Amount = Amount;
        }


        public OrderDetalis (Int32 productId)
        {
           
            this.product_id = productId;
           
        }

        public OrderDetalis(Int32 productId, UInt64 OrderId)
        {

            this.product_id = productId;

        }
        public OrderDetalis(int product_id, float unitePrice, int amount, string category, string color, string size, float price, string manufacturer)
        {

            this.product_id = product_id;
            this.UnitPrice = unitePrice;
            this.Amount = amount;
            this.category = category;
            this.color = color;
            this.size = size;
            this.price = price;
            this.manufacturer = manufacturer;

    }
        public OrderDetalis(int Amount, int product_id)
        {

            this.product_id = product_id;
            this.Amount = Amount;

        }

    }
}
