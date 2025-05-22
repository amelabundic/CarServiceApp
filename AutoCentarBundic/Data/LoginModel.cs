using System.ComponentModel.DataAnnotations;

namespace AutoCentarBundic.Data
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email je obavezan!")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage ="Password je obavezan!")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
