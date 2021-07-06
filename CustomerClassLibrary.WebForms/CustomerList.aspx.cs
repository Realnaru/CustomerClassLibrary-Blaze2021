using CustomerClassLibrary.Business;
using CustomerClassLibrary.Data.Business;
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
        private ICustomerService _customerService;
        public List<Customer> Customers { get; set; }
        public int AmountOfCustomers { get; set; }

        public int SheetCount { get; set; } = 0;
        public int CustomersPerPage { get; set; } = 5;

        public CustomerList()
        {
            _customerService = new CustomerService();
        }

        public CustomerList(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            nextButton.Enabled = SheetCount < AmountOfCustomers / CustomersPerPage ? true : false;
            prevButton.Enabled = SheetCount > 0 ? true : false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAmountOfCustomers();
            LoadCustomers();
        }

        public void GetAmountOfCustomers()
        {
            AmountOfCustomers = _customerService.GetAmountOfCustomers();
        }

        public void LoadCustomers()
        {
            Customers = _customerService.GetCustomersPartially(SheetCount, CustomersPerPage).ToList<Customer>();
            
        }
        
        public void OnNextClick(object sender, EventArgs e)
        {
            
            if (SheetCount < AmountOfCustomers / CustomersPerPage)
            {
                SheetCount++;
                LoadCustomers();    
            } 
        }

        public void OnPrevClick(object sender, EventArgs e)
        {
            if (SheetCount > 0)
            {
                SheetCount--;
                LoadCustomers();
            } 
        }
    }
}