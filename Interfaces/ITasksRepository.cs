using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yapms.Dtos.Tasks;
using yapms.Models;

namespace yapms.Interfaces
{
    public interface ITasksRepository
    {
        Task<List<Tasks>> GetAllAsync();
        Task<Tasks?> GetByIdAsync(int id);
        Task<Tasks> CreateAsync(Tasks createDto);
        Task<Tasks?> UpdateAsync(UpdateTaskDto updateDto, int id);
        Task<Tasks?> DeleteAsync(int id);
    }
}