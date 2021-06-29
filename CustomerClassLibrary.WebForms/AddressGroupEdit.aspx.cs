using CustomerClassLibrary.Data.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerClassLibrary.WebForms
{
    public partial class AddressGroupEdit : System.Web.UI.Page
    {
        private AddressService _addressService;

        private int CustomerId;
        public List<Address> Addresses { get; set; } = new List<Address>();
        public AddressGroupEdit()
        {
            _addressService = new AddressService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int customerIdReq;
            int.TryParse(Request.QueryString["customerId"], out customerIdReq);
            CustomerId = customerIdReq;

            if (!IsPostBack)
            {
                if (CustomerId != 0)
                {
                    Addresses = _addressService.GetAllAddresses(customerIdReq);
                }

                if (Addresses.Count == 0)
                {
                    Addresses.Add(new Address());
                }

                addressRepeater.DataSource = Addresses;
                addressRepeater.DataBind();
            }
           
        }

        public void OnSaveClick(object sender, EventArgs e)
        {
            List<Address> addresses = new List<Address>();

            if (addressRepeater.Items.Count != 0)
            {
                foreach (RepeaterItem item in addressRepeater.Items)
                {
                    int addressId;
                    AddressType typeOfAddress;

                    int.TryParse(((HiddenField)item.FindControl("addressId"))?.Value, out addressId);
                    Enum.TryParse<AddressType>(((TextBox)item.FindControl("addressType"))?.Text, out typeOfAddress);

                    addresses.Add(new Address()
                    {
                        AddressId = addressId,
                        AdressLine = ((TextBox)item.FindControl("addressLine"))?.Text,
                        AdressLine2 = ((TextBox)item.FindControl("addressLine2"))?.Text,
                        AddressType = typeOfAddress,
                        City = ((TextBox)item.FindControl("city"))?.Text,
                        PostalCode = ((TextBox)item.FindControl("postalCode"))?.Text,
                        State = ((TextBox)item.FindControl("state"))?.Text,
                        Country = ((TextBox)item.FindControl("country"))?.Text
                    });
                }
            }

            if (addresses.Count != 0)
            {
                foreach(var address in addresses)
                {
                    _addressService.ChangeAddress(address);
                }
            }

            Response?.Redirect($"CustomerEdit?customerId={CustomerId}");
        }
    }
}