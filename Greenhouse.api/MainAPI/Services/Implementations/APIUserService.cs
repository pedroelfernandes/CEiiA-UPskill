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


        public async Task<APIUserDTO> Create(APIUser apiUser) =>
            APIUserDTO.ToDto(await _apiUserRepository.Create(apiUser));


        public async Task<List<APIUserDTO>> Get() =>
            (await _apiUserRepository.Get()).Select(user => APIUserDTO.ToDto(user)).ToList();


        public async Task<APIUserDTO> Get(int id) =>
            APIUserDTO.ToDto(await _apiUserRepository.Get(id));


        public async Task<bool> ChangeState(int id) =>
            await _apiUserRepository.ChangeState(id);


        public async Task<APIUserDTO> Edit(APIUser apiUser) =>
            APIUserDTO.ToDto(await _apiUserRepository.Edit(apiUser));


        public async Task<string> Login(string username, string password)
        {
            bool authorized = await _apiUserRepository.Authorized(username, password);

            if (authorized)
                return _jwtToken.GenerateJwtToken(username);

            return string.Empty;
        }
    }
}
