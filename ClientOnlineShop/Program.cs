using ClientOnlineShop;
using ClientOnlineShop.DAL;

namespace ClientOnlineShop

{
    class Program
    {
        static void Main(string[] args)
        {
          
            IProductsRepository product = new ProductsRespository();
            IOrdersRepository order = new OrdersRespository();
            IOrderDetalisRepository orderDetalis = new OrderDetalisRepository();



            {
                bool showMenu = true;
                while (showMenu)
                {
                    showMenu = OrdersController.CreateOrderMenu(order, product, orderDetalis);
                        
                    //showMenu = ProductController.MainMenu(product);
                }
            }

        }
    }
}
