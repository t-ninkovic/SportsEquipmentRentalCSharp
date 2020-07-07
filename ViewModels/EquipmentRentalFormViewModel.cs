using SportsEquipmentRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsEquipmentRental.ViewModels
{
    public class EquipmentRentalFormViewModel
    {
        public IEnumerable<Equipment> Equipments { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public EquipmentRental EquipmentRental { get; set; }
    }
}