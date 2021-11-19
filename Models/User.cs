using System;
using System.Collections.Generic;
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

        [Required(ErrorMessage = "Nome deve ser preenchido"), Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email deve ser preenchido"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Senha"), DataType(DataType.Password),]
        [Required(ErrorMessage = "Senha deve ser preenchida"), StringLength(255, MinimumLength = 6, ErrorMessage = "Mínimo de 6 caracteres")]
        public string Password { get; set; }

        [Display(Name = "Telefone"), DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public Address Address { get; set; }
        public long? AddressId { get; set; }

        public string Photo { get; set; }

        public DateTime CreatedAt { get; private set; } = DateTime.Now;

        // 1 : N
        public virtual ICollection<Food> Foods { get; set; }
    }
}