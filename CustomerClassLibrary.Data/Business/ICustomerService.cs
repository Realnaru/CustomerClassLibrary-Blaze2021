using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary.Data.Business
{
    public interface ICustomerService
    {
        IReadOnlyCollection<Customer> GetAllCustomers();

        IReadOnlyCollection<Customer> GetCustomersPartially(int pageNumber, int rowsCount);

        public int CreateCustomer(Customer customer);

        public Customer GetCustomer(int customerId);

        public int GetAmountOfCustomers();

        public void ChangeCustomer(Customer customer);

        public void DeleteCustomer(Customer customer);
    }
}
