using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainAPI.Models
{
    [NotMapped]
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
