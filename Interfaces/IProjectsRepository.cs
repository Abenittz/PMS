using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yapms.Dtos.Project;
using yapms.Models;

namespace yapms.Interfaces
{
    public interface IProjectsRepository
    {
        Task<List<Projects>> GetAllAsync();
        Task<Projects?> GetByIdAsync(int id);
        Task<Projects> CreateAsync(Projects project);
        Task<Projects?> UpdateAsync(int id, UpdateProjectsDto project);
        Task<Projects?> DeleteAsync(int id);
    }
}