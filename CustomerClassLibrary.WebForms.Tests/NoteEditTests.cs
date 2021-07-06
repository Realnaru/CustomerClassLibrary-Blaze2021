using CustomerClassLibrary.Data.Business;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Web;

namespace CustomerClassLibrary.WebForms.Tests
{
    public class NoteEditTests
    {
        [Fact]
        public void ShouldBeAbleToLoadNote()
        {
            var noteServiceMock = new Mock<INoteService>();
            var note = new CustomerNote() { CustomerId = 1, Note = "Kitty Ipsum" };
            noteServiceMock.Setup(x => x.GetNote(1)).Returns(note);

            var noteEdit = new NoteEdit(noteServiceMock.Object);
            string noteText = noteEdit.LoadNote(1);

            noteServiceMock.Verify(x => x.GetNote(1), Times.Exactly(1));
            Assert.Equal("Kitty Ipsum", noteText);
        }

        [Fact]
        public void ShouldBeAbleToEditNote()
        {
            var noteServiceMock = new Mock<INoteService>();
            var noteEdit = new NoteEdit(noteServiceMock.Object);

            try
            {
                noteEdit.OnSaveClick(this, EventArgs.Empty);
            }
            catch (HttpException)
            {

            }

            noteServiceMock.Verify(x => x.ChangeNote(It.IsAny<CustomerNote>()));
        }


    }
}
