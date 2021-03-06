using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Greenhouse.web.Models
{
    public class Asset
    {
        public int? Id { get; set; } = 0;


        public string? Name { get; set; }


        public string? Description { get; set; }


        public string? Company { get; set; }


        public string? Location { get; set; }


        [Display(Name = "Creation Date")]
        public DateTime? CreationDate { get; set; } = DateTime.Now;


        [Display(Name = "Asset Type")]
        public int AssetTypeId { get; set; }


        public AssetType? AssetType { get; set; }


        public bool IsActive { get; set; } = true;

      
        public List<Sensor>? Sensors { get; set; }
    }
}
