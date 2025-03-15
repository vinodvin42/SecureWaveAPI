using SecureWaveAPI.Models.DTOs;

namespace SecureWaveAPI.Services.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDTO>> GetAllRolesAsync();
        Task<RoleDTO> GetRoleByIdAsync(Guid id);
        Task<RoleDTO> CreateRoleAsync(RoleDTO roleDto);
        Task UpdateRoleAsync(RoleDTO roleDto);
        Task DeleteRoleAsync(Guid id);
    }
}
