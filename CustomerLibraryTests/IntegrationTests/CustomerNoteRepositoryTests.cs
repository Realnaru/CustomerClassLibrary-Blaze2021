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
            var customerNote = new CustomerNote();

            
            customerNote.CustomerId = 2;
            customerNote.Note = "Kitty ipsum dolor sit amet, shed everywhere shed everywhere stretching attack your ankles chase the red dot, hairball run catnip eat the grass sniff";

            customerNoteRepository.Create(customerNote);
        }
    }
}
