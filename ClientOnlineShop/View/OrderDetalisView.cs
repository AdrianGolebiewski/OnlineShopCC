using System;
using System.Collections.Generic;

namespace ClientOnlineShop
{
    class OrderDetalisView
    {
        public static void printList(List<OrderDetalis> list, float allPrice)
            
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("    id | category   | manufact   | color      | size | price(One) | price(all)  | amount |");
            Console.ResetColor();
            foreach (var product in list)
            {

                Console.WriteLine($" {product.product_id,5} | {product.category,-10} | {product.manufacturer,-10} | {product.color,-10} | {product.size,-4} | {product.price, 10} | " +
                                   $" {product.UnitPrice,10} | {product.Amount,6} |");
            }
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Total price: {allPrice} ");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
