using System.Collections.Generic;
using Npgsql;
using System.Data;
using Dapper;
using System.Linq;


namespace OnlineShopCMS.DAL
{
    class CustomerRespository : ICustomerRepository
    {
        private IDbConnection _db = new NpgsqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        bool ICustomerRepository.DeleteCustomer(int customerId)
        {
            int rowsAffected = this._db.Execute(@"DELETE FROM Customer WHERE CustomerID = @CustomerID", new { CustomerID = customerId });

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        List<Customer> ICustomerRepository.GetCustomers(string amount, string sort)
        {
            return this._db.Query<Customer>($"SELECT CustomerID, CustomerFirstName, CustomerLastName, IsActive FROM Customer LIMIT {amount}").ToList();
        }

        Customer ICustomerRepository.GetSingleCustomer(int customerId)
        {
            return _db.Query<Customer>("SELECT CustomerID, CustomerFirstName, CustomerLastName, IsActive FROM Customer WHERE CustomerID =@CustomerID", new { CustomerID = customerId }).SingleOrDefault();
        }

        bool ICustomerRepository.InsertCustomer(Customer ourCustomer)
        {
             int rowsAffected = this._db.Execute("INSERT INTO customer (CustomerID, CustomerFirstName, CustomerLastName, IsActive) VALUES (@CustomerID, @CustomerFirstName, @CustomerLastName, @IsActive)", new { CustomerId = ourCustomer.CustomerID, CustomerFirstName = ourCustomer.CustomerFirstName, CustomerLastName = ourCustomer.CustomerLastName, isActive = ourCustomer.IsActive});

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        bool ICustomerRepository.UpdateCustomer(Customer ourCustomer)
        {
            int rowsAffected = this._db.Execute("UPDATE Customer SET CustomerFirstName = @CustomerFirstName , CustomerLastName = @CustomerLastName, IsActive = @IsActive WHERE CustomerID = " + ourCustomer.CustomerID, ourCustomer);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
    }
}
