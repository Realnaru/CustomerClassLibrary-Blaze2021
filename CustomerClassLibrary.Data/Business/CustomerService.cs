using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerClassLibrary.Data;
using CustomerClassLibrary.Data.Repositories;

namespace CustomerClassLibrary.Business
{
    public class CustomerService
    {
        private readonly IEntityRepository<Customer> _customerRepository;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }

        public CustomerService(IEntityRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public Customer GetCustomer(int customerId)
        {
            return _customerRepository.Read(customerId);
        }

        public int CreateCustomer(Customer customer)
        {
            return _customerRepository.Create(customer);
        }

        public void ChangeCustomer(Customer customer)
        {
            _customerRepository.Update(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            _customerRepository.Delete(customer);
        }
    }
}
