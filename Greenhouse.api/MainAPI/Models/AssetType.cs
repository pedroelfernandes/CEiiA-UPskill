using MainAPI.DTO;
using System.ComponentModel.DataAnnotations;

namespace MainAPI.Models
{
    public class AssetType
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}
