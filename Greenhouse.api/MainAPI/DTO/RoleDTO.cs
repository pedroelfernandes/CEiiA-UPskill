using MainAPI.Models;

namespace MainAPI.DTO
{
    public class RoleDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public static RoleDTO ToDto(Role role)
        {
            return new RoleDTO
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
                IsActive = role.IsActive,
            };
        }
    }
}
