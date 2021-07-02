using CustomerClassLibrary.Data.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerClassLibrary.WebMvc.Controllers
{
    [Route("customers/{customerId}/[controller]/[action]/{noteId?}")]
    public class NotesController : Controller
    {
        private INoteService _noteService;

        public NotesController()
        {
            _noteService = new NoteService();
        }
        // GET: Notes
        public ActionResult Index(int customerId)
        {
            var notes = _noteService.GetAllNotes(customerId);

            return View(notes);
        }

        // GET: Notes/Details/5
        public ActionResult Details(int noteId)
        {
            var note = _noteService.GetNote(noteId);
            return View(note);
        }

        // GET: Notes/Create
        public ActionResult Create(int customerId)
        {
            var note = new CustomerNote();
            note.CustomerId = customerId;
            return View(note);
        }

        // POST: Notes/Create
        [HttpPost]
        public ActionResult Create(int customerId, CustomerNote anyNote)
        {
            try
            {
                // TODO: Add insert logic here
                _noteService.CreateNote(anyNote);
                return RedirectToAction("Index", new { customerId = customerId});
            }
            catch
            {
                return View(anyNote);
            }
        }

        // GET: Notes/Edit/5
        public ActionResult Edit(int noteId)
        {
            var note = _noteService.GetNote(noteId);
            return View(note);
        }

        // POST: Notes/Edit/5
        [HttpPost]
        public ActionResult Edit(int customerId, CustomerNote anyNote)
        {
            try
            {
                // TODO: Add update logic here
                _noteService.ChangeNote(anyNote);
                return RedirectToAction("Index", new { customerId = customerId});
            }
            catch
            {
                return View(anyNote);
            }
        }

        // GET: Notes/Delete/5
        public ActionResult Delete(int noteId)
        {
            var note = _noteService.GetNote(noteId);
            return View(note);
        }

        // POST: Notes/Delete/5
        [HttpPost]
        public ActionResult Delete(int noteId, CustomerNote anyNote)
        {
            int customerId = _noteService.GetNote(noteId).CustomerId;
            try
            {
                // TODO: Add delete logic here
                _noteService.DeleteNote(noteId);
                return RedirectToAction("Index", new { customerId = customerId});
            }
            catch
            {
                return View();
            }
        }
    }
}
