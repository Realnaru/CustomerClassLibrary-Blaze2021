using CustomerClassLibrary.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CustomerClassLibrary.Data;
using Moq;
using CustomerClassLibrary;
using CustomerClassLibrary.Data.Repositories;

namespace CustomerLibraryTests.CustomerLibraryTests
{
    public class CustomerServiceTests
    {
        [Fact]
        public void ShouldInitializeCustomerService()
        {
            var customerService = new CustomerService();
        }


        [Fact]
        public void ShouldCreateCustomerAndReturnId()
        {
            var customerMock = new Mock<IEntityRepository<Customer>>();
            var customerToCreate = new Customer();
            int expectedId = 1;

            customerMock.Setup(x => x.Create(customerToCreate)).Returns(() => expectedId);

            var customerService = new CustomerService(customerMock.Object);

            int customerId = customerService.CreateCustomer(customerToCreate);

            Assert.Equal(expectedId, customerId);
        }

        [Fact]
        public void ShouldGetCustomerById()
        {
            var customerMock = new Mock<IEntityRepository<Customer>>();
            var customerExpected = new Customer();

            customerMock.Setup(x => x.Read(1)).Returns(() => customerExpected);

            var customerService = new CustomerService(customerMock.Object);

            var customer = customerService.GetCustomer(1);

            Assert.Equal(customerExpected, customer);
        }

        [Fact]
        public void ShouldUpdateCustomer()
        {
            var customerMock = new Mock<IEntityRepository<Customer>>();
            var customerToUpdate = new Customer();
            var customerExpected = new Customer();

            customerMock.Setup(x => x.Update(customerToUpdate));

            var customerService = new CustomerService(customerMock.Object);

            customerService.ChangeCustomer(customerToUpdate);

            customerMock.Verify(x => x.Update(customerToUpdate), Times.Exactly(1));
        }

        [Fact]
        public void ShouldDeleteCustomer()
        {
            var customerMock = new Mock<IEntityRepository<Customer>>();
            var customerToDelete = new Customer();

            customerMock.Setup(x => x.Delete(customerToDelete));

            var customerService = new CustomerService(customerMock.Object);

            customerService.DeleteCustomer(customerToDelete);

            customerMock.Verify(x => x.Delete(customerToDelete), Times.Exactly(1));
        }
    }
}

