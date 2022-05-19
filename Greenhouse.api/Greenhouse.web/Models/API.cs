using System.ComponentModel.DataAnnotations;

namespace Greenhouse.web.Models
{
    public class API
    {
        [Required]
        public int ApiId { get; set; }


        [Required, StringLength(50)]
        public string ApiName { get; set; } = null!;


        [StringLength(250)]
        public string ApiDescription { get; set; } = null!;

    }
}
