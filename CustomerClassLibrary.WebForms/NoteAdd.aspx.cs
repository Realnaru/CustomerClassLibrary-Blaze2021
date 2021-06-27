using CustomerClassLibrary.Data.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerClassLibrary.WebForms
{
    public partial class NoteAdd : System.Web.UI.Page
    {
        private NoteService _noteService;
        public int CustomerId { get; set; }

        public NoteAdd()
        {
            _noteService = new NoteService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int customerIdReq;
            int.TryParse(Request.QueryString["customerId"], out customerIdReq);
            if (customerIdReq != 0)
            {
                CustomerId = customerIdReq;
            }
        }

        public void OnAddClick(object sender, EventArgs e)
        {
            var noteToCreate = new CustomerNote()
            {
                CustomerId = this.CustomerId,
                Note = noteText?.Text
            };

            _noteService.CreateNote(noteToCreate);

            Response?.Redirect($"CustomerEdit?customerId={CustomerId}");
        }
    }
}