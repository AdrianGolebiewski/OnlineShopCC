using System;
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
                    product.AddProduct(getProductInput());
                    return true;
                case "5":
                    Console.Clear();
                    product.DeleteProduct(getId());
                    return true;
                case "6":
                    Console.Clear();
                    product.UpdateProduct(getProductInput());
                    return true;
                case "2":
                    Console.Clear();
                    ProductsView.printList(product.GetFewProducts(getAmount()));
                    return true;
                case "1":
                    Console.Clear();
                    ProductsView.printList(product.GetAllProducts());
                    return true;
                case "3":
                    Console.Clear();
                    ProductsView.printOne(product.GetSingleProduct(getId()));
                    return true;
                case "7":
                   return false;
                default:
                    Console.WriteLine("There is no such choice");
                    return true;
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
