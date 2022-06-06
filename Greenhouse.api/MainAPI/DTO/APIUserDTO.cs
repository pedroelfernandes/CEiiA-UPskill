using MainAPI.Models;

namespace MainAPI.DTO
{
    public class APIUserDTO
    {
        public int Id { get; set; }

        public string? Username { get; set; }


        public string? Email { get; set; }

        public bool Active { get; set; }

        public int RoleId { get; set; }

        public static APIUserDTO ToDto(APIUser user)
        {
            return new APIUserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Active = user.Active,
                RoleId = user.RoleId,
            };
        }
    }
}
