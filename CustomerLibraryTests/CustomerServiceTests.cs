using CustomerClassLibrary.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CustomerClassLibrary.Data;
using Moq;
using CustomerClassLibrary;
using CustomerClassLibrary.Data.Repositories;
using CustomerLibraryTests.IntegrationTests;
using CustomerLibrary.IntegrationTests.IntegrationTests;

namespace CustomerLibraryTests.CustomerLibraryTests
{
    public class CustomerServiceTests
    {
        [Fact]
        public void ShouldInitializeCustomerService()
        {
            var customerService = new CustomerService();
        }


        [Fact]
        public void ShouldCreateCustomerAndReturnId()
        {
            var customerFixture = new CustomerRepositoryFixture();
            var addressFixture = new CustomerAddressFixture();

            var customerMock = new Mock<IEntityRepository<Customer>>();
            var addressMock = new Mock<IEntityRepository<Address>>();
            var noteMock = new Mock<IEntityRepository<CustomerNote>>();

            var customerToCreate = customerFixture.MockCustomer();

            var addressToCreate = customerToCreate.AdressesList[0];
            var noteToCreate = customerToCreate.Note[0];

            int expectedId = 1;
            int expectedAddressId = 1;
            int expectedNoteId = 1;

            customerMock.Setup(x => x.Create(customerToCreate)).Returns(() => expectedId);
            addressMock.Setup(x => x.Create(addressToCreate)).Returns(() => expectedAddressId );
            noteMock.Setup(x => x.Create(noteToCreate)).Returns(() => expectedNoteId);

            var customerService = new CustomerService(customerMock.Object, addressMock.Object, noteMock.Object);

            int customerId = customerService.CreateCustomer(customerToCreate);
            int addressCustomerId = customerId;
            int noteCustomerId = customerId;

            Assert.Equal(expectedId, customerId);
            Assert.Equal(expectedAddressId, addressCustomerId);
            Assert.Equal(expectedNoteId, noteCustomerId);
        }

        [Fact]
        public void ShouldGetCustomerById()
        {
            var customerFixture = new CustomerRepositoryFixture();
            var addressFixture = new CustomerAddressFixture();

            var customerMock = new Mock<IEntityRepository<Customer>>();
            var addressMock = new Mock<IEntityRepository<Address>>();
            var noteMock = new Mock<IEntityRepository<CustomerNote>>();

            var customerExpected = customerFixture.MockCustomer();
            var addressExpected = addressFixture.MockAddress();
            var noteExpected = new CustomerNote();

            List<Address> expectedAddresses = new List<Address>();
            expectedAddresses.Add(addressExpected);

            List<CustomerNote> expectedNotes = new List<CustomerNote>();
            expectedNotes.Add(noteExpected);

            customerMock.Setup(x => x.Read(1)).Returns(() => customerExpected);
            addressMock.Setup(x => x.ReadAll(1)).Returns(expectedAddresses);
            noteMock.Setup(x => x.ReadAll(1)).Returns(expectedNotes);

            var customerService = new CustomerService(customerMock.Object, addressMock.Object, noteMock.Object);

            var customer = customerService.GetCustomer(1);
            var address = customer.AdressesList[0];
            var note = customer.Note[0];

            Assert.Equal(customerExpected, customer);
            Assert.Equal(addressExpected, address);
            Assert.Equal(noteExpected, note);
        }

        [Fact]
        public void ShouldGetAllCustomers()
        {
            var customerFixture = new CustomerRepositoryFixture();
            var addressFixture = new CustomerAddressFixture();

            var customerMock = new Mock<IEntityRepository<Customer>>();
            var addressMock = new Mock<IEntityRepository<Address>>();
            var noteMock = new Mock<IEntityRepository<CustomerNote>>();

            var customerExpected = customerFixture.MockCustomer();
            var addressExpected = addressFixture.MockAddress();
            var noteExpected = new CustomerNote();

            List<Customer> customers = new List<Customer>();

            List<Address> expectedAddresses = new List<Address>();
            expectedAddresses.Add(addressExpected);

            List<CustomerNote> expectedNotes = new List<CustomerNote>();
            expectedNotes.Add(noteExpected);

            customerMock.Setup(x => x.Read(1)).Returns(() => customerExpected);
            addressMock.Setup(x => x.ReadAll(1)).Returns(expectedAddresses);
            noteMock.Setup(x => x.ReadAll(1)).Returns(expectedNotes);

            var customerService = new CustomerService(customerMock.Object, addressMock.Object, noteMock.Object);

            var customer = customerService.GetCustomer(1);
            var address = customer.AdressesList[0];
            var note = customer.Note[0];

            Assert.Equal(customerExpected, customer);
            Assert.Equal(addressExpected, address);
            Assert.Equal(noteExpected, note);
        }

