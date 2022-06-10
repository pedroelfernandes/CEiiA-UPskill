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
            APIUser tempUser = await _apiUserRepository.Create(apiUser);
            return APIUserDTO.ToDto(tempUser);
        }

        public async Task<List<APIUserDTO>> Get()
        {
            List<APIUser> users = await _apiUserRepository.Get();

            foreach (APIUser user in users)
            {
                user.Role = await _roleService.GetRole(user.RoleId);
            }

            return users.Select(u => APIUserDTO.ToDto(u)).ToList();
        }

        public async Task<bool> ChangeState(int id)
        {
            return await _apiUserRepository.ChangeState(id);
        }

        public async Task<APIUserDTO> Edit(APIUser apiUser)
        {

            APIUser tempUser = await _apiUserRepository.Edit(apiUser);

            return APIUserDTO.ToDto(tempUser);
        }
    }
}
