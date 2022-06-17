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

        public async Task<RoleDTO> Create(Role role)
        {
            Role tempRole = await _roleRepository.Create(role);
            return RoleDTO.ToDto(tempRole);
        }

        public async Task<List<RoleDTO>> Get()
        {
            List<Role> roles = await _roleRepository.Get();

            return roles.Select(u => RoleDTO.ToDto(u)).ToList();
        }

        public async Task<RoleDTO> GetRoleById(int id)
        {
            Role tempRole = await _roleRepository.GetRoleById(id);
            return RoleDTO.ToDto(tempRole);
        }

        public async Task<bool> ChangeState(int id)
        {
            return await _roleRepository.ChangeState(id);
        }

        public async Task<RoleDTO> Edit(Role role)
        {

            Role tempRole = await _roleRepository.Edit(role);

            return RoleDTO.ToDto(tempRole);
        }
    }
}
