using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Greenhouse.web.Models
{
    public class Asset
    {
        [Key]
        public int Id { get; set; } = 0;

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Company { get; set; }

        public string? Location { get; set; }

        [Display(Name = "Creation Date")]
        public DateTime? CreationDate { get; set; }

        [Display(Name = "Asset Type")]
        public int AssetTypeId { get; set; }

        public AssetType? AssetType { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; } = true;

        public ICollection<AssetSensor>? Sensors { get; set; }

    }
}
