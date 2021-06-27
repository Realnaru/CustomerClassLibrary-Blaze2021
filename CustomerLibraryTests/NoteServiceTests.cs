using CustomerClassLibrary;
using CustomerClassLibrary.Data.Business;
using CustomerClassLibrary.Data.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerLibraryTests
{
    public class NoteServiceTests
    {
        [Fact]
        public void ShouldBeAbleToCreateNoteService()
        {
            var noteService = new NoteService();
        }

        [Fact]
        public void ShouldBeAbleToGetNote()
        {
            var noteMock = new Mock<IEntityRepository<CustomerNote>>();
            
            var noteToGet = new CustomerNote() { Note = "Kitty Ipsum", NoteId = 1 };

            int noteId = 1;

            noteMock.Setup(x => x.Read(1)).Returns(noteToGet);

            var noteService = new NoteService(noteMock.Object);

            var note = noteService.GetNote(noteId);

            Assert.Equal(noteToGet, note);
        }


        [Fact]
        public void ShouldBeAbleToChangeNote()
        {
            var noteMock = new Mock<IEntityRepository<CustomerNote>>();

            var noteToUpdate = new CustomerNote() { Note = "Kitty Ipsum", NoteId = 1 };
            

            noteMock.Setup(x => x.Update(noteToUpdate));

            var noteService = new NoteService(noteMock.Object);

            noteService.ChangeNote(noteToUpdate);

            noteMock.Verify(x => x.Update(noteToUpdate), Times.Exactly(1));
        }


    }
}
