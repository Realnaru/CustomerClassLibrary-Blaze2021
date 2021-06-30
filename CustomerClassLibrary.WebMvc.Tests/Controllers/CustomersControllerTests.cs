using CustomerClassLibrary.Data.Business;
using CustomerClassLibrary.WebMvc.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary.WebMvc.Tests.Controllers
{
    [TestClass]
    public class CustomersControllerTests
    {
        [TestMethod]
        public void ShouldCreateCustomersController()
        {
            CustomersController controller = new CustomersController();
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void ShouldReturnListOfCustomers()
        {
            CustomersController controller = new CustomersController();
            controller.Index(); 
        }

        [TestMethod]
        public void ShouldCreateCustomer()
        {
            var customerServiceMock = new Mock<ICustomerService>();
            CustomersController controller = new CustomersController();
            var customer = new Customer();
            controller.Index();
        }
    }
}
