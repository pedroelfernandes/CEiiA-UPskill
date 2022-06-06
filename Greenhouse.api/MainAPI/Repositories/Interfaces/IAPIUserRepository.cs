using MainAPI.Data;
using MainAPI.Models;

namespace MainAPI.Repositories.Interfaces
{
    public interface IAPIUserRepository
    {
        public Task<APIUser> Create(APIUser apiUser);

        public Task<APIUser> Get(int id);

        public Task<APIUser> Edit(int id, string username, string email, int roleId);

        public Task<bool> ChangeState(int id);
    }
}
