using CustomerClassLibrary.Data.Business;
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
    public class CustomerDeleteTests
    {
        [Fact]
        public void ShouldBeAbleToCreateCustomerDelete()
        {
            var customerDelete = new CustomerDelete();
        }
        
        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var customerServiceMock = new Mock<ICustomerService>();
            var customerRepositoryFixture = new CustomerRepositoryFixture();

            var customer = customerRepositoryFixture.MockCustomer();
            customerServiceMock.Setup(x => x.GetCustomer(1)).Returns(customer);
            customerServiceMock.Setup(x => x.DeleteCustomer(customer));

            var customerDelete = new CustomerDelete(customerServiceMock.Object);
            try
            {
                customerDelete.DeleteCustomer(1);
            }
            catch (System.Web.HttpException){

            }

            customerServiceMock.Verify(x => x.DeleteCustomer(customer), Times.Exactly(1));
            
        }
    }
}
