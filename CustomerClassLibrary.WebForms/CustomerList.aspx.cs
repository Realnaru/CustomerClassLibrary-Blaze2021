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

        public CustomerList()
        {
            _customerService = new CustomerService();
        }

        public CustomerList(ICustomerService customerService)
        {
            _customerService = customerService;
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
            Customers = _customerService.GetCustomersPartially(SheetCount, 5).ToList<Customer>();
            nextButton.Enabled = SheetCount < AmountOfCustomers / 5 ? true : false;
            prevButton.Enabled = SheetCount > 0 ? true : false;
        }
        
        public void OnNextClick(object sender, EventArgs e)
        {
            
            if (SheetCount < AmountOfCustomers / 5)
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