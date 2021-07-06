using CustomerClassLibrary.Data.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerClassLibrary.WebForms
{
    public partial class AddressDelete : System.Web.UI.Page
    {
        private IAddressService _addressService;

        public int CustomerId { get; set; }

        public AddressDelete()
        {
            _addressService = new AddressService();
        }

        public AddressDelete(IAddressService addressService)
        {
            _addressService = addressService;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int addressId;
            int.TryParse(Request.QueryString["addressId"], out addressId);
            
            if (addressId != 0)
            {
                var address = _addressService.GetAddress(addressId);
                CustomerId = address.CustomerId;

                _addressService.DeleteAddress(address.AddressId);

                Response?.Redirect($"CustomerEdit?customerId={CustomerId}");
            }

        }
    }
}