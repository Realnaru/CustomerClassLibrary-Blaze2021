using CustomerClassLibrary;
using CustomerClassLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLibrary.IntegrationTests.IntegrationTests
{
    public class CustomerAddressFixture
    {
        public Address CreateMockAddress()
        {
            var customerAddressRepository = new CustomerAddressRepository();
    
            var customer = MockAddress();

            customerAddressRepository.Create(customer);

            return customer;
        }

        public Address MockAddress()
        {
            var address = new Address();

            address.AdressLine = "123";
            address.AdressLine2 = "Main St";
            address.AddressType = AddressType.Billing;
            address.PostalCode = "123456";
            address.Country = "USA";
            address.City = "Anytown";
            address.State = "Anystate";
            
            return address;
        }
    }
}
