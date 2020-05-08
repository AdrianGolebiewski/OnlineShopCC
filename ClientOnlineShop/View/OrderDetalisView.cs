using System;
using System.Collections.Generic;

namespace ClientOnlineShop
{
    class OrderDetalisView
    {
        public static void printList(List<OrderDetalis> list, float allPrice)
            
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("    id | category    | manufact   | color      | size | price  | qty   | price(all)  | amount");
            Console.ResetColor();
            foreach (var product in list)
            {

                Console.WriteLine($" {product.product_id,5} | {product.category,-10} | {product.manufacturer,-10} | {product.color,-10} | {product.size,-4} | {product.price,-6} | " +
                                   $" {product.UnitPrice,5} | {product.Amount,-7}");
            }

            Console.WriteLine($"Total price: {allPrice} ");
            Console.WriteLine();
            ProductsView.pressAnyKey();
        }
    }
}
