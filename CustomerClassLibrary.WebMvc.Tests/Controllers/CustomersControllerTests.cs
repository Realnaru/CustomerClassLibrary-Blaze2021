using CustomerClassLibrary.WebMvc.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
