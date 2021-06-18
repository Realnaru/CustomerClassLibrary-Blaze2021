using CustomerClassLibrary;
using CustomerClassLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerLibraryTests.IntegrationTests
{
    public class CustomerNoteRepositoryTests
    {
        [Fact]
        public void ShouldbeAbleToCreateNoteRepository()
        {
            var customerNoteRepository = new CustomerNoteRepository();

            Assert.NotNull(customerNoteRepository);
        }

        [Fact]
        public void ShouldbeAbleToCreateCustomerNote()
        {
            var customerNoteRepository = new CustomerNoteRepository();
            var customerRepository = new CustomerRepository();

            customerRepository.DeleteAll();

            var customerNote = new CustomerNote();
            var fixture = new CustomerRepositoryFixture();
            var customer = fixture.MockCustomer();
            int customerId = customerRepository.Create(customer);

            customerNote.CustomerId = customerId;
            customerNote.Note = "Kitty ipsum dolor sit amet, shed everywhere shed everywhere";

            int customerNoteId = customerNoteRepository.Create(customerNote);
            Assert.NotEqual(0, customerNoteId);
          
        }

        [Fact]
        public void ShouldbeAbleToReadCustomerNote()
        {
            var customerNoteRepository = new CustomerNoteRepository();
            var customerRepository = new CustomerRepository();
            var fixture = new CustomerRepositoryFixture();

            customerRepository.DeleteAll();

            var customerNote = new CustomerNote();
            
            var customer = fixture.MockCustomer();
            int customerId = customerRepository.Create(customer);

            customerNote.CustomerId = customerId;
            customerNote.Note = "Kitty ipsum dolor sit amet, shed everywhere shed everywhere";

            customerNoteRepository.Create(customerNote);

            var createdNote = customerNoteRepository.Read(customerNote.CustomerId);

            Assert.NotNull(createdNote);
            Assert.Equal(customerId, createdNote.CustomerId);
            Assert.Equal("Kitty ipsum dolor sit amet, shed everywhere shed everywhere", createdNote.Note);
        }

        [Fact]
        public void ShouldbeAbleToUpdateCustomerNote()
        {
            var customerNoteRepository = new CustomerNoteRepository();
            var customerRepository = new CustomerRepository();
            var fixture = new CustomerRepositoryFixture();

            customerRepository.DeleteAll();

            var customerNote = new CustomerNote();

            var customer = fixture.MockCustomer();
            int customerId = customerRepository.Create(customer);

            customerNote.CustomerId = customerId;
            customerNote.Note = "Kitty ipsum dolor sit amet, shed everywhere shed everywhere";

            customerNoteRepository.Create(customerNote);

            customerNote.Note = "Purr jum eat the grass rip the couch scratched sumbathe, shed everywhere rip the couch sleep in the sink fluffy fur canip scratched";
            customerNoteRepository.Update(customerNote);

            var createdNote = customerNoteRepository.Read(customerNote.CustomerId);

            Assert.NotNull(createdNote);
            Assert.Equal(customerId, createdNote.CustomerId);
            Assert.Equal("Purr jum eat the grass rip the couch scratched sumbathe, shed everywhere rip the couch sleep in the sink fluffy fur canip scratched", createdNote.Note);
        }

        [Fact]
        public void ShouldbeAbleToDeleteCustomerNote()
        {
            var customerNoteRepository = new CustomerNoteRepository();
            var customerRepository = new CustomerRepository();
            var fixture = new CustomerRepositoryFixture();

            customerRepository.DeleteAll();

            var customerNote = new CustomerNote();

            var customer = fixture.MockCustomer();
            int customerId = customerRepository.Create(customer);

            customerNote.CustomerId = customerId;
            customerNote.Note = "Kitty ipsum dolor sit amet, shed everywhere shed everywhere";

            customerNoteRepository.Create(customerNote);

            customerNoteRepository.Delete(customerId);

            var deletedNote = customerNoteRepository.Read(customerNote.CustomerId);

            Assert.Null(deletedNote);
        }
    }
}
