using System.ComponentModel.DataAnnotations;

namespace Lageros.Models
{
    public class Toner
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Model tonera je obavezan!")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Boja tonera je obavezna!")]
        public string Boja { get; set; }

        [Required(ErrorMessage = "Količina tonera je obavezna!")]
        [Display(Name = "Količina")]
        public int Kolicina { get; set; }
    }
}
