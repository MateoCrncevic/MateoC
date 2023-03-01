using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebFormsCustomers.Models
{
    public class Customer
    {
        public int IDCustomer { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public int TownID { get; set; }
        public override string ToString()
        {
            return $"{Name} {Surname}";
        }

    }
}