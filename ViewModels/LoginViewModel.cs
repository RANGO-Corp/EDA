using System.ComponentModel.DataAnnotations;

namespace Alere.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Usuário inválido"), DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Senha inválida"), DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "Mínimo de 6 caracteres")]
        public string Password { get; set; }
    }
}