        [Fact]
        public void ShouldGetCustomersPartially()
        {
            var customerFixture = new CustomerRepositoryFixture();
            var addressFixture = new CustomerAddressFixture();

            var customerMock = new Mock<IEntityRepository<Customer>>();
            var addressMock = new Mock<IEntityRepository<Address>>();
            var noteMock = new Mock<IEntityRepository<CustomerNote>>();

            var firstCustomerExpected = customerFixture.MockCustomer();
            var secondCustomerExpected = customerFixture.MockCustomer();
            var thirdCustomerExpected = customerFixture.MockCustomer();
            var fourthCustomerExpected = customerFixture.MockCustomer();
            var fifthCustomerExpected = customerFixture.MockCustomer();
            //var addressExpected = addressFixture.MockAddress();
            //var noteExpected = new CustomerNote();

            List<Customer> expectedCustomers = new List<Customer>();
            expectedCustomers.Add(firstCustomerExpected);
            expectedCustomers.Add(secondCustomerExpected);
            expectedCustomers.Add(thirdCustomerExpected);
            expectedCustomers.Add(fourthCustomerExpected);
            expectedCustomers.Add(fifthCustomerExpected);

            //List<Address> expectedAddresses = new List<Address>();
            //expectedAddresses.Add(addressExpected);

            //List<CustomerNote> expectedNotes = new List<CustomerNote>();
            //expectedNotes.Add(noteExpected);

            customerMock.Setup(x => x.ReadPartially(0, 5)).Returns(() => expectedCustomers);
            //addressMock.Setup(x => x.ReadAll(1)).Returns(expectedAddresses);
            //noteMock.Setup(x => x.ReadAll(1)).Returns(expectedNotes);

            var customerService = new CustomerService(customerMock.Object, addressMock.Object, noteMock.Object);

            var fetchedCustomers = customerService.GetCustomersPartially(0, 5);

            customerMock.Verify(x => x.ReadPartially(0, 5), Times.Exactly(1));

            Assert.Equal(firstCustomerExpected, expectedCustomers[0]);
            Assert.Equal(secondCustomerExpected, expectedCustomers[1]);
            Assert.Equal(thirdCustomerExpected, expectedCustomers[2]);
            Assert.Equal(fourthCustomerExpected, expectedCustomers[3]);
            Assert.Equal(fifthCustomerExpected, expectedCustomers[4]);

        }


        [Fact]
        public void ShouldUpdateCustomer()
        {
            var customerMock = new Mock<IEntityRepository<Customer>>();
            var addressMock = new Mock<IEntityRepository<Address>>();
            var noteMock = new Mock<IEntityRepository<CustomerNote>>();

            var customerFixture = new CustomerRepositoryFixture();
            var addressFixture = new CustomerAddressFixture();

            var customerToUpdate = customerFixture.MockCustomer();
            customerToUpdate.CustomerId = 1;

            var addressToUpdate = addressFixture.MockAddress();
            addressToUpdate.CustomerId = 1;

            var noteToUdate = new CustomerNote();
            noteToUdate.CustomerId = 1;

            customerToUpdate.AddAddress(addressToUpdate);
            customerToUpdate.AddNote(noteToUdate);


            customerMock.Setup(x => x.Update(customerToUpdate));
            addressMock.Setup(x => x.Update(customerToUpdate.AdressesList[0]));
            noteMock.Setup(x => x.Update(customerToUpdate.Note[0]));

            var customerService = new CustomerService(customerMock.Object, addressMock.Object, noteMock.Object);

            customerService.ChangeCustomer(customerToUpdate);

            customerMock.Verify(x => x.Update(customerToUpdate), Times.Exactly(1));
            addressMock.Verify(x => x.Update(customerToUpdate.AdressesList[0]), Times.Exactly(1));
            noteMock.Verify(x => x.Update(customerToUpdate.Note[0]), Times.Exactly(1));
        }

        [Fact]
        public void ShouldDeleteCustomer()
        {
            var customerMock = new Mock<IEntityRepository<Customer>>();
            var addressMock = new Mock<IEntityRepository<Address>>();
            var noteMock = new Mock<IEntityRepository<CustomerNote>>();

            var customerFixture = new CustomerRepositoryFixture();
            var addressFixture = new CustomerAddressFixture();

            var customerToDelete = customerFixture.MockCustomer();
            //var addressToDelete = addressFixture.MockAddress();
            //var noteToDelete = new CustomerNote();

            //customerToDelete.AddAddress(addressToDelete);
            //customerToDelete.AddNote(noteToDelete);

            customerMock.Setup(x => x.Delete(customerToDelete));
            //addressMock.Setup(x => x.Delete(customerToDelete.AdressesList[0]));
            //noteMock.Setup(x => x.Delete(customerToDelete.Note[0]));

            var customerService = new CustomerService(customerMock.Object, addressMock.Object, noteMock.Object);

            customerService.DeleteCustomer(customerToDelete);

            customerMock.Verify(x => x.Delete(customerToDelete), Times.Exactly(1));
            //addressMock.Verify(x => x.Delete(addressToDelete), Times.Exactly(1));
            //noteMock.Verify(x => x.Delete(noteToDelete), Times.Exactly(1));
        }

        [Fact]
        public void ShouldBeAbleToGetAllCustomers()
        {
            var customerMock = new Mock<IEntityRepository<Customer>>();
            var addressMock = new Mock<IEntityRepository<Address>>();
            var noteMock = new Mock<IEntityRepository<CustomerNote>>();

            customerMock.Setup(x => x.GetAmountOfRows()).Returns(() => 1);

            var customerService = new CustomerService(customerMock.Object, addressMock.Object, noteMock.Object);

            int amountOfCustomers = customerService.GetAmountOfCustomers();

            customerMock.Verify(x => x.GetAmountOfRows(), Times.Exactly(1));
            Assert.Equal(1, amountOfCustomers);
        }

    }
}

