using System;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
using OnlineShopCMSMySql.DAL;


namespace OnlineShopCMSMySql
{
    public static class ProductController
    {
        internal static bool MainMenu(IProductRepository product)
        {
            ProductsView.printMenu();
           
            switch (Console.ReadLine())
            {   
                case "4":
                    Console.Clear();
                    try
                    {
                        product.AddProduct(getProductInput());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong value !");
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Product has been added");
                    Console.ResetColor();
                    Console.WriteLine();
                    return true;
                case "5":
                    Console.Clear();
                    try
                    {
                        product.DeleteProduct(getId());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong value !");
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Product has been removed");
                    Console.ResetColor();
                    Console.WriteLine();
                    return true;
                case "6":
                    Console.Clear();
                    try
                    {
                        product.UpdateProduct(getProductInput());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong value !");
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Product has been updated");
                    Console.ResetColor();
                    Console.WriteLine();
                    return true;
                case "2":
                    Console.Clear();
                    try
                    {
                        ProductsView.printList(product.GetFewProducts(getAmount()));
                    }
                    catch (Exception)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong value !");
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                    return true;
                case "1":
                    Console.Clear();
                    try
                    {
                        ProductsView.printList(product.GetAllProducts());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong value !");
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                    return true;
                case "3":
                    Console.Clear();
                    try
                    {
                        ProductsView.printOne(product.GetSingleProduct(getId()));
                    }
                    catch (Exception)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong value !");
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                    return true;
                case "7":
                    Console.Clear();
                    Environment.Exit(7);
                    return true;
                default:
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("There is no such choice");
                    Console.ResetColor();
                    Console.WriteLine();
                    return false;
            }
        }

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

        static int getAmount()
        {
            Console.Write("Amount: ");
            int amount = int.Parse(Console.ReadLine());
            return amount;
        }
        /*
        static string getSort()
        {
            Console.Write("Sort: ");
            string sort = Console.ReadLine();
            return sort;
        }
        */
    }
}
