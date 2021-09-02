using System.ComponentModel.DataAnnotations;

namespace Lageros.Models
{
    public class Sektor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Naziv sektora je obavezna!")]
        [Display(Name = "Sektor")]
        public string NazivSektora { get; set; }
    }
}