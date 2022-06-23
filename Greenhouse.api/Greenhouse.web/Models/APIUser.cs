using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Greenhouse.web.Models
{
    public class APIUser
    {
        [Key]
        public int Id { get; set; } = 0;


        public string? Username { get; set; }

        [JsonIgnore]
        public string? Password { get; set; }

        [JsonIgnore]
        public string? OldPassword { get; set; }

        
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }



        public bool IsActive { get; set; }



        public int RoleId { get; set; }


        public Role? Role { get; set; }
    }
}

