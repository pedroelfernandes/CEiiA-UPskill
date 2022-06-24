
using System.ComponentModel.DataAnnotations;

namespace Greenhouse.web.Models
{
    public class AssetType
    {
        [Key]
        public int? Id { get; set; } = 0;

        public string? Name { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

    }
}
