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

        public AddressEdit()
        {
            _addressService = new AddressService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int addressIdReq;

            int.TryParse(Request.QueryString["addressId"], out addressIdReq);

            LoadAddress(addressIdReq);
        }

        public void LoadAddress(int addressId)
        {
            if (addressId != 0)
            {
                var address = _addressService.GetAddress(addressId);

                addressLine.Text = address.AdressLine;
                addressLine2.Text = address.AdressLine2;
                addressType.Text = address.AddressType.ToString();
                city.Text = address.City;
                postalCode.Text = address.PostalCode;
                state.Text = address.State;
                country.Text = address.Country;
            }

        }
    }
}