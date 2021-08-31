using System.ComponentModel.DataAnnotations;

namespace Lageros.Models
{
    public class AdminKorisnik
    {
        public int Id { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Email { get; set; }

        [Display(Name = "Ime i Prezime")]
        public string PrezimeIme
        {
            get => Ime + ' ' + Prezime;
        }
    }
}
