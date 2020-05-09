using System;
using System.Collections.Generic;

namespace OnlineShopCMSMySql
{
    class CustomerView
    {
        public static void printMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Create product");
            Console.WriteLine("2) Remove product");
            Console.WriteLine("3) Update product");
            Console.WriteLine("4) Read all products");
            Console.WriteLine("5) Read one product");
            Console.WriteLine("6) Exit");
            Console.Write("\r\nSelect an option: ");
        }

        public static void printList(List<Customer> list)

        {
            foreach (var product in list)
            {

                Console.WriteLine($" {product.CustomerID} | {product.CustomerFirstName} | {product.CustomerLastName}  | {product.IsActive}");
            }
            pressAnyKey();
        }

        public static void printOne(Customer product)

        {
            Console.WriteLine($" {product.CustomerID} | {product.CustomerFirstName} | {product.CustomerLastName}  | {product.IsActive}");
            pressAnyKey();
        }

        public static void pressAnyKey()
        {
            Console.WriteLine("Press any key to return to main menu");
            Console.Read();
        }
    }
}
