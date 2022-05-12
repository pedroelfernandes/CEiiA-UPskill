using System.ComponentModel.DataAnnotations;

namespace MainAPI.Models
{
    public class API
    {
        [Key]
        [Required]
        public int Id { get; set; }


        [StringLength(25)]
        public string? Name { get; set; }


        [Required]
        [DataType(DataType.Url)]
        public string? Url { get; set; }
    }
}
