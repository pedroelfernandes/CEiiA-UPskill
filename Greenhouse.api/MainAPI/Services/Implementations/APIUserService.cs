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
        private readonly IRoleService _roleService;

        public APIUserService(IAPIUserRepository apiUserRepository, IRoleService roleService)
        {
            _apiUserRepository = apiUserRepository;
            _roleService = roleService;
        }


        public async Task<APIUserDTO> Create(APIUser apiUser)
        {
            APIUserDTO tempUser = APIUserDTO.ToDto(await _apiUserRepository.Create(apiUser));

            //tempUser.Role = await _roleService.GetRole(tempUser.RoleId);

            return tempUser;
        }


        public async Task<List<APIUserDTO>> Get() =>
            (await _apiUserRepository.Get()).Select(user => APIUserDTO.ToDto(user)).ToList();


        public async Task<APIUserDTO> Get(int id) =>
            APIUserDTO.ToDto(await _apiUserRepository.Get(id));


        public async Task<bool> ChangeState(int id)
        {
            return await _apiUserRepository.ChangeState(id);
        }


        public async Task<APIUserDTO> Edit(APIUser apiUser)
        {
            APIUserDTO tempUser = APIUserDTO.ToDto(await _apiUserRepository.Edit(apiUser));

            //tempUser.Role = await _roleService.GetRole(tempUser.RoleId);

            return tempUser;
        }
    }
}
