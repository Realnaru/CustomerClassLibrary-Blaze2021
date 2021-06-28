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
        private List<CustomerNote> notes { get; set; } = new List<CustomerNote>();

        public NoteGroupEdit()
        {
            _noteService = new NoteService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int customerIdReq;
            int.TryParse(Request.QueryString["customerId"], out customerIdReq);

            if (customerIdReq != 0)
            {
                notes = _noteService.GetAllNotes(customerIdReq);
            }
            if (notes.Count == 0)
            {
                notes.Add(new CustomerNote());
            }

            NoteRepeater.DataSource = notes;
            NoteRepeater.DataBind();
        }
    }
}