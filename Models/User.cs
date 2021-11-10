using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Alere.Models
{
    public class User
    {
        [HiddenInput]
        public long UserId { get; set; }
        
        [Display(Name="Nome")]
        public string Name { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Display(Name="Senha"), DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Display(Name="Telefone"), DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        
        [Display(Name="Tipo")]
        public UserType Type { get; set; }

        public Address Address { get; set; }
        public long AddressId { get; set; }
    }

    public enum UserType
    {
        [Display(Name = "Doador")] DONOR,
        [Display(Name = "Receptor")] RECEIVER
    }
}