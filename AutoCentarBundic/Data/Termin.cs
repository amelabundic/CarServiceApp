using System.ComponentModel.DataAnnotations;

namespace AutoCentarBundic.Data
{
    public class Termin
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Ime je obavezno.")]
        public string Ime { get; set; } = string.Empty;
        [Required(ErrorMessage = "Prezime je obavezno.")]
        public string Prezime { get; set; } = string.Empty;
        [Required(ErrorMessage = "Datum i vrijeme su obavezani.")]
        public DateTime Datum { get; set; }
        [Required(ErrorMessage = "Unesite model automobila.")]
        public string Automobil { get; set; } = string.Empty;
        [Required(ErrorMessage = "Opis problema na automobilu je obavezan")]
        public string Problem { get; set; } = string.Empty;

    }
}
