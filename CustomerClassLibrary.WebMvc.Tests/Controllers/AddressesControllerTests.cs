using CustomerClassLibrary.Common;
using CustomerClassLibrary.Data.Business;
using CustomerClassLibrary.WebMvc.Controllers;
using CustomerLibrary.IntegrationTests.IntegrationTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CustomerClassLibrary.WebMvc.Tests.Controllers
{
    [TestClass]
    public class AddressesControllerTests
    {
        [TestMethod]
        public void ShouldBeAbleToCreateAddressesController()
        {
            var addressesController = new AddressesController();
        }


        [TestMethod]
        public void ShouldBeAbleToShowListOfAddresses()
        {
            var mockAddressService = new Mock<IAddressService>();
            var addressFixture = new CustomerAddressFixture();
            var address = addressFixture.MockAddress();

            List<Address> addresses = new List<Address>();
            addresses.Add(address);

            mockAddressService.Setup(x => x.GetAllAddresses(1)).Returns(addresses);

            var controller = new AddressesController(mockAddressService.Object);

            var result = controller.Index(1) as ViewResult;

            Assert.IsNotNull(result); 
        }

        [TestMethod]
        public void ShouldBeAbleToShowDetails()
        {
            var mockAddressService = new Mock<IAddressService>();
            var addressFixture = new CustomerAddressFixture();
            var address = addressFixture.MockAddress();

            mockAddressService.Setup(x => x.GetAddress(1)).Returns(address);

            var controller = new AddressesController(mockAddressService.Object);

            var result = controller.Details(1) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldBeAbleToShowViewForCreateAddress()
        {
            var mockAddressService = new Mock<IAddressService>();
            var addressFixture = new CustomerAddressFixture();
            var address = new Address();
            address.CustomerId = 1;

            var controller = new AddressesController(mockAddressService.Object);
            var result = controller.Create(address.CustomerId) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldBeAbleToCreateAddress()
        {
            var mockAddressService = new Mock<IAddressService>();
            var addressFixture = new CustomerAddressFixture();
            var address = addressFixture.MockAddress();

            var controller = new AddressesController(mockAddressService.Object);

            var result = controller.Create(1, address) as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldNotBeAbleToCreateWrongAddress()
        {
            var mockAddressService = new Mock<IAddressService>();
            var addressFixture = new CustomerAddressFixture();
            var address = new Address();

            mockAddressService.Setup(x => x.CreateAddress(address)).Throws(new WrongDataException("Message"));

            var controller = new AddressesController(mockAddressService.Object);

            var result = controller.Create(1, address) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldShowViewForEditAddress()
        {
            var mockAddressService = new Mock<IAddressService>();
            var addressFixture = new CustomerAddressFixture();
            var address = addressFixture.MockAddress();
            address.AddressId = 1;

            var controller = new AddressesController(mockAddressService.Object);

            var result = controller.Edit(1) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldBeAbleToEditAddress()
        {
            var mockAddressService = new Mock<IAddressService>();

            var addressFixture = new CustomerAddressFixture();
            var address = addressFixture.MockAddress();
            address.CustomerId = 1;

            mockAddressService.Setup(x => x.GetAddress(1)).Returns(new Address() { CustomerId = 1 });

            var controller = new AddressesController(mockAddressService.Object);

            var result = controller.Edit(1, address) as RedirectToRouteResult;

            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void ShouldShowViewForDeleteAddress()
        {
            var mockAddressService = new Mock<IAddressService>();
            var addressFixture = new CustomerAddressFixture();
            var address = addressFixture.MockAddress();
            address.AddressId = 1;

            var controller = new AddressesController(mockAddressService.Object);

            var result = controller.Delete(1) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldBeAbleToDeleteAddress()
        {
            var mockAddressService = new Mock<IAddressService>();
            var addressFixture = new CustomerAddressFixture();
            var address = addressFixture.MockAddress();
            address.AddressId = 1;

            mockAddressService.Setup(x => x.GetAddress(1)).Returns(new Address() { CustomerId = 1 });

            var controller = new AddressesController(mockAddressService.Object);

            Assert.IsNotNull(address);

            var result = controller.Delete(1, address) as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }

    }
}
