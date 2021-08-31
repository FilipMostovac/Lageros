using System;
using System.ComponentModel.DataAnnotations;

namespace Lageros.Models
{
    public class NabavaTonera
    {
        public int Id { get; set; }

        [Display(Name = "Toner")]
        public int TonerId { get; set; }

        public Toner Toner { get; set; }

        [Required(ErrorMessage = "Količina je obavezno polje!")]
        [Display(Name = "Količina")]
        public int Kolicina { get; set; }

        [Required(ErrorMessage = "Datum nabave obavezno je polje!")]
        [Display(Name = "Datum nabave")]
        [DataType(DataType.Date)]
        public DateTime DatumZamjene { get; set; }
    }
}
