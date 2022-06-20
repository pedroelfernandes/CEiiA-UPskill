using Greenhouse.web.Models;

namespace Greenhouse.web.Services.Interfaces
{
    public interface IRolesServices
    {
        Task<List<Role>> Get();

        Task<Role> GetRoleById(int id);

        Task<Role> Create(Role role);

        Task<Role> Edit(Role role);

        Task<bool> ChangeState(int id);
    }
}
