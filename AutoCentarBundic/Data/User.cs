using System.ComponentModel.DataAnnotations;

namespace AutoCentarBundic.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ime je obavezno")]
        public string Ime { get; set; } = string.Empty;
        [Required(ErrorMessage = "Prezime je obavezno")]
        public string Prezime { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email je obavezan")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password je obavezan")]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
