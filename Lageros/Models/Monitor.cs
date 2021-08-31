using System.ComponentModel.DataAnnotations;

namespace Lageros.Models
{
    public class Monitor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Inventarni broj je obavezan!")]
        public string INV { get; set; }

        [Required(ErrorMessage = "Model monitora je obavezan!")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Veličina monitora je obavezna!")]
        public string Velicina { get; set; }

        public bool Izdano { get; set; }

    }
}