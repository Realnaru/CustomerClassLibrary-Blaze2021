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

        public CustomerEdit()
        {
            _customerService = new CustomerService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
    
                int customerIdReq;
                int.TryParse(Request.QueryString["customerId"], out customerIdReq);
                LoadCustomer(customerIdReq);
            }
        }

        public void LoadCustomer(int customerId)
        {
            if (customerId != 0)
            {
                var customer = _customerService.GetCustomer(customerId);

                var customerNote = customer.Note[0];
                var address = customer.AdressesList[0];

                id.Text = customer.CustomerId.ToString();
                firstName.Text = customer.FirstName;
                lastName.Text = customer.LastName;
                phoneNumber.Text = customer.PhoneNumber;
                email.Text = customer.Email;
                purchaseAmount.Text = customer.TotalPurshasesAmount.ToString();

                note.Text = customerNote.Note;

               
                addressLine.Text = address.AdressLine;
                addressLine2.Text = address.AdressLine2;
                addressType.Text = address.AddressType.ToString();
                city.Text = address.City;
                postalcode.Text = address.PostalCode;
                state.Text = address.State;
                country.Text = address.Country;

                addressRepeater.DataSource = customer.AdressesList;
                addressRepeater.DataBind();
            }
           
        }

        public void OnSaveClick(object sender, EventArgs e)
        {
            var customer = new Customer();
            var address = new Address();
            var customerNote = new CustomerNote();
            
            customer.CustomerId = Convert.ToInt32(id.Text);
            customer.FirstName = firstName.Text;
            customer.LastName = lastName.Text;
            customer.PhoneNumber = phoneNumber.Text;
            customer.Email = email.Text;
            customer.TotalPurshasesAmount = Convert.ToDecimal(purchaseAmount.Text);

            customerNote.CustomerId = Convert.ToInt32(id.Text);
            customerNote.Note = note.Text;

            address.CustomerId = Convert.ToInt32(id.Text);
            address.AdressLine = addressLine.Text;
            address.AdressLine2 = addressLine2.Text;
            address.AddressType = (AddressType)Enum.Parse(typeof(AddressType), addressType?.Text, true);
            address.City = city.Text;
            address.PostalCode = postalcode.Text;
            address.State = state.Text;
            address.Country = country.Text;

            customer.AddAddress(address);
            customer.AddNote(customerNote);

            _customerService.ChangeCustomer(customer);

            Response?.Redirect("CustomerList");
        }
    }
}