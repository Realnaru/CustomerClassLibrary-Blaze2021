using CustomerClassLibrary.Common;
using CustomerClassLibrary.Data.EFData;
using CustomerLibrary.IntegrationTests.IntegrationTests;
using CustomerLibraryTests.IntegrationTests;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerClassLibrary.IntegrationTests
{
    public class EFCustomerRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateEFCustomerRepository()
        {
            var customerRepository = new EFCustomerRepository();

            Assert.NotNull(customerRepository);
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            var customerRepository = new EFCustomerRepository();
            var customer = new Customer();

            var addressFixture = new CustomerAddressFixture();
            var address = addressFixture.MockAddress();

            customerRepository.DeleteAll();

            customer.FirstName = "John";
            customer.LastName = "Doe";
            customer.PhoneNumber = "1111111";
            customer.Email = "jd@mail.com";
            customer.TotalPurshasesAmount = 1000;
            customer.AddAddress(address);
            customer.AddNote(new CustomerNote() { Note = "Kitty Ipsum"});

            int customerId = customerRepository.Create(customer);

            Assert.NotEqual(0, customerId);
        }

        [Fact]
        public void ShouldThrowExceptionIfCustomerHasWrongData()
        {
            var customerRepository = new EFCustomerRepository();
            var customer = new Customer();

            var addressFixture = new CustomerAddressFixture();
            var address = addressFixture.MockAddress();

            customer.FirstName = "John";
            customer.PhoneNumber = "12345611111111111111";
            customer.Email = "111111111111111111111111111";
            customer.TotalPurshasesAmount = 1000;
            customer.AddAddress(address);
            customer.AddNote(new CustomerNote() { Note = "Kitty Ipsum" });

            Assert.Throws<DbEntityValidationException>(() => customerRepository.Create(customer));
        }

        [Fact]
        public void ShouldBeAbleToReadCustomer()
        {
            var customerRepository = new EFCustomerRepository();
            var fixture = new CustomerRepositoryFixture();

            customerRepository.DeleteAll();

            var customer = fixture.MockCustomer();
            int customerId = customerRepository.Create(customer);

            var createdCustomer = customerRepository.Read(customerId);

            Assert.Equal(customer.FirstName, createdCustomer.FirstName);
            Assert.Equal(customer.LastName, createdCustomer.LastName);
            Assert.Equal(customer.PhoneNumber, createdCustomer.PhoneNumber);
            Assert.Equal(customer.Email, createdCustomer.Email);
            Assert.Equal(customer.TotalPurshasesAmount, createdCustomer.TotalPurshasesAmount);
        }


        [Fact]
        public void ShouldBeAbleToReadAllCustomers()
        {
            var customerRepository = new EFCustomerRepository();
            var fixture = new CustomerRepositoryFixture();

            customerRepository.DeleteAll();

            var customer = fixture.MockCustomer();
            var secondCustomer = fixture.MockCustomer();
            int customerId = customerRepository.Create(customer);
            customerRepository.Create(secondCustomer);

            List<Customer> customers = customerRepository.ReadAll();

            Assert.Equal(2, customers.Count);
        }

        [Fact]
        public void ShouldBeAbleToReadCustomersPartially()
        {
            var customerRepository = new EFCustomerRepository();
            var fixture = new CustomerRepositoryFixture();

            customerRepository.DeleteAll();

            var customer = fixture.MockCustomer();
            var secondCustomer = fixture.MockCustomer();
            var thirdCustomer = fixture.MockCustomer();
            var fourthCustomer = fixture.MockCustomer();
            var fithCustomer = fixture.MockCustomer();
            var sixthCustomer = fixture.MockCustomer();

            customerRepository.Create(customer);
            customerRepository.Create(secondCustomer);
            customerRepository.Create(thirdCustomer);
            customerRepository.Create(fourthCustomer);
            customerRepository.Create(fithCustomer);
            customerRepository.Create(sixthCustomer);

            List<Customer> customers = customerRepository.ReadPartially(0, 5);

            Assert.Equal(5, customers.Count);
        }

        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            var customerRepository = new EFCustomerRepository();
            var fixture = new CustomerRepositoryFixture();
            var addressFixture = new CustomerAddressFixture();

            customerRepository.DeleteAll();

            var customer = fixture.MockCustomer();
            int customerId = customerRepository.Create(customer);

            var createdCustomer = customerRepository.Read(customerId);

            createdCustomer.FirstName = "Jein";
            createdCustomer.LastName = "Roe";
            createdCustomer.PhoneNumber = "999999";
            createdCustomer.Email = "dj@gmail.com";
            createdCustomer.TotalPurshasesAmount = 1000;
            createdCustomer.AdressesList.Add(addressFixture.MockAddress());
            createdCustomer.Note.Add(new CustomerNote() { NoteId = 1, Note = "Kitty Ipsum"});

            customerRepository.Update(createdCustomer);

            var updatedCustomer = customerRepository.Read(createdCustomer.CustomerId);

            Assert.Equal("Jein", updatedCustomer.FirstName);
            Assert.Equal("Roe", updatedCustomer.LastName);
            Assert.Equal("999999", updatedCustomer.PhoneNumber);
            Assert.Equal("dj@gmail.com", updatedCustomer.Email);
            Assert.Equal(1000, updatedCustomer.TotalPurshasesAmount);
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var customerRepository = new EFCustomerRepository();
            var fixture = new CustomerRepositoryFixture();

            customerRepository.DeleteAll();

            var customer = fixture.MockCustomer();
            int customerId = customerRepository.Create(customer);

            var createdCustomer = customerRepository.Read(customerId);

            customerRepository.Delete(createdCustomer);

            var deletedCustomer = customerRepository.Read(customerId);

            Assert.Null(deletedCustomer);
        }

        [Fact]
        public void ShouldBeAbleToGetAmountOfCustomers()
        {
            var customerRepository = new EFCustomerRepository();
            var fixture = new CustomerRepositoryFixture();

            customerRepository.DeleteAll();

            var customer = fixture.MockCustomer();
            int customerId = customerRepository.Create(customer);

            int amountOfCustomers = customerRepository.GetAmountOfRows();

            Assert.Equal(1, amountOfCustomers);
        }
    }
}
