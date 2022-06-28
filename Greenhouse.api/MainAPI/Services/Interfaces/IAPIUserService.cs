using MainAPI.DTO;
using MainAPI.Models;

namespace MainAPI.Services.Interfaces
{
    public interface IAPIUserService
    {
        Task<APIUserDTO> Create(APIUserDTO apiUserDTO, string password);


        Task<List<APIUserDTO>> Get();


        Task<APIUserDTO> Get(int id);


        Task<APIUserDTO> Edit(APIUserDTO apiUserDTO, string? oldPassword, string? newPassword);


        Task<bool> ChangeState(int id);


        Task<List<string>> Login(string username, string password);
    }
}
