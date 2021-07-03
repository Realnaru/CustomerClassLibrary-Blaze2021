using CustomerClassLibrary.Common;
using CustomerClassLibrary.Data.Business;
using CustomerClassLibrary.WebMvc.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CustomerClassLibrary.WebMvc.Tests.Controllers
{
    [TestClass]
    public class NotesControllerTests
    {
        [TestMethod]
        public void ShouldBeAbleToCreateNotesController()
        {
            var controller = new NotesController();
        }

        [TestMethod]
        public void ShouldBeAbleToShowAllNotes()
        {
            var mockNotesService = new Mock<INoteService>();
            var controller = new NotesController(mockNotesService.Object);

            var note = new CustomerNote()
            {
                CustomerId = 1,
                NoteId = 1,
                Note = "Kitty Ipsum"
            };

            List<CustomerNote> notes = new List<CustomerNote>();
            notes.Add(note);

            mockNotesService.Setup(x => x.GetAllNotes(1)).Returns(notes);

            var result = controller.Index(1) as ViewResult;

            Assert.IsNotNull(result);    
        }

        [TestMethod]
        public void ShouldShowViewForDetails()
        {
            var mockNoteService = new Mock<INoteService>();
            var controller = new NotesController(mockNoteService.Object);

            var note = new CustomerNote()
            {
                CustomerId = 1,
                NoteId = 1,
                Note = "Kitty Ipsum"
            };

            var result = controller.Details(1) as ViewResult;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void ShouldBeAbleToShowViewForCreateNote()
        {
            var mockNoteService = new Mock<INoteService>();
            var controller = new NotesController(mockNoteService.Object);

            var note = new CustomerNote();
            

            var result = controller.Create(1) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldBeAbleToCreateNote()
        {
            var mockNoteService = new Mock<INoteService>();
            var controller = new NotesController(mockNoteService.Object);

            var note = new CustomerNote()
            {
                CustomerId = 1,
                Note = "Kitty Ipsum"
            };

            var result = controller.Create(1, note) as RedirectToRouteResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldBeAbleToShowViewForEdit()
        {
            var mockNoteService = new Mock<INoteService>();
            var controller = new NotesController(mockNoteService.Object);

            var note = new CustomerNote();
            
            var result = controller.Edit(1) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldBeAbleToEditNote()
        {
            var mockNoteService = new Mock<INoteService>();
            var controller = new NotesController(mockNoteService.Object);

            var note = new CustomerNote()
            {
                CustomerId = 1,
                Note = "Kitty Ipsum"
            };

            var result = controller.Edit(1, note) as RedirectToRouteResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldNotBeAbleToCreateWrongNote()
        {
            var mockNoteService = new Mock<INoteService>();
            
            var controller = new NotesController(mockNoteService.Object);

            var note = new CustomerNote();
            mockNoteService.Setup(x => x.CreateNote(note)).Throws(new WrongDataException("Message"));

            var result = controller.Create(1, note) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldBeAbleToShowViewForDelete()
        {
            var mockNoteService = new Mock<INoteService>();
            var controller = new NotesController(mockNoteService.Object);

            var note = new CustomerNote() { NoteId = 1};
           
            var result = controller.Delete(1) as ViewResult;
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void ShouldBeAbleToDeleteNote()
        {
            var mockNoteService = new Mock<INoteService>();
            var controller = new NotesController(mockNoteService.Object);

            mockNoteService.Setup(x => x.GetNote(1)).Returns(new CustomerNote() { CustomerId = 1 });

            var note = new CustomerNote()
            {
                CustomerId = 1,
                NoteId = 1,
                Note = "Kitty Ipsum"
            };

            var result = controller.Delete(1, note) as RedirectToRouteResult;
            Assert.IsNotNull(result);
        }


    }
}
