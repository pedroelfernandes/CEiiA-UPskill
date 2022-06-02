using MainAPI.Models;

namespace MainAPI.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        public Task<bool> Create(Role role);

        public Task<Role> Get(int id);

        public Task<Role> Edit(Role role);

        public Task<bool> Delete(int id);
    }
}
