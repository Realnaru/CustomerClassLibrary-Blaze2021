using CustomerClassLibrary.Data.Business;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerClassLibrary.WebForms.Tests
{
    public class NoteAddTests
    {
        [Fact]
        public void ShouldBeAbleToCreateNoteAdd()
        {
            var noteAdd = new NoteAdd();
            Assert.NotNull(noteAdd);
        }

        [Fact]
        public void ShouldBeAbleToAddNote()
        {
            var mockNoteService = new Mock<INoteService>();
            var noteAdd = new NoteAdd(mockNoteService.Object);
            try
            {
                noteAdd.OnAddClick(this, EventArgs.Empty);
            }
            catch (System.Web.HttpException)
            {

            }
            
            mockNoteService.Verify(x => x.CreateNote(It.IsAny<CustomerNote>()));
        }
    }
}
