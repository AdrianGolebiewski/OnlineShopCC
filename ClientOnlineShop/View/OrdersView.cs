using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ClientOnlineShop
{
    class OrdersView
    {
        public static void PrintMenu(int currentCustomerId, UInt64 currentOrderId)
        {
            Console.WriteLine("M E N U:");
            Console.WriteLine();
            
                
                Console.WriteLine($"Your current CustomerId is: {currentCustomerId}");
                Console.WriteLine($"Your current OrderId is: {currentOrderId}");
                Console.WriteLine();
                Console.WriteLine("1)  Add products to my order");
                Console.WriteLine("2)  Show my order");
                Console.WriteLine("3)  Update my order");
                Console.WriteLine("4)  Delete my order");
                Console.WriteLine("5)  Go pay");
                Console.WriteLine("6)  Create new order");
                Console.WriteLine("0)  Exit");
                Console.Write("\r\nSelect an option: ");
        }
        public static void CreateOrderMenu()
        {
            Console.WriteLine(" Create New Order M E N U: ");
            Console.WriteLine();
            Console.WriteLine("1)  I want to register to 'Shop Online'");
            Console.WriteLine("2)  I have login to 'Shop Online'");
            Console.WriteLine("3)  I don't need a login (guest mode)");
            Console.WriteLine("4)  Exit");
            Console.Write("\r\nSelect an option: ");
        }

        public static void PressAnyKey()
        {
            Console.WriteLine("Press any key to return to main menu");
            Console.ReadLine();
        }
        public static void NotImplementedYet()
        {
            Console.WriteLine("Not yet implemented, try another solution");
        }

        public static void AddedSuccessfully()
        {
        Console.WriteLine();
        Console.WriteLine("product added successfully :)");
        Console.ReadLine();
        }

}
}