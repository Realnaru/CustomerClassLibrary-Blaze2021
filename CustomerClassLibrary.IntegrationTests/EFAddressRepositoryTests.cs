using CustomerClassLibrary.Data.EFData;
using CustomerLibrary.IntegrationTests.IntegrationTests;
using CustomerLibraryTests.IntegrationTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerClassLibrary.IntegrationTests
{
    public class EFAddressRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateEFAddressRepository()
        {
            var addressRepository = new EFAddressRepository();
            Assert.NotNull(addressRepository);
        }

        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            var addressRepository = new EFAddressRepository();
            var fixture = new CustomerRepositoryFixture();
            var customerRepository = new EFCustomerRepository();

            customerRepository.DeleteAll();

            var customer = fixture.MockCustomer();

            int customerId = customerRepository.Create(customer);    

            var address = new Address();
            address.CustomerId = customerId;
            address.AdressLine = "123";
            address.AdressLine2 = "Main St";
            address.AddressType = AddressType.Billing;
            address.PostalCode = "123456";
            address.Country = "USA";
            address.City = "Anytown";
            address.State = "Anystate";

            int addressId = addressRepository.Create(address);

            Assert.NotEqual(0, addressId);
        }

        [Fact]
        public void ShouldBeAbleToReadAddress()
        {
            var addressRepository = new EFAddressRepository();
            var customerRepository = new EFCustomerRepository();

            var fixtureCustomer = new CustomerRepositoryFixture();
            var fixtureAddress = new CustomerAddressFixture();

            customerRepository.DeleteAll();

            var address = fixtureAddress.MockAddress();
            var customer = fixtureCustomer.MockCustomer();


            int customerId = customerRepository.Create(customer);
            address.CustomerId = customerId;
            int addressId = addressRepository.Create(address);

            var createdAddress = addressRepository.Read(addressId);

            Assert.NotNull(createdAddress);

            Assert.Equal(address.CustomerId, createdAddress.CustomerId);
            Assert.Equal(address.AdressLine, createdAddress.AdressLine);
            Assert.Equal(address.AdressLine2, createdAddress.AdressLine2);
            Assert.Equal(address.AddressType, createdAddress.AddressType);
            Assert.Equal(address.City, createdAddress.City);
            Assert.Equal(address.PostalCode, createdAddress.PostalCode);
            Assert.Equal(address.State, createdAddress.State);
            Assert.Equal(address.Country, createdAddress.Country);
        }

        [Fact]
        public void ShouldBeAbleToUpdateAddress()
        {
            var customerRepository = new EFCustomerRepository();
            var fixtureCustomer = new CustomerRepositoryFixture();

            var customerAddressRepository = new EFAddressRepository();
            var fixtureAddress = new CustomerAddressFixture();

            customerRepository.DeleteAll();

            var customer = fixtureCustomer.MockCustomer();
            var address = fixtureAddress.MockAddress();

            int customerId = customerRepository.Create(customer);

            address.CustomerId = customerId;

            int addressId = customerAddressRepository.Create(address);

            var createdAddress = customerAddressRepository.Read(addressId);

            createdAddress.AdressLine = "245";
            createdAddress.AdressLine2 = "Belleville Road";
            createdAddress.AddressType = AddressType.Shipping;
            createdAddress.City = "Napanee";
            createdAddress.PostalCode = "K7R3M7";
            createdAddress.State = "Ontario";
            createdAddress.Country = "Canada";

            customerAddressRepository.Update(createdAddress);

            var updatedAddress = customerAddressRepository.Read(addressId);

            Assert.Equal("245", updatedAddress.AdressLine);
            Assert.Equal("Belleville Road", updatedAddress.AdressLine2);
            Assert.Equal(AddressType.Shipping, updatedAddress.AddressType);
            Assert.Equal("Napanee", updatedAddress.City);
            Assert.Equal("K7R3M7", updatedAddress.PostalCode);
            Assert.Equal("Ontario", updatedAddress.State);
            Assert.Equal("Canada", updatedAddress.Country);
        }

        [Fact]
        public void ShouldBeAbleToDeleteAddress()
        {
            var customerRepository = new EFCustomerRepository();
            var fixtureCustomer = new CustomerRepositoryFixture();

            var customerAdressRepository = new EFAddressRepository();
            var fixtureAddress = new CustomerAddressFixture();

            customerRepository.DeleteAll();

            var customer = fixtureCustomer.MockCustomer();
            var address = fixtureAddress.MockAddress();

            int customerId = customerRepository.Create(customer);

            address.CustomerId = customerId;

            int addressId = customerAdressRepository.Create(address);

            customerAdressRepository.Delete(addressId);

            var deletedAddress = customerAdressRepository.Read(addressId);

            Assert.Null(deletedAddress);
        }

        [Fact]
        public void ShouldReadAddressesByCustomerId()
        {
            var customerRepository = new EFCustomerRepository();
            var customerAddressRepository = new EFAddressRepository();
            var fixtureCustomer = new CustomerRepositoryFixture();

          
            var fixtureAddress = new CustomerAddressFixture();

            customerRepository.DeleteAll();

            var customer = fixtureCustomer.MockCustomer();
            var address = fixtureAddress.MockAddress();

            int customerId = customerRepository.Create(customer);

            address.CustomerId = customerId;

            int addressId = customerAddressRepository.Create(address);

            var createdAddress = customerAddressRepository.Read(addressId);

            createdAddress.AdressLine = "245";
            createdAddress.AdressLine2 = "Belleville Road";
            createdAddress.AddressType = AddressType.Shipping;
            createdAddress.City = "Napanee";
            createdAddress.PostalCode = "K7R3M7";
            createdAddress.State = "Ontario";
            createdAddress.Country = "Canada";

            customerAddressRepository.Update(createdAddress);

            List<Address> addresses = customerAddressRepository.ReadAll(customerId);

            var updatedAddress = addresses[1];

            Assert.Equal("245", updatedAddress.AdressLine);
            Assert.Equal("Belleville Road", updatedAddress.AdressLine2);
            Assert.Equal(AddressType.Shipping, updatedAddress.AddressType);
            Assert.Equal("Napanee", updatedAddress.City);
            Assert.Equal("K7R3M7", updatedAddress.PostalCode);
            Assert.Equal("Ontario", updatedAddress.State);
            Assert.Equal("Canada", updatedAddress.Country);
        }
    }
}
