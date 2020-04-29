using System.Collections.Generic;

namespace OnlineShopCMS.DAL
{
    internal interface ICustomerRepository
    {
        List<Customer> GetCustomers(string amount, string sort);
        Customer GetSingleCustomer(int customerId);
        bool InsertCustomer(Customer ourCustomer);
        bool DeleteCustomer(int customerId);
        bool UpdateCustomer(Customer ourCustomer);
    }
}
