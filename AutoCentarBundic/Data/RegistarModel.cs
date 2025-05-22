using System.ComponentModel.DataAnnotations;

namespace AutoCentarBundic.Data
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Ime je obavezno.")]
        public string Ime { get; set; } = string.Empty;

        [Required(ErrorMessage = "Prezime je obavezno.")]
        public string Prezime { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email je obavezan.")]
        [EmailAddress(ErrorMessage = "Unesite ispravan email.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lozinka je obavezna.")]
        [MinLength(6, ErrorMessage = "Lozinka mora imati najmanje 6 karaktera.")]
        public string Password { get; set; } = string.Empty;
    }
}
