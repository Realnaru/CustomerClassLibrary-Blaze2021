using CustomerClassLibrary.Data;
using CustomerClassLibrary.Data.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerClassLibrary.WebForms

{ 
    public partial class NoteDelete : System.Web.UI.Page
    {
        private NoteService _noteService;
        private int CustomerId { get; set; }

        public NoteDelete()
        {
            _noteService = new NoteService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int noteIdReq;
            int.TryParse(Request.QueryString["noteId"], out noteIdReq);
            var note = _noteService.GetNote(noteIdReq);
            CustomerId = note.CustomerId;

            if (noteIdReq != 0)
            {
             
                _noteService.DeleteNote(noteIdReq);

                Response?.Redirect($"CustomerEdit?customerId={CustomerId}");

            }

        }
    }
}