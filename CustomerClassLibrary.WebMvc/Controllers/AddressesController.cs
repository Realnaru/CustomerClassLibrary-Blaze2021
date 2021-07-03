using CustomerClassLibrary.Data.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerClassLibrary.WebMvc.Controllers
{
    [Route ("customers/{customerId}/[controller]/[action]/{addressId?}")]
    public class AddressesController : Controller
    {
        private IAddressService _addressService;

        public AddressesController()
        {
            _addressService = new AddressService();
        }

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        // GET: Address
        public ActionResult Index(int customerId)
        {
            var addresses = _addressService.GetAllAddresses(customerId);

            return View(addresses);
        }

        // GET: Address/Details/5
        public ActionResult Details(int addressId)
        {
            var address = _addressService.GetAddress(addressId);
            return View(address);
        }

        // GET: Address/Create
        public ActionResult Create(int customerId)
        {
            var address = new Address();
            address.CustomerId = customerId;
            return View(address);
        }

        // POST: Address/Create
        [HttpPost]
        public ActionResult Create(int customerId, Address address)
        {
            try
            {
                // TODO: Add insert logic here
                _addressService.CreateAddress(address);
                return RedirectToAction("Index", new { customerId = customerId});
            }
            catch
            {
                return View(address);
            }
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int addressId)
        {
            var address = _addressService.GetAddress(addressId);
            return View(address);
        }

        // POST: Address/Edit/5
        [HttpPost]
        public ActionResult Edit(int addressId, Address address)
        {
            int customerId = _addressService.GetAddress(addressId).CustomerId;
            try
            {
                _addressService.ChangeAddress(address);
                // TODO: Add update logic here

                return RedirectToAction("Index", new { customerId = customerId });
            }
            catch
            {
                return View(address);
            }
        }

        // GET: Address/Delete/5
        public ActionResult Delete(int addressId)
        {
            var address = _addressService.GetAddress(addressId);
            return View(address);
        }

        // POST: Address/Delete/5
        [HttpPost]
        public ActionResult Delete(int addressId, Address address)
        {
            int customerId = _addressService.GetAddress(addressId).CustomerId;
            try
            {
                // TODO: Add delete logic here
                _addressService.DeleteAddress(addressId);
                return RedirectToAction("Index", new { customerId = customerId});
            }
            catch
            {
                return View();
            }
        }
    }
}
