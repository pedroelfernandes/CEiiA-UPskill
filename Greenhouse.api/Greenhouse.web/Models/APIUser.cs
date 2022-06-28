using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Greenhouse.web.Models
{
    public class APIUser
    {
        [Key]
        public int Id { get; set; }


        public string? Username { get; set; }

        [JsonIgnore]
        [RegularExpression("^[a-zA-Z0-9]{4,8}", ErrorMessage = "Format invalid. Password must contain between 4 and 8 alphanumeric characters")]
        public string? Password { get; set; }

        [JsonIgnore]
        [RegularExpression("^[a-zA-Z0-9]{4,8}", ErrorMessage = "Format invalid. Password must contain between 4 and 8 alphanumeric characters")]
        public string? OldPassword { get; set; }

        
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }



        public bool IsActive { get; set; }



        public int RoleId { get; set; }


        public Role? Role { get; set; }
    }
}

