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
    public partial class AddressEdit : System.Web.UI.Page
    {

        private AddressService _addressService;
        private int AddressId { get; set; }
        private int CustomerId { get; set; }

        public AddressEdit()
        {
            _addressService = new AddressService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int addressIdReq;
            int.TryParse(Request.QueryString["addressId"], out addressIdReq);
            AddressId = addressIdReq;
            CustomerId = _addressService.GetAddress(addressIdReq).CustomerId;

            if (!IsPostBack)
            { 
                LoadAddress(AddressId);
            }
       
        }

        public void LoadAddress(int addressId)
        {
            if (addressId != 0)
            {
                var address = _addressService.GetAddress(addressId);

                addressLine.Text = address.AdressLine;
                line2.Text = address.AdressLine2;
                addressType.Text = address.AddressType.ToString();
                city.Text = address.City;
                postalCode.Text = address.PostalCode;
                state.Text = address.State;
                country.Text = address.Country;
            }

        }
        public void OnSaveClick(object sender, EventArgs e)
        {

                var address = new Address();
                AddressType typeOfAddress;

                Enum.TryParse<AddressType>(addressType?.Text, out typeOfAddress);

                address.AddressId = AddressId;
                address.AdressLine = addressLine.Text;
                address.AddressType = typeOfAddress;
                address.AdressLine2 = line2?.Text;
                address.City = city?.Text;
                address.PostalCode = postalCode?.Text;
                address.State = state?.Text;
                address.Country = country?.Text;

            try
            {
                _addressService.ChangeAddress(address);
                Response?.Redirect($"CustomerEdit?customerId={CustomerId}");
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
            addressTypeError.Text = errorMessagesAsList.Find(x => x.Contains("AddressType"));
            cityError.Text = errorMessagesAsList.Find(x => x.Contains("City"));
            postalCodeError.Text = errorMessagesAsList.Find(x => x.Contains("PostalCode"));
            stateError.Text = errorMessagesAsList.Find(x => x.Contains("State"));
            countryError.Text = errorMessagesAsList.Find(x => x.Contains("Country"));
        }
    }
}