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
        // GET: Address
        public ActionResult Index(int customerId)
        {
            var addresses = _addressService.GetAllAddresses(customerId);

            return View(addresses);
        }

        // GET: Address/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Address/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Address/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Address/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Address/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
