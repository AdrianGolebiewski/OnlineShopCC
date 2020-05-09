using System;
using OnlineShopCMSMySql.DAL;

namespace OnlineShopCMSMySql
{
    public static class CustomerController
    {
        internal static bool MainMenu(ICustomerRepository product)
        {
            CustomerView.printMenu();
           
            switch (Console.ReadLine())
            {   
                case "1":
                    Console.Clear();
                    product.InsertCustomer(getCustomerInput());
                    return true;
                case "2":
                    Console.Clear();
                    product.DeleteCustomer(getId());
                    return true;
                case "3":
                    Console.Clear();
                    product.UpdateCustomer(getCustomerInput());
                    return true;
                case "4":
                    Console.Clear();
                    CustomerView.printList(product.GetCustomers(getAmount(), getSort()));
                    return true;
                case "5":
                    Console.Clear();
                    CustomerView.printOne(product.GetSingleCustomer(getId()));
                    return true;
                case "6":
                   return false;
                default:
                    Console.WriteLine("There is no such choice");
                    return true;
            }
        }
                static Customer getCustomerInput()
                {
                Console.Write("ID: ");
                int _customerId = Convert.ToInt16(Console.ReadLine());
                Console.Write("FirstName: ");
                string _custumerFirstName;
                _custumerFirstName = Console.ReadLine();
                Console.Write("LastName: ");
                string _custumerLastName = Console.ReadLine();
                Console.Write("Active true/false: ");
                string _active = Console.ReadLine();
                bool _isActive = false;
                //_isActive => _active == 0; TODO: improve lambda "if" statements

                if (_active == "true")
                {
                    _isActive = true;
                }
                else if (_active == "false")
                {
                    _isActive = false;
                }

                var customer = new Customer(_customerId, _custumerFirstName, _custumerLastName, _isActive);

                return customer;
            
        }

        static int getId()
        {
            Console.Write("ID: ");
            int customerId = Convert.ToInt16(Console.ReadLine());

            return customerId;
        }

        //TODO: how to return two different types?
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
