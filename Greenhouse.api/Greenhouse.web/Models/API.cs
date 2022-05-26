using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;

namespace Greenhouse.web.Models
{
    public class API
    {
        public int Id { get; set; }


        public string Name { get; set; } = null!;


        public string Description { get; set; } = null!;
    }
}

