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
            RoleDTO roleDTO = new RoleDTO();
            roleDTO.Name = role.Name;

            await _roleRepository.Create(role);
            return roleDTO;
        }

        public async Task<RoleDTO> Get(int id)
        {
            Role roleDto = await _roleRepository.Get(id);
            return RoleDTO.ToDto(roleDto);
        }

        public async Task<bool> Delete(int id)
        {
            return await _roleRepository.Delete(id);
        }

        public async Task<RoleDTO> Edit(Role role)
        {

            Role roleDto = await _roleRepository.Edit(role);

            return RoleDTO.ToDto(roleDto);
        }
    }
}
