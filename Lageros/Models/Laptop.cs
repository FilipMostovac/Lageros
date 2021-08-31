using System.ComponentModel.DataAnnotations;

namespace Lageros.Models
{
    public class Laptop
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Inventarni broj je obavezan!")]
        public string INV { get; set; }

        [Required(ErrorMessage = "Model laptopa je obavezan!")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Količina RAM memorije je obavezna!")]
        public string RAM { get; set; }

        [Required(ErrorMessage = "Model procesora je obavezan!")]
        public string CPU { get; set; }

        [Required(ErrorMessage = "Veličina HDD/SSD-a je obavezna!")]
        public string HDD { get; set; }

        [Required(ErrorMessage = "Opearcijski sustav je obavezan!")]
        public string WINDOWS { get; set; }

        public bool Izdano { get; set; }

    }
}