using MainAPI.Models;

namespace MainAPI.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        public Task<Role> Create(Role role);

        public Task<Role> Get(int id);

        public Task<Role> Edit(int id, string name, string description);

        public Task<bool> ChangeState(int id);
    }
}
