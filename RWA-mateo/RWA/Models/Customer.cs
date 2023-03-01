using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWA.Models
{
    public class Customer
    {
        public int IDKupac { get; set; }

        [Required]
        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Telefon { get; set; }
        public Town Town { get; set; }


        public int grad { get; set; }

        public int GradID { get; set; }
        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }
    }
}