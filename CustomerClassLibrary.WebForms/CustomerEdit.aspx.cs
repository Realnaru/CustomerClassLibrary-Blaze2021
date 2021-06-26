using CustomerClassLibrary.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerClassLibrary.WebForms
{
    public partial class CustomerEdit : System.Web.UI.Page
    {
        private CustomerService _customerService;

        public List<Address> Addresses { get; set; }

        public CustomerEdit()
        {
            _customerService = new CustomerService();
        }

        public CustomerEdit(CustomerService customerService)
        {
            _customerService = customerService;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
                int customerIdReq;
                int.TryParse(Request.QueryString["customerId"], out customerIdReq);
                Addresses = LoadCustomer(customerIdReq);
            }
    
        }

        public List<Address> LoadCustomer(int customerId)
        {
            if (customerId != 0)
            {
                var customer = _customerService.GetCustomer(customerId);

                List<Address> addresses = customer.AdressesList;

                id.Text = customer.CustomerId.ToString();
                firstName.Text = customer.FirstName;
                lastName.Text = customer.LastName;
                phoneNumber.Text = customer.PhoneNumber;
                email.Text = customer.Email;
                purchaseAmount.Text = customer.TotalPurshasesAmount.ToString();

                return addresses;
            }
            return new List<Address>();
        }

        public void OnSaveClick(object sender, EventArgs e)
        {
            decimal totalAmount;
            int customerId;
            AddressType typeOfAddress;

            decimal.TryParse(purchaseAmount?.Text, out totalAmount);
            int.TryParse(id?.Text, out customerId);
            
            var customer = new Customer();
            
            customer.CustomerId = customerId;
            customer.FirstName = firstName?.Text;
            customer.LastName = lastName?.Text;
            customer.PhoneNumber = phoneNumber?.Text;
            customer.Email = email?.Text;
            customer.TotalPurshasesAmount = totalAmount;

            _customerService.ChangeCustomer(customer);

            Response?.Redirect("CustomerList");
        }
    }
}