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
        public List<Address> Addresses { get; set; } = new List<Address>();
        public AddressGroupEdit()
        {
            _addressService = new AddressService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int customerIdReq;
            int.TryParse(Request.QueryString["customerId"], out customerIdReq);

            if (customerIdReq != 0)
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

        public void OnSaveClick(object sender, EventArgs e)
        {

        }
    }
}