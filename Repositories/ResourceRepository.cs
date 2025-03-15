using Microsoft.EntityFrameworkCore;
using SecureWave.Data;
using SecureWave.Models;
using SecureWaveAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureWaveAPI.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly SecureWaveDbContext _context;

        public ResourceRepository(SecureWaveDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Resource>> GetAllResourcesAsync()
        {
            return await _context.Resources.ToListAsync();
        }

        public async Task<Resource> GetResourceByIdAsync(Guid id)
        {
            return await _context.Resources.FindAsync(id);
        }

        public async Task AddResourceAsync(Resource resource)
        {
            _context.Resources.Add(resource);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateResourceAsync(Resource resource)
        {
            _context.Entry(resource).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteResourceAsync(Guid id)
        {
            var resource = await _context.Resources.FindAsync(id);
            if (resource != null)
            {
                _context.Resources.Remove(resource);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<string>> GetResourceTypesAsync()
        {
            return await Task.FromResult(Enum.GetNames(typeof(ResourceType)));
        }

        public async Task<IEnumerable<string>> GetResourceProtocolAsync()
        {
            return await Task.FromResult(Enum.GetNames(typeof(Protocol)));
        }
    }
}