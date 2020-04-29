
namespace OnlineShopCMS
{
    class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public bool IsActive { get; set; }

        public Customer(int customerId, string customerFirstName, string customerlastname, bool isactive)
        {
            this.CustomerID = customerId;
            this.CustomerFirstName = customerFirstName;
            this.CustomerLastName = customerlastname;
            this.IsActive = isactive;

        }

    }
}
