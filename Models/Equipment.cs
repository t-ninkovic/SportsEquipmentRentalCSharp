using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsEquipmentRental.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public Manufacturer Manufacturer { get; set; }
        [Display(Name = "Manufacturer")]
        public int ManufacturerId { get; set; }
        [Required]
        [StringLength(255)]
        public String Kind { get; set; }
        public String Description { get; set; }
        [Required]
        public int InStock { get; set; }
    }
}