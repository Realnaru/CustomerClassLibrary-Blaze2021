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
        public void ShouldBeAbleToCreateNote()
        {
            var noteMock = new Mock<IEntityRepository<CustomerNote>>();

            var noteToCreate = new CustomerNote() { Note = "Kitty Ipsum", NoteId = 1, CustomerId = 1 };

            int expectedId = 1;
            int noteId;


            noteMock.Setup(x => x.Create(noteToCreate)).Returns(expectedId);

            var noteService = new NoteService(noteMock.Object);

            noteId = noteService.CreateNote(noteToCreate);

            noteMock.Verify(x => x.Create(noteToCreate), Times.Exactly(1));
            Assert.Equal(expectedId, noteId);
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

        [Fact]
        public void ShouldBeAbleToGetAllNotes()
        {
            var noteMock = new Mock<IEntityRepository<CustomerNote>>();

            var noteToGet = new CustomerNote() { Note = "Kitty Ipsum", NoteId = 1, CustomerId = 1 };

            List<CustomerNote> notesToReturn = new List<CustomerNote>();
            notesToReturn.Add(noteToGet);

            List<CustomerNote> returnedNotes = new List<CustomerNote>();

            int customerId = 1;


            noteMock.Setup(x => x.ReadAll(customerId)).Returns(notesToReturn);

            var noteService = new NoteService(noteMock.Object);

            returnedNotes =  noteService.GetAllNotes(customerId);

            noteMock.Verify(x => x.ReadAll(customerId), Times.Exactly(1));
            Assert.NotNull(returnedNotes);
        }

        [Fact]
        public void ShouldBeAbleToDeleteNote()
        {
            var noteMock = new Mock<IEntityRepository<CustomerNote>>();

            var noteToDelete = new CustomerNote() { Note = "Kitty Ipsum", NoteId = 1 };

            int noteId = noteToDelete.NoteId;


            noteMock.Setup(x => x.Delete(noteToDelete.NoteId));

            var noteService = new NoteService(noteMock.Object);

            noteService.DeleteNote(noteId);

            noteMock.Verify(x => x.Delete(noteId), Times.Exactly(1));
        }

    }
}
