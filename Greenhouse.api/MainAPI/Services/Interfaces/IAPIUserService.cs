using MainAPI.DTO;
using MainAPI.Models;

namespace MainAPI.Services.Interfaces
{
    public interface IAPIUserService
    {
        Task<APIUserDTO> Create(APIUser apiUser);

        Task<APIUserDTO> Get(int id);

        Task<APIUserDTO> Edit(APIUser apiUser);

        Task<bool> Delete(int id);
    }
}
