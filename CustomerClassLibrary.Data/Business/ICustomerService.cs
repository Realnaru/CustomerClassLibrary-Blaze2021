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
        public int CreateCustomer(Customer customer);

        public Customer GetCustomer(int customerId);

        public void ChangeCustomer(Customer customer);

        public void DeleteCustomer(Customer customer);
    }
}
