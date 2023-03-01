using System.ComponentModel.DataAnnotations;

namespace RWA.Models
{
    public class Category
    {
        
        public int IDKategorija { get; set; }


        [Display(Name = "Naziv")]
        [Required(ErrorMessage = "Naziv je obvezan")]
        public string Naziv { get; set; }

    }
}