using SecureWave.Models;
using SecureWaveAPI.Models.DTOs;
using SecureWaveAPI.Repositories.Interfaces;
using SecureWaveAPI.Services.Interfaces;

namespace SecureWaveAPI.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<RoleDTO>> GetAllRolesAsync()
        {
            var roles = await _roleRepository.GetAllRolesAsync();
            return roles.Select(r => new RoleDTO
            {
                RoleId = r.RoleId,
                RoleName = r.RoleName,
                Description = r.Description
            });
        }

        public async Task<RoleDTO> GetRoleByIdAsync(Guid id)
        {
            var role = await _roleRepository.GetRoleByIdAsync(id);
            if (role == null)
            {
                throw new KeyNotFoundException($"Role with ID {id} not found.");
            }
            return new RoleDTO
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                Description = role.Description
            };
        }

        public async Task<RoleDTO> CreateRoleAsync(RoleDTO roleDto)
        {
            var role = new Role
            {
                RoleName = roleDto.RoleName,
                Description = roleDto.Description
            };

            await _roleRepository.AddRoleAsync(role);
            roleDto.RoleId = role.RoleId;
            return roleDto;
        }

        public async Task UpdateRoleAsync(RoleDTO roleDto)
        {
            var role = await _roleRepository.GetRoleByIdAsync(roleDto.RoleId);
            if (role != null)
            {
                role.RoleName = roleDto.RoleName;
                role.Description = roleDto.Description;
                await _roleRepository.UpdateRoleAsync(role);
            }
        }

        public async Task DeleteRoleAsync(Guid id)
        {
            await _roleRepository.DeleteRoleAsync(id);
        }
    }
}
