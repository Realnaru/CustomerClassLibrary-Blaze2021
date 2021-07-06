using CustomerClassLibrary.Business;
using CustomerClassLibrary.Data.Business;
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
        public void ShouldBeAbleToGetAddresses()
        {
            var customerServiceMock = new Mock<ICustomerService>();
            var addressServiceMock = new Mock<IAddressService>();
            var noteServiceMock = new Mock<INoteService>();

            var customerRepositoryFixture = new CustomerRepositoryFixture();

            var customer = customerRepositoryFixture.MockCustomer();

            customerServiceMock.Setup(x => x.GetCustomer(1)).Returns(customer);
            addressServiceMock.Setup(x => x.GetAllAddresses(1)).Returns(customer.AdressesList);
            
            var customerEdit = new CustomerEdit(customerServiceMock.Object, addressServiceMock.Object, noteServiceMock.Object);
            List<Address> addresses = customerEdit.GetAddresses(1);

            addressServiceMock.Verify(x => x.GetAllAddresses(1), Times.Exactly(1));
            Assert.Collection(addresses, item => Assert.Equal(customer.AdressesList[0], item));
        }

        [Fact]
        public void ShouldBeAbleToGetNotes()
        {
            var customerServiceMock = new Mock<ICustomerService>();
            var addressServiceMock = new Mock<IAddressService>();
            var noteServiceMock = new Mock<INoteService>();

            var customerRepositoryFixture = new CustomerRepositoryFixture();

            var customer = customerRepositoryFixture.MockCustomer();

            customerServiceMock.Setup(x => x.GetCustomer(1)).Returns(customer);
            noteServiceMock.Setup(x => x.GetAllNotes(1)).Returns(customer.Note);

            var customerEdit = new CustomerEdit(customerServiceMock.Object, addressServiceMock.Object, noteServiceMock.Object);
            List<CustomerNote> notes = customerEdit.GetNotes(1);

            noteServiceMock.Verify(x => x.GetAllNotes(1), Times.Exactly(1));
            Assert.Collection(notes, item => Assert.Equal(customer.Note[0], item));
        }

        [Fact]
        public void ShouldBeAbleToEditCustomer()
        {
            var customerServiceMock = new Mock<ICustomerService>();
            var addressServiceMock = new Mock<IAddressService>();
            var noteServiceMock = new Mock<INoteService>();

            var customerEdit = new CustomerEdit(customerServiceMock.Object, addressServiceMock.Object, noteServiceMock.Object);

            try
            {
                customerEdit.OnSaveClick(this, EventArgs.Empty);
            }
            catch (System.Web.HttpException)
            {

            }

            customerServiceMock.Verify(x => x.ChangeCustomer(It.IsAny<Customer>()));
        }
    }
}
