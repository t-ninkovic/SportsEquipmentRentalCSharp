using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsEquipmentRental.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        public String Address { get; set; }
        public String PhoneNumber { get; set; }
    }
}