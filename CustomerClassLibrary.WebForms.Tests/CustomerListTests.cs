using CustomerClassLibrary.Business;
using CustomerClassLibrary.Data.Repositories;
using CustomerLibraryTests.IntegrationTests;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace CustomerClassLibrary.WebForms.Tests
{
    public class CustomerListTests
    {
        [Fact]
        public void ShouldBeAbleTocreateCustomerList()
        {
            var customerList = new CustomerList();
        }

        [Fact]
        public void ShouldLoadCustomers()
        {
            var customerMockRepository = new Mock<IEntityRepository<Customer>>();
            var addressMockRepository = new Mock<IEntityRepository<Address>>();
            var noteMockRepository = new Mock<IEntityRepository<CustomerNote>>();

            var customerFixture = new CustomerRepositoryFixture();

            var firstCustomer = customerFixture.MockCustomer();
            var secondCustomer = customerFixture.MockCustomer();

            customerMockRepository.Setup(x => x.ReadAll()).Returns(() => new List<Customer>()
            {
                firstCustomer,
                secondCustomer
            });

            var customerService = new CustomerService(customerMockRepository.Object, addressMockRepository.Object, noteMockRepository.Object);

            var customerList = new CustomerList(customerService);

            customerList.LoadCustomers();

            Assert.Equal(2, customerList.Customers.Count);
        }
    }
}
