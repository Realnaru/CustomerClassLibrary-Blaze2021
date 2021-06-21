using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using CustomerClassLibrary.Data;
using CustomerClassLibrary.Data.Repositories;

namespace CustomerClassLibrary.Business
{
    public class CustomerService
    {
        private readonly IEntityRepository<Customer> _customerRepository;

        public readonly IEntityRepository<Address> _addressRepository;

        public readonly IEntityRepository<CustomerNote> _noteRepository;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
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
                foreach (var address in customer.AdressesList)
                {
                    _addressRepository.Create(address);
                }

                foreach (var note in customer.Note)
                {
                    _noteRepository.Create(note);
                }

                 customerId = _customerRepository.Create(customer);

                transactionScope.Complete();

            }

            return customerId;
        }
           

        public Customer GetCustomer(int customerId)
        {
            var customer =  _customerRepository.Read(customerId);
            customer.AdressesList = _addressRepository.ReadByCustomerId(customerId);
            customer.Note = _noteRepository.ReadNoteByCustomerId(customerId);
            return customer;

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
    }
}
