using CustomerClassLibrary.Business;
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
    public partial class CustomerEdit : System.Web.UI.Page
    {
        private ICustomerService _customerService;

        private IAddressService _addressService;

        private INoteService _noteService;

        public List<Address> Addresses { get; set; }

        public List<CustomerNote> Notes { get; set; }

        public int CustomerId{get; set;}

        public CustomerEdit()
        {
            _customerService = new CustomerService();
            _addressService = new AddressService();
            _noteService = new NoteService();
        }

        public CustomerEdit(ICustomerService customerService, IAddressService addressService, INoteService noteService)
        {
            _customerService = customerService;
            _addressService = addressService;
            _noteService = noteService;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int customerIdReq;
            int.TryParse(Request.QueryString["customerId"], out customerIdReq);
            CustomerId = customerIdReq;

            if (!IsPostBack)
            {
                LoadCustomer(customerIdReq);
                Addresses = GetAddresses(customerIdReq);
                Notes = GetNotes(customerIdReq);
            }

            Addresses = GetAddresses(CustomerId);
            Notes = GetNotes(CustomerId);
        }

        public void LoadCustomer(int customerId)
        {
            if (customerId != 0)
            {
                var customer = _customerService.GetCustomer(customerId);

                id.Text = customer.CustomerId.ToString();
                firstName.Text = customer.FirstName;
                lastName.Text = customer.LastName;
                phoneNumber.Text = customer.PhoneNumber;
                email.Text = customer.Email;
                purchaseAmount.Text = customer.TotalPurshasesAmount.ToString();                
            }
        }

        public void OnSaveClick(object sender, EventArgs e)
        {
            decimal totalAmount;
            int customerId;
            
            decimal.TryParse(purchaseAmount?.Text, out totalAmount);
            int.TryParse(id?.Text, out customerId);
            
            var customer = new Customer();
            
            customer.CustomerId = customerId;
            customer.FirstName = firstName?.Text;
            customer.LastName = lastName?.Text;
            customer.PhoneNumber = phoneNumber?.Text;
            customer.Email = email?.Text;
            customer.TotalPurshasesAmount = totalAmount;
            customer.AdressesList = Addresses;
            customer.Note = Notes;

            try
            {
                _customerService.ChangeCustomer(customer);
                Response?.Redirect($"CustomerList");
            }
            catch (WrongDataException ex)
            {
                ShowValidationErrors(ex);
            }
        }

        public List<Address> GetAddresses(int customerId)
        {

            List<Address> addresses = _addressService.GetAllAddresses(customerId).ToList<Address>();

            return addresses;
        }

        public List<CustomerNote> GetNotes(int customerId)
        {
            List<CustomerNote> notes = _noteService.GetAllNotes(customerId).ToList<CustomerNote>();
            return notes;
        }

        public void ShowValidationErrors(WrongDataException ex)
        {
            string errorMessages = ex.Message;
            errorMessages = errorMessages.Replace('(', ' ').Replace(')', '.');
            List<string> errorMessagesAsList = errorMessages.Split('.').ToList<string>();

            lastNameError.Text = errorMessagesAsList.Find(x => x.Contains("LastName"));
            phoneNumberError.Text = errorMessagesAsList.Find(x => x.Contains("PhoneNumber"));
            emailError.Text = errorMessagesAsList.Find(x => x.Contains("Email"));
            noteError.Text = errorMessagesAsList.Find(x => x.Contains("Note"));
        }

        public void OnBackClick(object sender, EventArgs e)
        {
            Response.Redirect("CustomerList");
        }
    }
}