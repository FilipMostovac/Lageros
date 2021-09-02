using System.ComponentModel.DataAnnotations;

namespace Lageros.Models
{
    public class Korisnik
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ime je obavezno polje!")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno polje!")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Email je obavezan!")]
        public string Email { get; set; }

        [Display(Name = "Sektor")]
        public int SektorId { get; set; }

        public Sektor Sektor { get; set; }

        [Display(Name = "Ime i Prezime")]
        public string ImePrezime
        {
            get => Ime + ' ' + Prezime;
        }
    }
}