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
    public partial class NoteGroupEdit : System.Web.UI.Page
    {
        private NoteService _noteService;
        private List<CustomerNote> Notes { get; set; } = new List<CustomerNote>();
        private int CustomerId { get; set; }

        public NoteGroupEdit()
        {
            _noteService = new NoteService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int customerIdReq;
            int.TryParse(Request.QueryString["customerId"], out customerIdReq);
            CustomerId = customerIdReq;

            if (!IsPostBack)
            {  
                if (CustomerId != 0)
                {
                    Notes = _noteService.GetAllNotes(CustomerId);
                }

                if (Notes.Count == 0)
                {
                    Notes.Add(new CustomerNote());
                }

                noteRepeater.DataSource = Notes;
                noteRepeater.DataBind();
            }
        }

        public void OnSaveClick(object sender, EventArgs e)
        {
            List<CustomerNote> notes = new List<CustomerNote>();

            int customerId = CustomerId;

            if (noteRepeater.Items.Count != 0)
            {
                foreach (RepeaterItem item in noteRepeater.Items)
                {
                    int noteId;
                    int.TryParse(((HiddenField)item.FindControl("noteId"))?.Value, out noteId);
                    notes.Add(new CustomerNote()
                    {
                        NoteId = noteId,
                        Note = ((TextBox)item.FindControl("note"))?.Text
                    });
                }
            }

            if (notes.Count != 0)
            {
                foreach(var note in notes)
                {
                    _noteService.ChangeNote(note);
                }
            }

            Response.Redirect($"CustomerEdit?customerId={customerId}");    
        }
    }
}