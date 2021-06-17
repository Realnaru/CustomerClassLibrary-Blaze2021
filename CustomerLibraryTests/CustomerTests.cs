using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerClassLibrary;
using CustomerClassLibrary.Data.Common;
using Xunit;

namespace CustomerLibraryTests
{
    public class CustomerTests
    {
        [Fact]
        public void ShouldCreateCustomer()
        {
            Customer customer = new Customer();
            Assert.Equal(0, customer.CustomerId);
            Assert.Null(customer.FirstName);
            Assert.Null(customer.LastName);
            Assert.NotNull(customer.AdressesList);
            Assert.Null(customer.PhoneNumber);
            Assert.Null(customer.Email);
            Assert.NotNull(customer.Note);
            Assert.Null(customer.TotalPurshasesAmount);

        }

        [Fact]
        public void ShouldSetProperties()
        {
            Customer customer = new Customer();

            var adress = new List<Address>();

            customer.CustomerId = 1;
            customer.FirstName = "Harry";
            customer.LastName = "Potter";
            customer.PhoneNumber = "(605) 475-6961";
            customer.Email = "hogwards@mail.com";
            customer.AdressesList = adress;
            customer.TotalPurshasesAmount = 303000;

            Assert.Equal(1, customer.CustomerId);
            Assert.Equal("Harry", customer.FirstName);
            Assert.Equal("Potter", customer.LastName);
            Assert.Equal("(605) 475-6961", customer.PhoneNumber);
            Assert.Equal("hogwards@mail.com", customer.Email);
            Assert.Equal("hogwards@mail.com", customer.Email);
            Assert.Equal(adress, customer.AdressesList);
            Assert.Equal(303000, customer.TotalPurshasesAmount);

            Customer customer1 = new Customer();
            customer1.TotalPurshasesAmount = null;
            Assert.Null(customer1.TotalPurshasesAmount);

        }

        [Fact]
        public void ShouldBeAbleToAddAddress()
        {
            Customer customer = new Customer();
            Address address = new Address();

            customer.AddAddress(address);

            Assert.Equal(address, customer.AdressesList[0]);
        }

        [Fact]
        public void ShouldNotBeAbleToAddAddressWithWrongId()
        {
            Customer customer = new Customer();
            Address address = new Address();

            customer.CustomerId = 1;
            address.AddressId = 2;

            Assert.Throws<WrongIdException>(() => customer.AddAddress(address));

            
        }

        [Fact]
        public void ShouldBeAbleToAddNote()
        {
            Customer customer = new Customer();
            CustomerNote note = new CustomerNote();

            customer.AddNote(note);

            Assert.Equal(note, customer.Note[0]);
        }

        [Fact]
        public void ShouldNoBeAbleToAddNoteWithWrongId()
        {
            Customer customer = new Customer();
            customer.CustomerId = 1;
            CustomerNote note = new CustomerNote();
            note.CustomerId = 2;

            Assert.Throws<WrongIdException>(() => customer.AddNote(note));
        }
    }

}
