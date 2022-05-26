using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;

namespace Greenhouse.web.Models
{
    public class API
    {
        [Required]
        public int Id { get; set; }


        [Required, StringLength(50)]
        public string Name { get; set; } = null!;


        [StringLength(250)]
        public string Description { get; set; } = null!;
    }
}

