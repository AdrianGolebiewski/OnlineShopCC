using System;
using System.Collections.Generic;
using System.Dynamic;
using ClientOnlineShop.DAL;

namespace ClientOnlineShop
{
     public static class OrdersController
    { 
        private static int CustomerId;
        private static UInt64 OrderId;


        internal static bool MainMenu(IOrdersRepository order, IProductsRepository product, IOrderDetalisRepository orderDetalis)

        {
            Console.Clear();
            OrdersView.PrintMenu(CustomerId, OrderId);
            
            switch (Console.ReadLine())
            {   
                case "6":
                    GetNewOrderInput(order);
                    return true;
                case "1":
                    ProductsView.printList(product.GetAllProducts());
                    var addorder = GetOrderDetalis();
                    if (orderDetalis.AddOrderDetalis(addorder) == true)
                    {
                        OrdersView.AddedSuccessfully();
                    }
                    var updateProduct = new Products(addorder.product_id, addorder.Amount);
                    product.UpdateProduct(updateProduct);
                    orderDetalis.UpdatePrice(addorder);
                    return true;
                case "2":
                    GetOrderList(orderDetalis);
                    return true;
                case "3":
                    GetOrderList(orderDetalis);
                    var updateDetalis = GetOrderDetalis();
                    orderDetalis.UpdateOrderDetalis(updateDetalis);
                    orderDetalis.UpdatePrice(updateDetalis);
                    return true;
                case "4":
                    orderDetalis.DeleteOrderDetalis(OrderId);
                    return true;
                case "5":
                    //?
                case "0":
                   return false;
                default:
                    Console.WriteLine("There is no such choice");
                    OrdersView.PressAnyKey();
                    return true;
            }

        }
        internal static bool CreateOrderMenu(IOrdersRepository order, IProductsRepository product, IOrderDetalisRepository orderDetalis)
        {
            Console.Clear();
            OrdersView.CreateOrderMenu();
            switch (Console.ReadLine())
            {
                case "1":
                    OrdersView.NotImplementedYet();
                    OrdersView.PressAnyKey();
                    return true;
                case "2":
                    OrdersView.NotImplementedYet();
                    OrdersView.PressAnyKey();
                    return true;
                case "3":
                    GetNewOrderInput(order);
                    bool showMenu = true;
                    while (showMenu)
                    {
                        MainMenu(order, product, orderDetalis);
                    }                  
                    return true;
                case "4":
                   return false;
                default:
                    Console.WriteLine("There is no such choice");
                    OrdersView.PressAnyKey();
                    return true;
            }
        }

        static void GetNewOrderInput(IOrdersRepository order)
        {
            Random rnd = new Random();
            int customerId = rnd.Next(1200000);
            var _order = new Orders(customerId);
            order.AddOrder(_order);
            CustomerId = _order.CustomerId;
            var _orderId = order.GetOrderId(CustomerId);
            OrderId = _orderId.OrderId;
            

        }
        static OrderDetalis GetOrderDetalis()
        {   
           Console.Write("Product Id: ");
           int productId = Convert.ToInt32(Console.ReadLine());
           Console.Write("Quantity: ");
           int quantity = Convert.ToInt32(Console.ReadLine());
           var orderDetalis = new OrderDetalis(OrderId, productId, quantity);

           return orderDetalis;
        }
        static float GetAllPrice(List<OrderDetalis> list)
        {
            float AllPrice = 0;
            foreach (var product in list)
            {
                AllPrice = product.UnitPrice;
            }
            return AllPrice;
        }

        static void GetOrderList(IOrderDetalisRepository orderDetalis)
        {
            List<OrderDetalis> allOrders = orderDetalis.GetAllOrdersDetalis(OrderId);
            OrderDetalisView.printList(allOrders, GetAllPrice(allOrders));
        }
        
        
    }
}
