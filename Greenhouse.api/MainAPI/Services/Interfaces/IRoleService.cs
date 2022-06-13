using MainAPI.DTO;
using MainAPI.Models;

namespace MainAPI.Services.Interfaces
{
    public interface IRoleService
    {
        Task<RoleDTO> Create(Role role);

        Task<List<RoleDTO>> Get();

        Task<RoleDTO> GetRole(int id);

        Task<RoleDTO> Edit(Role role);

        Task<bool> ChangeState(int id);
    }
}
