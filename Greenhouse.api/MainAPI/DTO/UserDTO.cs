using MainAPI.Models;

namespace MainAPI.DTO
{
    public class UserDTO
    {
        public string? Username { get; set; }


        public string? Email { get; set; }


        public static UserDTO ToDto(APIUser user)
        {
            return new UserDTO()
            {
                Username = user.Username,
                Email = user.Email
            };
        }
    }
}
