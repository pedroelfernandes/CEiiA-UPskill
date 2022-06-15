using MainAPI.DTO;
using MainAPI.Models;

namespace MainAPI.Services.Interfaces
{
    public interface IAPIUserService
    {
        Task<APIUserDTO> Create(APIUser apiUser);


        Task<List<APIUserDTO>> Get();


        Task<APIUserDTO> Get(int id);


        Task<APIUserDTO> Edit(APIUser apiUser);


        Task<bool> ChangeState(int id);
    }
}
