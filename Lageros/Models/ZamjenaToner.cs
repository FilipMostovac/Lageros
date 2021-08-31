using System;
using System.ComponentModel.DataAnnotations;

namespace Lageros.Models
{
    public class ZamjenaToner
    {
        public int Id { get; set; }

        [Display(Name = "Printer")]
        public int PrinterId { get; set; }

        public Printer Printer { get; set; }

        [Display(Name = "Toner")]
        public int TonerId { get; set; }

        public Toner Toner { get; set; }

        [Required(ErrorMessage = "Datum zamjene obavezno je polje!")]
        [Display(Name = "Datum zamjene")]
        [DataType(DataType.Date)]
        public DateTime DatumZamjene { get; set; }

        [Display(Name = "Zamjenio")]
        public int AdminKorisnikId { get; set; }

        public AdminKorisnik AdminKorisnik { get; set; }

    }
}
