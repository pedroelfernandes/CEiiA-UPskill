using MainAPI.DTO;
using MainAPI.Models;
using MainAPI.Repositories.Interfaces;
using MainAPI.Services.Interfaces;

namespace MainAPI.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;


        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }


        public async Task<RoleDTO> Create(Role role) =>
            RoleDTO.ToDto(await _roleRepository.Create(role));


        public async Task<List<RoleDTO>> Get() =>
            (await _roleRepository.Get()).Select(u => RoleDTO.ToDto(u)).ToList();


        public async Task<RoleDTO> GetRole(int id) =>
            RoleDTO.ToDto(await _roleRepository.GetRole(id));


        public async Task<RoleDTO> Edit(Role role) =>
            RoleDTO.ToDto(await _roleRepository.Edit(role));


        public async Task<bool> ChangeState(int id) =>
            await _roleRepository.ChangeState(id);
    }
}
