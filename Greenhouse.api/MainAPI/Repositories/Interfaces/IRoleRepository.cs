using MainAPI.Models;

namespace MainAPI.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        public Task<Role> Create(Role role);

        public Task<List<Role>> Get();

        public Task<Role> GetRole(int id);    

        public Task<Role> Edit(Role role);

        public Task<bool> ChangeState(int id);
    }
}
