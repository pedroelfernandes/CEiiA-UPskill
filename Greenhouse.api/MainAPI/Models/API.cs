using System.ComponentModel.DataAnnotations;

namespace MainAPI.Models
{
    public class API
    {
        [Key]
        [Required]
        public int Id { get; set; }


        [Required]
        [StringLength(25)]
        public string? Name { get; set; }


        [StringLength(100)]
        public string? Description { get; set; }
    }
}
