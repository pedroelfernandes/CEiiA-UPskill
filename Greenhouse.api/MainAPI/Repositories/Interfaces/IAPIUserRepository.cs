using MainAPI.Data;
using MainAPI.Models;

namespace MainAPI.Repositories.Interfaces
{
    public interface IAPIUserRepository
    {
        public Task<APIUser> Create(APIUser apiUser);


        public Task<List<APIUser>> Get();


        public Task<APIUser> Get(int id);


        public Task<APIUser> Edit(APIUser apiUser, string? oldPassword, string? newPassword);


        public Task<bool> ChangeState(int id);


        public Task<bool> Authorized(string username, string password);
    }
}
