using SportsEquipmentRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsEquipmentRental.ViewModels
{
    public class EquipmentFormViewModel
    {
        public IEnumerable<Manufacturer> Manufacturers { get; set; }
        public Equipment Equipment { get; set; }
    }
}