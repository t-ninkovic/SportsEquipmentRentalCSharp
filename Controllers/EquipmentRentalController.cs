using SportsEquipmentRental.Models;
using SportsEquipmentRental.ViewModels;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsEquipmentRental.Controllers
{
    public class EquipmentRentalController : Controller
    {
        private ApplicationDbContext _context;

        public EquipmentRentalController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var equipments = _context.Equipments.Where(e => e.InStock > 0).ToList();
            var customers = _context.Customers.ToList();
            var viewModel = new EquipmentRentalFormViewModel
            {
                Equipments = equipments,
                Customers = customers,
                EquipmentRental = new EquipmentRental()
            };
            return View("EquipmentRentalForm", viewModel);
        }

        [HttpPost]
        public ActionResult Create(EquipmentRental equipmentRental)
        {
            var eqId = equipmentRental.EquipmentId;
            var eq = _context.Equipments.Single(e => e.Id == eqId);
            if (eq.InStock <= 0) return View("Error");

            if (!ModelState.IsValid)
            {
                var equipments = _context.Equipments.Where(e => e.InStock > 0).ToList();
                var customers = _context.Customers.ToList();
                var viewModel = new EquipmentRentalFormViewModel
                {
                    Equipments = equipments,
                    Customers = customers,
                    EquipmentRental = equipmentRental
                };
                return View("EquipmentRentalForm", viewModel);
            }

            eq.InStock--;
            equipmentRental.RentDate = DateTime.Now;
            _context.EquipmentRentals.Add(equipmentRental);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Active()
        {
            var rentals = _context.EquipmentRentals.Where(e => e.ReturnDate.Equals(null)).Include(e => e.Equipment).Include(e => e.Customer).ToList();

            return View(rentals);
        }

        public ActionResult ReturnDate(int id)
        {
            var rental = _context.EquipmentRentals.Single(r => r.Id == id);
            rental.ReturnDate = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Active", "EquipmentRental");
        }

    }
}