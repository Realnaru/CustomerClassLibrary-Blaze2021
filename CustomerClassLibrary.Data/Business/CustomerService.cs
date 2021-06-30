using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using CustomerClassLibrary.Data;
using CustomerClassLibrary.Data.Business;
using CustomerClassLibrary.Data.Repositories;

namespace CustomerClassLibrary.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly IEntityRepository<Customer> _customerRepository;

        private readonly IEntityRepository<Address> _addressRepository;

        private readonly IEntityRepository<CustomerNote> _noteRepository;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
            _addressRepository = new CustomerAddressRepository();
            _noteRepository = new CustomerNoteRepository();
        }

        public CustomerService(IEntityRepository<Customer> customerRepository, IEntityRepository<Address> addressRepository,
            IEntityRepository<CustomerNote> customerNoteRepository)
        {
            _customerRepository = customerRepository;

            _addressRepository = addressRepository;

            _noteRepository = customerNoteRepository;
        }

        public int CreateCustomer(Customer customer)
        {
            int customerId;

            using (var transactionScope = new TransactionScope())
            {
                 customerId = _customerRepository.Create(customer);

                foreach (var address in customer.AdressesList)
                {
                     address.CustomerId = customerId;
                    _addressRepository.Create(address);
                }

                foreach (var note in customer.Note)
                {
                     note.CustomerId = customerId;
                    _noteRepository.Create(note);
                }

                transactionScope.Complete();

            }

            return customerId;
        }
           
        public Customer GetCustomer(int customerId)
        {
            var customer =  _customerRepository.Read(customerId);
            customer.AdressesList = _addressRepository.ReadAll(customerId);
            customer.Note = _noteRepository.ReadAll(customerId);
            return customer;

        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = _customerRepository.ReadAll();
            
            foreach (var customer in customers)
            { 
                customer.AdressesList = _addressRepository.ReadAll(customer.CustomerId);
                customer.Note = _noteRepository.ReadAll(customer.CustomerId);
            }

            return customers;
        }

        public List<Customer> GetCustomersPartially(int pageNumber, int rowsCount)
        {
            return _customerRepository.ReadPartially(pageNumber, rowsCount);
        }

        public void ChangeCustomer(Customer customer)
        {
            using (var transactionScope = new TransactionScope())
            {
                _customerRepository.Update(customer);

                foreach (var address in customer.AdressesList)
                {
                    _addressRepository.Update(address);
                }

                foreach (var note in customer.Note)
                {
                    _noteRepository.Update(note);
                }

                transactionScope.Complete();
            }
            
        }

        public void DeleteCustomer(Customer customer)
        {
            _customerRepository.Delete(customer);
            /*
            foreach (var address in customer.AdressesList)
            {
                _addressRepository.Delete(address);
            }

            foreach (var note in customer.Note)
            {
                _noteRepository.Delete(note);
            }
            */
        }

        IReadOnlyCollection<Customer> ICustomerService.GetAllCustomers()
        {
            var customers = _customerRepository.ReadAll();
            return customers.ToArray();
        }
    }
}
