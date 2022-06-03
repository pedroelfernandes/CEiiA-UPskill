using MainAPI.Data;
using MainAPI.DTO;
using MainAPI.Models;
using MainAPI.Repositories.Interfaces;
using MainAPI.Services.Interfaces;

namespace MainAPI.Services.Implementations
{
    public class APIUserService : IAPIUserService
    {
        private readonly IAPIUserRepository _apiUserRepository;

        public APIUserService(IAPIUserRepository apiUserRepository)
        {
            _apiUserRepository = apiUserRepository;
        }

        public async Task<APIUserDTO> Create(APIUser apiUser)
        {
            APIUser tempUser = await _apiUserRepository.Create(apiUser);
            return APIUserDTO.ToDto(tempUser);
        }

        public async Task<APIUserDTO> Get(int id)
        {
            APIUser user = await _apiUserRepository.Get(id);
            return APIUserDTO.ToDto(user);
        }

        public async Task<bool> ChangeState(int id)
        {
            return await _apiUserRepository.ChangeState(id);
        }

        public async Task<APIUserDTO> Edit(int id, string username, string email, int roleId)
        {

            APIUser tempUser = await _apiUserRepository.Edit(id, username, email, roleId);

            return APIUserDTO.ToDto(tempUser);
        }
    }
}
