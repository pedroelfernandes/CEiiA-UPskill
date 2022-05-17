using MainAPI.Models;

namespace MainAPI.DTO
{
    public class APIDTO
    {
        public string? Name { get; set; }


        public string? Description { get; set; }


        public static APIDTO ToDto(API api)
        {
            return new APIDTO()
            {
                Name = api.Name,
                Description = api.Description
            };
        }
    }
}
