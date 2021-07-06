﻿using CustomerClassLibrary.Business;
using CustomerClassLibrary.Common;
using CustomerClassLibrary.Data.Business;
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
        private ICustomerService _customerService;

        public AddCustomer()
        {
            _customerService = new CustomerService();
        }

        public AddCustomer(ICustomerService customerService)
        {
            _customerService = customerService;
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
                AddressTypeEnum = typeOfAddress,
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
                ShowValidationErrors(ex); 
            }
        }

        public void ShowValidationErrors(WrongDataException ex)
        {
            string errorMessages = ex.Message;
            errorMessages = errorMessages.Replace('(', ' ').Replace(')', '.');
            List<string> errorMessagesAsList = errorMessages.Split('.').ToList<string>();

            addressLineError.Text = errorMessagesAsList.Find(x => x.Contains("AdressLine"));
            addressLine2Error.Text = errorMessagesAsList.Find(x => x.Contains("AdressLine2"));
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
    }

}