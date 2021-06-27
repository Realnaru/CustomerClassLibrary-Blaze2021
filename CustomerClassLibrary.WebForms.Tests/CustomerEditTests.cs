using CustomerClassLibrary.Business;
using CustomerClassLibrary.Data.Repositories;
using CustomerLibrary.IntegrationTests.IntegrationTests;
using CustomerLibraryTests.IntegrationTests;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerClassLibrary.WebForms.Tests
{
    public class CustomerEditTests
    {
        [Fact]
        public void ShouldBeAbleToCreateCustomerEdit()
        {
            var customerEdit = new CustomerEdit();        
        }

        [Fact]
        public void ShouldBeAbleToEditCustomer()
        {
            var customerMockRepository = new Mock<IEntityRepository<Customer>>();
            var addressMockRepository = new Mock<IEntityRepository<Address>>();
            var noteMockRepository = new Mock<IEntityRepository<CustomerNote>>();

            //var customerFixture = new CustomerRepositoryFixture();
            //var addressFixture = new CustomerAddressFixture();
            //var note = new CustomerNote()
            //{
            //    Note = "Kitty Ipsum"
            //};

            //var customer = customerFixture.MockCustomer();
            //var address = addressFixture.MockAddress();

            //customer.AddAddress(address);

            var customerService = new CustomerService(customerMockRepository.Object, addressMockRepository.Object, noteMockRepository.Object);

            var customerEdit = new CustomerEdit(customerService);
            //customerEdit.OnSaveClick(this, EventArgs.Empty);

            //customerMockRepository.Verify(x => x.Update(It.IsAny<Customer>()));
            //addressMockRepository.Verify(x => x.Update(It.IsAny<Address>()));
        }
    }
}
