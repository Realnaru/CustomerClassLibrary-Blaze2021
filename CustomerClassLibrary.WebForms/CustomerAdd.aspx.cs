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
            Decimal totalAmount;
            AddressType typeOfAddress;
            
            
            decimal.TryParse(purchaseAmount?.Text, out totalAmount);
            Enum.TryParse(addressType?.Text, out typeOfAddress);
            
            var customer = new Customer()
            {
                FirstName = firstName?.Text,
                LastName = lastName?.Text,
                PhoneNumber = phoneNumber?.Text,
                Email = email?.Text,
                TotalPurshasesAmount = totalAmount
            };


            var address = new Address()
            {
                AdressLine = addressLine?.Text,
                AdressLine2 = addressLine2?.Text,
                AddressType = typeOfAddress,
                City = city?.Text,
                PostalCode = postalcode?.Text,
                State = state?.Text,
                Country = country?.Text
            };

            var customerNote = new CustomerNote()
            {
                Note = note?.Text
            };

            try
            {
                customer.AddAddress(address);
                customer.AddNote(customerNote);
                _customerService.CreateCustomer(customer);
                Response?.Redirect("CustomerList");
            }
            catch (WrongDataException ex)
            {
                //lastNameError.Text = ex.Message;
                ShowValidationErrors(ex);
                //string errorMessages = ex.Message;
                //errorMessages = errorMessages.Replace('(', ' ').Replace(')', '.');
                //List<string> errorMessagesAsList = errorMessages.Split('.').ToList<string>();
            }
        }

        public void ShowValidationErrors(WrongDataException ex)
        {
            string errorMessages = ex.Message;
            errorMessages = errorMessages.Replace('(', ' ').Replace(')', '.');
            List<string> errorMessagesAsList = errorMessages.Split('.').ToList<string>();

            addressLineError.Text = errorMessagesAsList.Find(x => x.Contains("AdressLine"));
            addressTypeError.Text = errorMessagesAsList.Find(x => x.Contains("AddressType"));
            cityError.Text = errorMessagesAsList.Find(x => x.Contains("City"));
            postalcodeError.Text = errorMessagesAsList.Find(x => x.Contains("PostalCode"));
            stateError.Text = errorMessagesAsList.Find(x => x.Contains("State"));
            countryError.Text = errorMessagesAsList.Find(x => x.Contains("Country"));

            noteError.Text = errorMessagesAsList.Find(x => x.Contains("Note"));

            lastNameError.Text = errorMessagesAsList.Find(x => x.Contains("LastName"));
            phoneNumberError.Text = errorMessagesAsList.Find(x => x.Contains("PhoneNumber"));
            emailError.Text = errorMessagesAsList.Find(x => x.Contains("Email"));
            
        }

        public void ShowCustomerValidationErrors(WrongDataException ex)
        {
            string errorMessages = ex.Message;
            errorMessages = errorMessages.Replace('(', ' ').Replace(')', '.');
            List<string> errorMessagesAsList = errorMessages.Split('.').ToList<string>();
        }



    }

}