using IOTA.Database.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace IOTA.Database.Models
{
    public class Login : IEntity
    {
        public int id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [DataType(DataType.Text)]
        public string UserType { get; set; }
    }
}
