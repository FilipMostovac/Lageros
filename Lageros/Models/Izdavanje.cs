using System;
using System.ComponentModel.DataAnnotations;

namespace Lageros.Models
{
    public class Izdavanje
    {
        public int Id { get; set; }

        [Display(Name = "Korisnik")]
        public int KorisnikId { get; set; }

        public Korisnik Korisnik { get; set; }

        [Display(Name = "Laptop")]
        public int? LaptopId { get; set; }

        public Laptop Laptop { get; set; }

        [Display(Name = "Monitor")]
        public int? MonitorId { get; set; }

        public Monitor Monitor { get; set; }

        [Display(Name = "Periferija")]
        public int? PeriferijaId { get; set; }

        public Periferija Periferija { get; set; }

        [Display(Name = "Datum zamjene")]
        [DataType(DataType.Date)]
        public DateTime DatumZamjene { get; set; }

        [Display(Name = "Izdao")]
        public int AdminKorisnikId { get; set; }

        public AdminKorisnik AdminKorisnik { get; set; }

    }
}