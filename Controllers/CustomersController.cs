using SportsEquipmentRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsEquipmentRental.Controllers
{
    
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ViewResult Index()
        {
            var customers = _context.Customers.ToList();
            if (User.IsInRole("AdminRole"))
                return View("IndexAdmin", customers);
            
            return View("IndexGuest", customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null) return HttpNotFound();
            return View(customer);
        }
        [Authorize(Roles = "AdminRole")]
        public ActionResult New()
        {
            var customer = new Customer();
            return View("CustomerForm", customer);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("CustomerForm", customer);
            }
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var existingCustomer = _context.Customers.Single(c => c.Id == customer.Id);
                existingCustomer.Name = customer.Name;
                existingCustomer.Address = customer.Address;
                existingCustomer.PhoneNumber = customer.PhoneNumber;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        [Authorize(Roles = "AdminRole")]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null) return HttpNotFound();
            
            return View("CustomerForm", customer);
        }
        [Authorize(Roles = "AdminRole")]
        public ActionResult Delete(int id)
        {
            var existingCustomer = _context.Customers.Single(c => c.Id == id);
            _context.Customers.Remove(existingCustomer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
    }
}