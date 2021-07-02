﻿using CustomerClassLibrary.Data.Business;
using CustomerClassLibrary.WebMvc.Controllers;
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
            CustomersController controller = new CustomersController();
            controller.Index(0); 
        }

        [TestMethod]
        public void ShouldCreateCustomer()
        {
            var customerServiceMock = new Mock<ICustomerService>();
            var addressServiceMock = new Mock<IAddressService>();
            var notesMock = new Mock<INoteService>();
            CustomersController controller = new CustomersController();

            var customer = new Customer();
            customer.AdressesList = new List<Address>() { new Address() };
            customer.Note = new List<CustomerNote>() { new CustomerNote() };

            var result = controller.Create(customer) as RedirectResult;

            //Assert.IsNotNull(result);
            
        }
    }
}
