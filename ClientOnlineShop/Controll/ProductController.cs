using System;
using ClientOnlineShop.DAL;

namespace ClientOnlineShop

{
    public static class ProductController
    {  
       
                static Products getProductInput()
                {
                    Console.Write("Product Id: ");
                    int _product_id = Convert.ToInt16(Console.ReadLine());
                    Console.Write("Category: ");
                    string _category = Console.ReadLine();
                    Console.Write("Manufacturer: ");
                    string _manufacturer = Console.ReadLine();
                    Console.Write("Color: ");
                    string _color = Console.ReadLine();
                    Console.Write("Size: ");
                    string _size = Console.ReadLine();
                    Console.Write("Price: ");
                    float _price = float.Parse(Console.ReadLine());
                    Console.Write("Quantity: ");
                    int _quantity = int.Parse(Console.ReadLine());
                    Console.Write("Description: ");
                    string _description = Console.ReadLine();
                    Console.Write("Products index: ");
                    string _product_index = Console.ReadLine();
                
                    var prod = new Products(_product_id, _category, _manufacturer, _color, _size, _price, _quantity, _description, _product_index);

                    return prod;
            
        }

        static int getId()
        {
            Console.Write("ID: ");
            int productId = Convert.ToInt32(Console.ReadLine());
            return productId;
        }

        static string getAmount()
        {
            Console.Write("Amount: ");
            string amount = Console.ReadLine();
            return amount;
        }

        static string getSort()
        {
            Console.Write("Sort: ");
            string sort = Console.ReadLine();
            return sort;
        }

    }
}
