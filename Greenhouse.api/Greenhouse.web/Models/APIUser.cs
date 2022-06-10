using System.ComponentModel.DataAnnotations;

namespace Greenhouse.web.Models
{
    public class APIUser
    {
        
        public int Id { get; set; }


        
        public string? Username { get; set; }


        
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }


        
        public bool Active { get; set; }


        
        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}

