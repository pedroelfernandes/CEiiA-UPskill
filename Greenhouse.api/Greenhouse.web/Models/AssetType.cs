
using System.ComponentModel.DataAnnotations;

namespace Greenhouse.web.Models
{
    public class AssetType
    {
        [Key]
        public int? Id { get; set; } = 0;

        //[Required]
        public string? Name { get; set; }

        //[Required]
        //[RegularExpression(@"^.{1,}$", ErrorMessage = "Minimum 1 character required")]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

    }
}
