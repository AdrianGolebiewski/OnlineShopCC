﻿using System;
using System.Collections.Generic;

namespace ClientOnlineShop
{
    class ProductsView
    {
       public static void printList(List<Products> list)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("    id | category   | manufact   | color      | size | price  | qty   | desc  | index");
            Console.ResetColor();
            foreach (var product in list)
            {

                Console.WriteLine($" {product.product_id, 5} | {product.category, -10} | {product.manufacturer, -10} | {product.color, -10} | {product.size, -4} | {product.price, -6} | " +
                                  $"{product.quantity, -5} | {product.description, 5} | {product.product_index, -7}");
            }
           
        }
    }
}
