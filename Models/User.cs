using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Alere.Models
{
    [Table("Tbl_User")]
    public class User
    {
        [HiddenInput, Column("Id")]
        public long UserId { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Senha"), DataType(DataType.Password), MinLength(6, ErrorMessage = "Mínimo de 6 caracteres")]
        public string Password { get; set; }

        [Display(Name = "Telefone"), DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public Address Address { get; set; }
        public long? AddressId { get; set; }
    }
}