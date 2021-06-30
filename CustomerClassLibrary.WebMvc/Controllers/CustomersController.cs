using CustomerClassLibrary.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerClassLibrary.Data.Business;

namespace CustomerClassLibrary.WebMvc.Controllers
{
    public class CustomersController : Controller
    {
        private ICustomerService _customerService;
        private IAddressService _addressService;
        private INoteService _noteService;

        public CustomersController()
        {
            _customerService = new CustomerService();
            _addressService = new AddressService();
            _noteService = new NoteService();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _customerService.GetAllCustomers();

            return View(customers);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            var defaultValues = new Customer();
            defaultValues.AdressesList = new List<Address>() { new Address() };
            defaultValues.Note = new List<CustomerNote>() { new CustomerNote() };

            return View(defaultValues);
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                _customerService.
                    CreateCustomer(customer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(customer);
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _customerService.GetCustomer(id);
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                List <Address> addresses = _addressService.GetAllAddresses(customer.CustomerId);
                List<CustomerNote> notes = _noteService.GetAllNotes(customer.CustomerId);

                customer.AdressesList = addresses;
                customer.Note = notes;

                _customerService.ChangeCustomer(customer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(customer);
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = _customerService.GetCustomer(id);
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            try
            {
                // TODO: Add delete logic here

                _customerService.DeleteCustomer(customer);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View(customer);
            }
        }
    }
}
