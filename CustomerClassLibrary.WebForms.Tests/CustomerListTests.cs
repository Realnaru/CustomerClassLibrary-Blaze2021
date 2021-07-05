using CustomerClassLibrary.Business;
using CustomerClassLibrary.Data.Business;
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
        public void ShouldbeAbleLoadCustomers()
        {
            var customerServiceMock = new Mock<ICustomerService>();

            var customerRepositoryFixture = new CustomerRepositoryFixture();

            var firstCustomer = customerRepositoryFixture.MockCustomer();
            var secondCustomer = customerRepositoryFixture.MockCustomer();

            customerServiceMock.Setup(x => x.GetCustomersPartially(0, 5)).Returns(new List<Customer>()
            {
                firstCustomer,
                secondCustomer
            });

            var customerList = new CustomerList(customerServiceMock.Object);
            customerList.LoadCustomers();

            Assert.NotNull(customerList.Customers);
            Assert.Collection(customerList.Customers, 
                item => Assert.Equal(firstCustomer, item), 
                item => Assert.Equal(secondCustomer, item));
        }

        [Fact]
        public void ShouldBeAbleToGetAmountOfCustomers()
        {
            var customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock.Setup(x => x.GetAmountOfCustomers()).Returns(10);

            var customerList = new CustomerList(customerServiceMock.Object);

            customerList.GetAmountOfCustomers();

            Assert.Equal(10, customerList.AmountOfCustomers);
        }

        [Fact]
        public void ShouldBeAbleToGetNextCustomers()
        {
            var customerRepositoryFixture = new CustomerRepositoryFixture();
            var customer = customerRepositoryFixture.MockCustomer();

            var customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock.Setup(x => x.GetCustomersPartially(1, 5)).Returns(new List<Customer>() {customer});

            var customerList = new CustomerList(customerServiceMock.Object);

            customerList.OnNextClick(customerList, EventArgs.Empty);

            //customerServiceMock.Verify(x => x.GetCustomersPartially(1, 5));

            //Assert.NotNull(customerList.Customers);
            //Assert.Single(customerList.Customers);
            //Assert.Collection(customerList.Customers, item => Assert.Equal(customer, item));
        }
    }
}
