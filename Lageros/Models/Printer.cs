using System.ComponentModel.DataAnnotations;

namespace Lageros.Models
{
    public class Printer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Naziv printera je obavezan!")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Model printera je obavezan!")]
        public string Model { get; set; }

        [Required(ErrorMessage = "IP adresa printera je obavezna!")]
        [Display(Name = "IP Adresa")]
        public string IP { get; set; }
    }
}

