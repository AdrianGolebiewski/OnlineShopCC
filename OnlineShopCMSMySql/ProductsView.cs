using System;
using System.Collections.Generic;

namespace OnlineShopCMSMySql
{
    class ProductsView
    {
        public static void printMenu()
        { 
            Console.WriteLine("M E N U:");
            Console.WriteLine();
            Console.WriteLine("1)  Show all products");
            Console.WriteLine("2)  Show few products");
            Console.WriteLine("3)  Show single product");
            Console.WriteLine("4)  Add product");
            Console.WriteLine("5)  Delete product");
            Console.WriteLine("6)  Udate product");
            Console.WriteLine("7)  Exit");
            Console.Write("\r\nSelect an option: ");
        }

        public static void printList(List<Products> list)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("    id | category   | manufact   | color      | size | price  | qty   | desc  | index");
            Console.ResetColor();
            foreach (var product in list)
            {

                Console.WriteLine($" {product.product_id, 5} | {product.category, -10} | {product.manufacturer, -10} | {product.color, -10} | {product.size, -4} | {product.price, -6} | " +
                                  $"{product.quantity, -5} | {product.description, 5} | {product.product_index, -7}");
            }
            Console.WriteLine();
            // pressAnyKey();
        }

        public static void printOne(Products product)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("    id | category   | manufact   | color      | size | price  | qty   | desc  | index");
            Console.ResetColor();
            Console.WriteLine($" {product.product_id,5} | {product.category,-10} | {product.manufacturer,-10} | {product.color,-10} | {product.size,-4} | {product.price,-6} | " +
                              $"{product.quantity,-5} | {product.description,5} | {product.product_index,-7}");

            Console.WriteLine();
            // pressAnyKey();
        }

        public static void pressAnyKey()
        {
            Console.WriteLine("Press any key to return to main menu");
            Console.Read();
        }
    }
}
