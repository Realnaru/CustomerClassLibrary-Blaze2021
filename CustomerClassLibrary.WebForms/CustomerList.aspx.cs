using CustomerClassLibrary.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerClassLibrary.WebForms
{
    public partial class CustomerList : System.Web.UI.Page
    {
        private CustomerService _customerService;
        public List<Customer> Customers { get; set; }

        public CustomerList()
        {
            _customerService = new CustomerService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        public void LoadCustomers()
        {
            Customers = _customerService.GetAllCustomers();
        }
        
    }
}