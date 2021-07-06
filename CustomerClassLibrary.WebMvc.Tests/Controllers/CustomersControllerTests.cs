using CustomerClassLibrary.Common;
using CustomerClassLibrary.Data.Business;
using CustomerClassLibrary.WebMvc.Controllers;
using CustomerLibraryTests.IntegrationTests;
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
            var customerServiceMock = new Mock<ICustomerService>();
            CustomersController controller = new CustomersController(customerServiceMock.Object);

            var customer = new Customer();

            customerServiceMock.Setup(x => x.GetCustomersPartially(0, 5)).Returns(new List<Customer>() { customer });
            var result = controller.Index(0) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldReturnViewForDetails()
        {
            var customerServiceMock = new Mock<ICustomerService>();
            var controller = new CustomersController(customerServiceMock.Object);

            var customerFixture = new CustomerRepositoryFixture();
            var customer = customerFixture.MockCustomer();
            customer.CustomerId = 1;

            customerServiceMock.Setup(x => x.GetCustomer(1)).Returns(customer);

            var result = controller.Details(1) as ViewResult;

            customerServiceMock.Verify(x => x.GetCustomer(1), Times.Exactly(1));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldReturnViewToCreateCustomer()
        {
            var controller = new CustomersController();

            var result = controller.Create() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldCreateCustomer()
        {
            var customerServiceMock = new Mock<ICustomerService>();
            var customerFixture = new CustomerRepositoryFixture();
 
            CustomersController controller = new CustomersController(customerServiceMock.Object);
            
            var customer = customerFixture.MockCustomer();
            
            var result = controller.Create(customer) as RedirectToRouteResult;

            Assert.IsNotNull(result);     
        }

        [TestMethod]
        public void ShouldNotCreateWrongCustomer()
        {
            var customerServiceMock = new Mock<ICustomerService>();
            
            CustomersController controller = new CustomersController(customerServiceMock.Object);

            var customer = new Customer();
            customer.AdressesList.Add(new Address());
            customer.Note.Add(new CustomerNote());
            customerServiceMock.Setup(x => x.CreateCustomer(customer)).Throws(new WrongDataException("Message"));

            var result = controller.Create(customer) as ViewResult;

            customerServiceMock.Verify(x => x.CreateCustomer(customer), Times.Exactly(1));

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldReturnViewToEditCustomer()
        {
            var customerServiceMock = new Mock<ICustomerService>();

            CustomersController controller = new CustomersController(customerServiceMock.Object);

            var customer = new Customer() { CustomerId = 1};

            customerServiceMock.Setup(x => x.GetCustomer(1)).Returns(customer);

            var result = controller.Edit(1) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldBeAbleToEditCustomer()
        {
            var customerServiceMock = new Mock<ICustomerService>();
            var addressServiceMock = new Mock<IAddressService>();
            var noteServiceMock = new Mock<INoteService>();

            var customer = new Customer()
            {
                CustomerId = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "jd@gmail.com",
                PhoneNumber = "123456",
                TotalPurshasesAmount = 100
            };

            var address = new Address()
            {
                CustomerId = 1,
                AddressId = 1,
                AdressLine = "123",
                AdressLine2 = "123",
                AddressTypeEnum = AddressType.Billing,
                PostalCode = "12345",
                State = "Man",
                City = "Anonvill",
                Country = "USA"
            };

            var note = new CustomerNote()
            {
                CustomerId = 1,
                NoteId = 1,
                Note = "Kitty ipsum"
            };

            var addresses = new List<Address>();
            addresses.Add(address);

            var notes = new List<CustomerNote>();
            notes.Add(note);

            addressServiceMock.Setup(x => x.GetAllAddresses(customer.CustomerId)).Returns(addresses);

            noteServiceMock.Setup(x => x.GetAllNotes(customer.CustomerId)).Returns(notes);

            CustomersController controller = new CustomersController(customerServiceMock.Object, 
                                                                     addressServiceMock.Object,
                                                                     noteServiceMock.Object);

            var result = controller.Edit(customer) as RedirectToRouteResult;

            customerServiceMock.Verify(x => x.ChangeCustomer(customer), Times.Exactly(1));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldBeAbleToReturnViewForDelete()
        {
            var customerServiceMock = new Mock<ICustomerService>();
            var controller = new CustomersController(customerServiceMock.Object);

            var customer = new Customer() { CustomerId = 1 };
            customerServiceMock.Setup(x => x.GetCustomer(1)).Returns(customer);

            var result = controller.Delete(1) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var customerServiceMock = new Mock<ICustomerService>();
            var addressServiceMock = new Mock<IAddressService>();
            var noteServiceMock = new Mock<INoteService>();

            var controller = new CustomersController(customerServiceMock.Object, addressServiceMock.Object, noteServiceMock.Object);

            var customer = new Customer()
            {
                CustomerId = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "jd@gmail.com",
                PhoneNumber = "123456",
                TotalPurshasesAmount = 100
            };

            var address = new Address()
            {
                CustomerId = 1,
                AddressId = 1,
                AdressLine = "123",
                AdressLine2 = "123",
                AddressTypeEnum = AddressType.Billing,
                PostalCode = "12345",
                State = "Man",
                City = "Anonvill",
                Country = "USA"
            };

            var note = new CustomerNote()
            {
                CustomerId = 1,
                NoteId = 1,
                Note = "Kitty ipsum"
            };

            var addresses = new List<Address>();
            addresses.Add(address);

            var notes = new List<CustomerNote>();
            notes.Add(note);

            addressServiceMock.Setup(x => x.GetAllAddresses(customer.CustomerId)).Returns(addresses);

            noteServiceMock.Setup(x => x.GetAllNotes(customer.CustomerId)).Returns(notes);

            var result = controller.Delete(1, customer) as RedirectToRouteResult;

            customerServiceMock.Verify(x => x.DeleteCustomer(customer), Times.Exactly(1));

            Assert.IsNotNull(result);
        }
    }

}
