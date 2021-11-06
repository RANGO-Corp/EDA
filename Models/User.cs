using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDA.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email {get;set;}
        public string Password {get;set;}
        public string Phone {get;set;}
        public UserType Type {get;set;}
    }

    public enum UserType
    {
        DONOR, 
        RECEIVER
    }
}