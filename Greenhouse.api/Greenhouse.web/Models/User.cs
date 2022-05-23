using System.ComponentModel.DataAnnotations;

namespace Greenhouse.web.Models
{
    public class User
    {
        public string? Name { get; set; }

        public DataType EmailAddress { get; set; }

        public string? Password { get; set; }
    }
}
