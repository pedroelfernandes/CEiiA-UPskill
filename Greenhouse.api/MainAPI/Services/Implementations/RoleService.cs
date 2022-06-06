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

        public async Task<RoleDTO> Get(int id)
        {
            Role tempRole = await _roleRepository.Get(id);
            return RoleDTO.ToDto(tempRole);
        }

        public async Task<bool> ChangeState(int id)
        {
            return await _roleRepository.ChangeState(id);
        }

        public async Task<RoleDTO> Edit(int id, string name, string description)
        {

            Role tempRole = await _roleRepository.Edit(id, name, description);

            return RoleDTO.ToDto(tempRole);
        }
    }
}
