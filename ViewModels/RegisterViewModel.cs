using System.ComponentModel.DataAnnotations;
using Alere.Models;

namespace Alere.ViewModels
{
    public class RegisterViewModel
    {
        public User User { get; set; }

        [Required(ErrorMessage = "Senha inválida"), DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "Mínimo de 6 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Senha inválida"), DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Senhas não coincidem.")]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "Mínimo de 6 caracteres")]
        public string ConfirmPassword { get; set; }
    }
}