using System.ComponentModel.DataAnnotations;

namespace Lageros.Models
{
    public class Periferija
    {
        public int Id { get; set; }

        [Display(Name = "Naziv periferije")]
        public int IzborId { get; set; }


        [Display(Name = "Periferija")]
        public Izbor Izbor { get; set; }

        public string Model { get; set; }

        [Required(ErrorMessage = "Količina periferije je obavezna!")]
        [Display(Name = "Količina")]
        public int Kolicnina { get; set; }

    }
}