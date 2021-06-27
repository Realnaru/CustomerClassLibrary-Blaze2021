﻿using CustomerClassLibrary.Data.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerClassLibrary.WebForms
{
    public partial class NoteEdit : System.Web.UI.Page
    {
        private NoteService _noteService;

        public int NoteId { get; set; }

        public int CustomerId { get; set; }
        public NoteEdit()
        {
            _noteService = new NoteService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            int noteIdReq;
            int.TryParse(Request.QueryString["noteId"], out noteIdReq);
            NoteId = noteIdReq;
            

            if (!IsPostBack)
            {
                LoadNote(noteIdReq);
            }

        }

        public void LoadNote(int noteId)
        {
            var note = _noteService.GetNote(noteId);

            noteText.Text = note.Note;
        }

        public void OnSaveClick(object sender, EventArgs e)
        {
            var note = new CustomerNote();

            note.NoteId = NoteId;
            note.Note = noteText?.Text;

            _noteService.ChangeNote(note);

        }
    }
}