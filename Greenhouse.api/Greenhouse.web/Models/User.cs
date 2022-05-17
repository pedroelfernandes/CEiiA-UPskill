using System.ComponentModel.DataAnnotations;

namespace Greenhouse.web.Models
{
    public class User
    {
        [Required]
        [Key]
        public int UserId { get; set; }
        
        
        [Required]
        public string? UserName { get; set; }
        
       
        public string? Name { get; set; }
        
       
        public string? Company { get; set; }
        
       
        public int PhoneNumber { get; set; }

       
        [Required]
        public string? EmailAddress { get; set; }

       
        [Required]
        public string? Password { get; set; }
    }
}
