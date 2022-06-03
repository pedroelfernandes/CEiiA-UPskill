using MainAPI.DTO;
using MainAPI.Models;

namespace MainAPI.Services.Interfaces
{
    public interface IAPIUserService
    {
        Task<APIUserDTO> Create(APIUser apiUser);

        Task<APIUserDTO> Get(int id);

        Task<APIUserDTO> Edit(int id, string username, string email, int roleId);

        Task<bool> ChangeState(int id);
    }
}
