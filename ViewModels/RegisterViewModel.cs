using System.ComponentModel.DataAnnotations;
using Alere.Models;

namespace Alere.ViewModels
{
    public class RegisterViewModel
    {
        public User User { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Compare(nameof(Password), ErrorMessage = "Senha não coincide. Verifique as senhas.")]
        public string ConfirmPassword { get; set; }
    }
}