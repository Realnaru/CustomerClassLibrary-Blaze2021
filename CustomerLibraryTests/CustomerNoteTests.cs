using CustomerClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace CustomerLibraryTests
{
    public class CustomerNoteTests
    {
        [Fact]
        public void ShouldBeAbleToCreateNote()
        {
            CustomerNote note = new CustomerNote();
            Assert.NotNull(note);
        }

        [Fact]
        public void ShouldBeAbleToGetAndSetProperties()
        {
            CustomerNote note = new CustomerNote();

            note.NoteId = 1;
            note.CustomerId = 1;
            note.Note = "Lorem ipsum sit ameth";

            Assert.Equal(1, note.NoteId);
            Assert.Equal(1, note.CustomerId);
            Assert.Equal("Lorem ipsum sit ameth", note.Note);
        }
    }
}
