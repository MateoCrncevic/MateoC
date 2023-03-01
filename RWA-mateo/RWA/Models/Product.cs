using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWA.Models
{
    public class Product
    {
        public int IdProizvod { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public string BrojProizvoda { get; set; }
        [Required]
        public string Boja { get; set; }
        [Range(1, 1000)]
        public short MinKolicinaNaSkladistu { get; set; }      
        public decimal CijenaBezPdva { get; set; }
        public int? PotKategorijaID { get; set; }
        public SubCategory Subcategory { get; set; }
    }
}