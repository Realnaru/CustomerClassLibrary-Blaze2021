using CustomerClassLibrary.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerClassLibrary.WebForms
{
    public partial class EditCustomer : System.Web.UI.Page
    {
        private CustomerService _customerService;

        public EditCustomer()
        {
            _customerService = new CustomerService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ShowCustomer(int customerId)
        {


        }
    }
}