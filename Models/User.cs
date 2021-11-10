using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alere.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
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