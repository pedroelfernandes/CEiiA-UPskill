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
            APIUserDTO userDTO = new APIUserDTO();
            userDTO.Username = apiUser.Username;

            await _apiUserRepository.Create(apiUser);
            return userDTO;
        }

        public async Task<APIUserDTO> Get(int id)
        {
            APIUser user = await _apiUserRepository.Get(id);
            return APIUserDTO.ToDto(user);
        }

        public async Task<bool> Delete(int id)
        {
            return await _apiUserRepository.Delete(id);
        }

        public async Task<APIUserDTO> Edit(APIUser apiUser)
        {

            APIUser user = await _apiUserRepository.Edit(apiUser);

            return APIUserDTO.ToDto(user);
        }
    }
}
