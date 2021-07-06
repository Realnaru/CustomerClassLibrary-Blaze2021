using CustomerClassLibrary.Data.Business;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xunit;

namespace CustomerClassLibrary.WebForms.Tests
{
    public class NoteGroupEditTests
    {
        [Fact]
        public void ShouldBeAbleToCreateNoteGroupEdit()
        {
            var noteGroupEdit = new NoteGroupEdit();
            Assert.NotNull(noteGroupEdit);
        }

        //[Fact]
        //public void ShouldBeAbleToEditNotes()
        //{
        //    var noteServiceMock = new Mock<INoteService>();

        //    var noteGroupEdit = new NoteGroupEdit(noteServiceMock.Object);

        //    try
        //    {
        //        noteGroupEdit.OnSaveClick(this, EventArgs.Empty);
        //    }
        //    catch (HttpException)
        //    {

        //    }

        //    noteServiceMock.Verify(x => x.ChangeNote(It.IsAny<CustomerNote>()));  
        //}
    }
}
