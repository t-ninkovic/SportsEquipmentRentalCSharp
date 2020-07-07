using SportsEquipmentRental.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsEquipmentRental.ViewModels;

namespace SportsEquipmentRental.Controllers
{
    public class EquipmentController : Controller
    {
        private ApplicationDbContext _context;
        public EquipmentController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var equipments = _context.Equipments.Include(e => e.Manufacturer).ToList();
            if (User.IsInRole("AdminRole")) return View("IndexAdmin", equipments);
            return View("IndexGuest", equipments);
        }
        [Authorize(Roles = "AdminRole")]
        public ActionResult New()
        {
            var manufacturers = _context.Manufacturers.ToList();
            var viewModel = new EquipmentFormViewModel
            {
                Equipment = new Equipment(),
                Manufacturers = manufacturers
            }; 
            return View("EquipmentForm", viewModel);
        }

        [HttpPost]
        public ActionResult Create(Equipment equipment)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EquipmentFormViewModel
                {
                    Equipment = equipment,
                    Manufacturers = _context.Manufacturers.ToList()
                };
                return View("EquipmentForm", viewModel);
            }
            if (equipment.Id == 0)
                _context.Equipments.Add(equipment);
            else
            {
                var existingEquipment = _context.Equipments.Single(e => e.Id == equipment.Id);
                existingEquipment.Kind = equipment.Kind;
                existingEquipment.Description = equipment.Description;
                existingEquipment.InStock = equipment.InStock;
                existingEquipment.ManufacturerId = equipment.ManufacturerId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Equipment");
        }
        [Authorize(Roles = "AdminRole")]
        public ActionResult Edit(int id)
        {
            var equipment = _context.Equipments.SingleOrDefault(e => e.Id == id);
            if (equipment == null) return HttpNotFound();
            var viewModel = new EquipmentFormViewModel
            {
                Equipment = equipment,
                Manufacturers = _context.Manufacturers.ToList()
            };

            return View("EquipmentForm", viewModel);
        }
        [Authorize(Roles = "AdminRole")]
        public ActionResult Delete(int id)
        {
            var existingEquipment = _context.Equipments.Single(e => e.Id == id);
            _context.Equipments.Remove(existingEquipment);
            _context.SaveChanges();
            return RedirectToAction("Index", "Equipment");
        }
    }
}