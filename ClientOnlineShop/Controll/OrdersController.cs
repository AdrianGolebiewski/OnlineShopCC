using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using ClientOnlineShop.DAL;

namespace ClientOnlineShop
{
    public static class OrdersController
    {
        private static int CustomerId;
        private static UInt64 OrderId;
        private static float TotalPrice;


        internal static bool MainMenu(IOrdersRepository order, IProductsRepository product, IOrderDetalisRepository orderDetalis)

        {
            Console.Clear();
            OrdersView.PrintMenu(CustomerId, OrderId);

            switch (Console.ReadLine())
            {
                case "6":
                    order.UpdateOrder(UpdateStatus(1));
                    GetIdAndAmount(orderDetalis.GetAllOrdersDetalis(OrderId), product);
                    GetNewOrderInput(order);
                    return true;
                case "1":
                    Console.Clear();
                    ProductsView.printList(product.GetAllProducts());
                    bool ProductInBase = true;
                    var addorder = new OrderDetalis();
                    while (ProductInBase)
                    {
                        addorder = GetInput();
                        if (IsProductIdInBase(product, addorder))
                        {
                            ProductInBase = CheckLessThanZero(product, addorder);
                        }
                        else
                        {
                            ProductInBase = true;
                        }
                    }
                    if (orderDetalis.AddOrderDetalis(addorder) == true)
                    {
                        OrdersView.AddedSuccessfully();
                    }
                    var updateProduct = new Products(addorder.product_id, addorder.Amount);
                    product.UpdateProduct(updateProduct);
                    orderDetalis.UpdatePrice(addorder);
                    return true;
                case "2":
                    Console.Clear();
                    GetOrderList(orderDetalis);
                    OrdersView.PressAnyKey();
                    return true;
                case "3":
                    if (!IsAnyProductInBase(orderDetalis))
                    {
                        Console.WriteLine("Buy something first");
                        OrdersView.PressAnyKey();
                    }
                    else
                    {
                        Console.Clear();
                        GetOrderList(orderDetalis);
                        var updateDetalis = GetInput();
                        var amount = orderDetalis.GetCurrentAmount(updateDetalis);
                        product.UpdateProductUp(amount);
                        orderDetalis.UpdateOrderDetalis(updateDetalis);
                        orderDetalis.UpdatePrice(updateDetalis);
                        var updateAmount = new Products(updateDetalis.product_id, updateDetalis.Amount);
                        product.UpdateProduct(updateAmount);
                        return true;
                    }
                    return true;
                case "4":
                    GetIdAndAmount(orderDetalis.GetAllOrdersDetalis(OrderId), product);
                    orderDetalis.DeleteOrderDetalis(OrderId);
                    return true;
                case "5":
                    bool showMenu = true;
                    while (showMenu)
                    {
                        showMenu = getPay(order);
                    }
                    return true;
                case "0":
                    GetIdAndAmount(orderDetalis.GetAllOrdersDetalis(OrderId), product);
                    order.UpdateOrder(UpdateStatus(1));
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
                        showMenu = MainMenu(order, product, orderDetalis);
                    }
                    return true;
                case "0":
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

        static OrderDetalis GetInput()
        {
            bool IsCorrect = true;
            while (IsCorrect == true)
            {
                Console.Write("Product Id: ");
                var ProductIdString = Console.ReadLine();
                Console.Write("Amount: ");
                var QuantityString = Console.ReadLine();
                int ProductId;
                bool parseSuccess = int.TryParse(ProductIdString, out ProductId);
                bool parseSuccessTwo = int.TryParse(QuantityString, out int Quantity);

                if (parseSuccess & parseSuccessTwo)
                {
                    var orderDetalis = new OrderDetalis(OrderId, ProductId, Quantity);
                    return orderDetalis;
                }
                else
                {
                    Console.WriteLine("This is not a number, try again!");
                    IsCorrect = true;
                    continue;
                }

            }

            return null;
        }
        static float GetAllPrice(List<OrderDetalis> list)
        {
            float AllPrice = 0;
            foreach (var product in list)
            {
                AllPrice = AllPrice + product.UnitPrice;
            }
            return AllPrice;
        }

        static void GetOrderList(IOrderDetalisRepository orderDetalis)
        {
            List<OrderDetalis> allOrders = orderDetalis.GetAllOrdersDetalis(OrderId);
            TotalPrice = GetAllPrice(allOrders);
            OrderDetalisView.printList(allOrders, TotalPrice);
            
        }

        static void GetIdAndAmount(List<OrderDetalis> allOrders, IProductsRepository product)
        {
            foreach (var order in allOrders)
            {
                product.UpdatePriceWhenDelete(order.product_id, order.Amount);
            }
        }

        static Orders UpdateStatus(int statusValue)
        {
            var status = new Orders();
            status.Status = statusValue;
            status.OrderId = OrderId;
            return status;
        }

        static bool getPay(IOrdersRepository order)
        {
            Console.WriteLine($"Do you want to pay {TotalPrice} y/n");

            switch (Console.ReadLine())
            {
                case "y":
                    order.UpdateOrder(UpdateStatus(2));
                    GetNewOrderInput(order);
                    return false;
                case "n":
                    return false;
                default:
                    Console.WriteLine("There is no such choice");
                    OrdersView.PressAnyKey();
                    return true;

            }
        }
        static bool IsProductIdInBase(IProductsRepository product, OrderDetalis product_id)
        {
            if (!product.GetAllProductId().Contains(product_id.product_id))
            {
                Console.WriteLine("There is no such id in base, try again!");
                return false;
            }
            else
            {
                return true;
            }

           
        }
        static bool CheckLessThanZero(IProductsRepository product, OrderDetalis order )
        {
            if (Int32.Parse(product.GetAmount(order)) - order.Amount < 0)
            {
                Console.WriteLine("We don't have enough items in stock change amount");
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool IsAnyProductInBase(IOrderDetalisRepository orderDetalis)
        {
            return orderDetalis.IsAnyProductInBase(OrderId).Contains(OrderId);
        }
    }

}
