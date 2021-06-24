using CustomerClassLibrary;
using CustomerClassLibrary.Data;
using CustomerLibrary.IntegrationTests.IntegrationTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLibraryTests.IntegrationTests
{
    public class CustomerRepositoryFixture
    {
        public Customer CreateMockCustomer()
        {
            var customerRepository = new CustomerRepository();
            customerRepository.DeleteAll();

            var customer = MockCustomer();

            customerRepository.Create(customer);

            return customer;     
        }

        public Customer MockCustomer()
        {
            var fixtureAddress = new CustomerAddressFixture();

            var address = fixtureAddress.MockAddress();

            var note = new CustomerNote()
            {
                Note = "Kiity Ipsum"
            };

            var customer = new Customer();
            customer.FirstName = "John";
            customer.LastName = "Doe";
            customer.PhoneNumber = "1111111";
            customer.Email = "jd@gmail.com";
            customer.TotalPurshasesAmount = 100;
            customer.AddAddress(address);
            customer.AddNote(note);

            return customer;
        }
    }
}
