using MainAPI.DTO;
using MainAPI.Models;

namespace MainAPI.Services.Interfaces
{
    public interface IRoleService
    {
        Task<RoleDTO> Create(Role role);

        Task<RoleDTO> Get(int id);

        Task<RoleDTO> Edit(Role role);

        Task<bool> Delete(int id);
    }
}
