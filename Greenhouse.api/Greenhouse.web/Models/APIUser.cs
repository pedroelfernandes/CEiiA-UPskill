using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Greenhouse.web.Models
{
    public class APIUser
    {
        [Key]
        [Required]
        public int Id { get; set; }


        [Required]
        public string? Username { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }


        [Required]
        public bool Active { get; set; }


        [Required, ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}

