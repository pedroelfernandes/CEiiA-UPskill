using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Greenhouse.web.Models
{
    public class APIUser
    {
        [Key]
        public int Id { get; set; } = 0;


        public string? Username { get; set; }


        public string? Password { get; set; }


        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }



        public bool IsActive { get; set; }



        public int RoleId { get; set; }


        public Role? Role { get; set; }
    }
}

