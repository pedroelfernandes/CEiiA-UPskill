using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainAPI.Models
{
    public class Asset
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public string? Company { get; set; }

        [Required]
        public string? Location { get; set; }

        [Required]
        public DateTime? CreationDate { get; set; }

        [Required, ForeignKey("AssetType")]
        public int AssetTypeId { get; set; }
        public AssetType? AssetType { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public ICollection<AssetSensor>? Sensors { get; set; }

    }
}
