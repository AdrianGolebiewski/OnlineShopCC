using OnlineShopCMS.DAL;

namespace OnlineShopCMS
{
    class Program
    {
        static void Main(string[] args)
        {
            ICustomerRepository product = new CustomerRespository();

            {
                bool showMenu = true;
                while (showMenu)
                {
                    showMenu = CustomerController.MainMenu(product);
                }
            }

        }
    }
}
