using MainAPI.Data;
using MainAPI.Models;

namespace MainAPI.Repositories.Interfaces
{
    public interface IAPIUserRepository
    {
        public Task<bool> Create(APIUser apiUser);

        public Task<APIUser> Get(int id);

        public Task<APIUser> Edit(APIUser apiUser);

        public Task<bool> Delete(int id);
    }
}
