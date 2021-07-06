using CustomerClassLibrary.Common;
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
    public class CustomerAddTests
    {
        [Fact]
        public void ShouldbeAbleToCreateAddCustomer()
        {
            var addCustomer = new AddCustomer();
        }

        //[Fact]
        //public void ShouldBeAbleToAddCustomer()
        //{
        //    var customerServiceMock = new Mock<ICustomerService>();

        //    var customerFixture = new CustomerRepositoryFixture();

        //    var customer = customerFixture.MockCustomer();

        //    var addCustomer = new AddCustomer(customerServiceMock.Object);

        //    try
        //    {
        //        addCustomer.OnAddClick(this, EventArgs.Empty);
        //    }
        //    catch (System.Web.HttpException)
        //    {

        //    }

        //    customerServiceMock.Verify(x => x.CreateCustomer(It.IsAny<Customer>()));
        //}
    }
}
