using CustomerClassLibrary.Data.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerClassLibrary.WebForms
{
    public partial class AddressAdd : System.Web.UI.Page
    {
        private AddressService _addressService;

        public int CustomerId { get; set; }

        public AddressAdd()
        {
            _addressService = new AddressService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int customerIdReq;

            int.TryParse(Request.QueryString["customerId"], out customerIdReq);

            CustomerId = customerIdReq;
        }

        public void OnAddClick(object sender, EventArgs e)
        {
            var address = new Address();
            AddressType typeOfAddress;
            Enum.TryParse<AddressType>(addressType?.Text, out typeOfAddress);

            address.CustomerId = CustomerId;
            address.AdressLine = addressLine?.Text;
            address.AdressLine2 = addressLine2?.Text;
            address.AddressType = typeOfAddress;
            address.City = city?.Text;
            address.PostalCode = postalCode?.Text;
            address.State = state?.Text;
            address.Country = country?.Text;

            _addressService.CreateAddress(address);

            Response?.Redirect($"CustomerEdit?customerId={CustomerId}");
        }
    }
}