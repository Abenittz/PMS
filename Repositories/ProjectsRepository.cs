using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yapms.Data;
using yapms.Dtos.Project;
using yapms.Interfaces;
using yapms.Models;

namespace yapms.Repositories
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly ApplicationDBContext _context;
        public ProjectsRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Projects> CreateAsync(Projects projects)
        {
            await _context.Projects.AddAsync(projects);
            await _context.SaveChangesAsync();
            return projects;
        }

        public async Task<Projects?> DeleteAsync(int id)
        {
            var existingProject = await _context.Projects.FirstOrDefaultAsync(x => x.ID == id);
           Console.WriteLine(id);
            if (existingProject == null){
                Console.WriteLine("hello i am null");
                 
                return null;
            }

            _context.Remove(existingProject);
            await _context.SaveChangesAsync();
            return existingProject;
        }

        public async Task<List<Projects>> GetAllAsync()
        {
            return await _context.Projects.Include(p => p.Tasks).ToListAsync();
        }

        public async Task<Projects?> GetByIdAsync(int id)
        {
           return await _context.Projects.Include(p => p.Tasks).FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<bool> ProjectExists(int id)
        {
            return await _context.Projects.AnyAsync(x => x.ID == id);
        }

        public async Task<Projects?> UpdateAsync( int id, UpdateProjectsDto projectsDto)
        {
            var existingProject = await _context.Projects.FirstOrDefaultAsync(x => x.ID == id);

            if (existingProject == null){
                return null;
            }
            existingProject.Name = projectsDto.Name;
            existingProject.Description = projectsDto.Description;
            existingProject.StartDate = projectsDto.StartDate;
            existingProject.EndDate = projectsDto.EndDate;

            await _context.SaveChangesAsync();
            return existingProject;
            
        }
    }
}