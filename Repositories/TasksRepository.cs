using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using yapms.Data;
using yapms.Dtos.Tasks;
using yapms.Interfaces;
using yapms.Models;

namespace yapms.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly ApplicationDBContext _context;
        public TasksRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Tasks> CreateAsync(Tasks createDto)
        {
            await _context.Tasks.AddAsync(createDto);
            await _context.SaveChangesAsync();
            return createDto;
        }

        public async Task<Tasks?> DeleteAsync(int id)
        {
            var existingTask = await _context.Tasks.FirstOrDefaultAsync(x => x.ID == id);
            if (existingTask == null)
            {
                return null;
            }

            _context.Remove(existingTask);
            await _context.SaveChangesAsync();
            return existingTask;
        }

        public async Task<List<Tasks>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Tasks?> GetByIdAsync(int id)
        {
            var tasks = await _context.Tasks.FindAsync(id);

            if (tasks == null)
            {
                return null;
            }

            return tasks;
        }

        public async Task<Tasks?> UpdateAsync(UpdateTaskDto updateDto, int id)
        {
            var existingTask = await _context.Tasks.FindAsync(id);

            if (existingTask == null)
            {
                return null;
            }

            existingTask.Title = updateDto.Title;
            existingTask.Description = updateDto.Description;
           
            existingTask.DueDate = updateDto.DueDate;

            await _context.SaveChangesAsync();
            return existingTask;
        }


    }
}