using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yapms.Data;
using yapms.Dtos.Tasks;
using yapms.Interfaces;
using yapms.Mappers;
using yapms.Migrations;


namespace yapms.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ITasksRepository _taskRepo;
        private readonly IProjectsRepository _projectsRepo;
        public TasksController(ApplicationDBContext context, ITasksRepository taskRepo, IProjectsRepository projectsRepo)
        {
            _context = context;
            _taskRepo = taskRepo;
            _projectsRepo = projectsRepo;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskRepo.GetAllAsync();
            var tasksDto = tasks.Select(t => t.ToTasksDto());

            return Ok(tasks);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tasks = await _context.Tasks.FindAsync(id);

            if (tasks == null)
            {
                return NotFound();
            }

            return Ok(tasks.ToTasksDto());
        }

        [HttpPost("{projectId}")]
        
        public async Task<IActionResult> Create( CreateTasksDto taskDto, [FromRoute] int projectId)
        {
            if (!await _projectsRepo.ProjectExists(projectId)){
                return BadRequest("the project doesn't exist");
            }

            var tasks = taskDto.ToTaskFromTaskDto(projectId);
            await _taskRepo.CreateAsync(tasks);

            return CreatedAtAction(nameof(GetById), new { id = tasks.ID }, tasks.ToTasksDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateTaskDto updateDto, [FromRoute] int id)
        {
            var existingTask = await _taskRepo.UpdateAsync(updateDto, id);

            if (existingTask == null)
            {
                return NotFound();
            }

            return Ok(existingTask.ToTasksDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var existingTask = await _taskRepo.DeleteAsync(id);
            if (existingTask == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}