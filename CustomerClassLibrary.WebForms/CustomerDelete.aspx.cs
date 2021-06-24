using CustomerClassLibrary.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerClassLibrary.WebForms
{
    public partial class CustomerDelete : System.Web.UI.Page
    {
        private CustomerService _customerService;

        public CustomerDelete()
        {
            _customerService = new CustomerService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int customerIdReq;
                int.TryParse(Request.QueryString["customerId"], out customerIdReq);
                DeleteCustomer(customerIdReq);
            }
        }

        public void DeleteCustomer(int customerId)
        {
            if (customerId != 0)
            {
                var customer = _customerService.GetCustomer(customerId);
                _customerService.DeleteCustomer(customer);   

            }
            Response?.Redirect("CustomerList");
        }
    }
}