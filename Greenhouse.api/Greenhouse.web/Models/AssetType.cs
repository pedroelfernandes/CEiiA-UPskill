
using System.ComponentModel.DataAnnotations;

namespace Greenhouse.web.Models
{
    public class AssetType
    {
        public AssetType()
        {
        }

        public AssetType(int id, string name, string description, bool isActive=true)
        {
            Id = id;
            Name = name;
            Description = description;
            IsActive = isActive;
        }

        [Key]
        public int? Id { get; set; } = 0;

        public string? Name { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

    }
}
