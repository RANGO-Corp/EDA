using System.ComponentModel.DataAnnotations;

namespace Alere.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Usuário inválido"), DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Senha inválida"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}