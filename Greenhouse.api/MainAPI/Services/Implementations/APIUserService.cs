using MainAPI.Data;
using MainAPI.DTO;
using MainAPI.Helpers.Interfaces;
using MainAPI.Models;
using MainAPI.Repositories.Interfaces;
using MainAPI.Services.Interfaces;

namespace MainAPI.Services.Implementations
{
    public class APIUserService : IAPIUserService
    {
        private readonly IAPIUserRepository _apiUserRepository;

        private readonly IRoleService _roleService;

        private readonly IJwtToken _jwtToken;


        public APIUserService(IAPIUserRepository apiUserRepository, IRoleService roleService, IJwtToken jwtToken)
        {
            _apiUserRepository = apiUserRepository;

            _roleService = roleService;

            _jwtToken = jwtToken;
        }


        public async Task<APIUserDTO> Create(APIUserDTO apiUserDTO, string password) =>
            APIUserDTO.ToDto(await _apiUserRepository.Create(new APIUser {Id = 0, Email = apiUserDTO.Email, Password = password,
                Username = apiUserDTO.Username, RoleId = apiUserDTO.RoleId}));


        public async Task<List<APIUserDTO>> Get() =>
            (await _apiUserRepository.Get()).Select(user => APIUserDTO.ToDto(user)).ToList();


        public async Task<APIUserDTO> Get(int id) =>
            APIUserDTO.ToDto(await _apiUserRepository.Get(id));


        public async Task<bool> ChangeState(int id) =>
            await _apiUserRepository.ChangeState(id);


        public async Task<APIUserDTO> Edit(APIUserDTO apiUserDTO, string? oldPassword, string? newPassword) =>
            APIUserDTO.ToDto(await _apiUserRepository.Edit(new APIUser
            {
                Id = apiUserDTO.Id,
                Email = apiUserDTO.Email,
                //Password = password,
                Username = apiUserDTO.Username,
                RoleId = apiUserDTO.RoleId,
                Role = new Role { Id = apiUserDTO.RoleId}
            }, oldPassword, newPassword));


        public async Task<List<string>> Login(string username, string password)
        {
            List<string> strings = new();

            APIUser apiUser = await _apiUserRepository.Authorized(username, password);

            string token = string.Empty, name = string.Empty, role = string.Empty;

            if (apiUser != null)
            {
                token = _jwtToken.GenerateJwtToken(username);
                name = apiUser.Username;
                role = apiUser.Role.Name;
            }
                
            strings.Add(name);
            strings.Add(role);
            strings.Add(token);

            return strings;
        }
    }
}
