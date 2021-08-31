using System.ComponentModel.DataAnnotations;

namespace Lageros.Models
{
    public class Periferija
    {
        public int Id { get; set; }

        public int IzborId { get; set; }

        [Display(Name = "Periferija")]
        public Izbor Izbor { get; set; }

        public string Model { get; set; }

        public int Kolicnina { get; set; }

    }
}