using System.ComponentModel.DataAnnotations;

namespace Lageros.Models
{
    public class Korisnik
    {
        public int Id { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

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