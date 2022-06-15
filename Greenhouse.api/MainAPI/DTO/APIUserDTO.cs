using MainAPI.Models;

namespace MainAPI.DTO
{
    public class APIUserDTO
    {
        public int Id { get; set; }

        public string? Username { get; set; }


        public string? Email { get; set; }

        public bool IsActive { get; set; }

        public int RoleId { get; set; }

        public RoleDTO? Role { get; set; }


        public static APIUserDTO ToDto(APIUser user)
        {
            return new APIUserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                IsActive = user.IsActive,
                RoleId = user.RoleId,
                Role = RoleDTO.ToDto(user.Role)
            };
        }
    }
}
