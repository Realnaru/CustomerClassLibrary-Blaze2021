using CustomerClassLibrary.Business;
using CustomerClassLibrary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerClassLibrary.WebForms
{
    public partial class AddCustomer : System.Web.UI.Page
    {
        private CustomerService _customerService;

        public AddCustomer()
        {
            _customerService = new CustomerService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        public void OnAddClick(object sender, EventArgs e)
        {
           
            var customer = new Customer()
            {
                FirstName = firstName?.Text,
                LastName = lastName?.Text,
                PhoneNumber = phoneNumber.Text,
                Email = email.Text,
                TotalPurshasesAmount = 0,
            };
            

            var address = new Address()
            {
                AdressLine = addressLine?.Text,
                AdressLine2 = addressLine2?.Text,
                AddressType = (AddressType)Enum.Parse(typeof(AddressType), addressType?.Text, true),
                City = city?.Text,
                PostalCode = postalcode?.Text,
                State = state?.Text,
                Country = country?.Text
            };

            var customerNote = new CustomerNote()
            {
                Note = note?.Text
            };

            customer.AddAddress(address);
            customer.AddNote(customerNote);

            try
            {
                _customerService.CreateCustomer(customer);
            }
            catch (WrongDataException err)
            {
                firstName.Text = err.Message;
            }
            finally
            {
                Response?.Redirect("CustomerList");
            }
            

            Response?.Redirect("CustomerList");
        }
    }
}