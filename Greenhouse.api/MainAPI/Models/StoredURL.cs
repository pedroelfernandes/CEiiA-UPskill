using System.ComponentModel.DataAnnotations.Schema;

namespace MainAPI.Models
{
    [NotMapped]
    public class StoredURL
    {
        public int? Id { get; set; }


        public string? Url { get; set; }
    }
}
