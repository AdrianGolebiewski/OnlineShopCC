using OnlineShopCMSMySql.DAL;

namespace OnlineShopCMSMySql
{
    class Program
    {
        static void Main(string[] args)
        {
            Login login = new Login();
            login.GetAccess();

            IProductRepository product = new ProductRespository();
            {
                bool showMenu = true;
                while (showMenu)
                {
                    showMenu = ProductController.MainMenu(product);
                }
            }

        }
    }
}
