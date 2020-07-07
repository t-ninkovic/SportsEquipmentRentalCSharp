using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsEquipmentRental.Models
{
    public class EquipmentRental
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        public Equipment Equipment { get; set; }
        [Display(Name = "Equipment")]
        public int EquipmentId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}