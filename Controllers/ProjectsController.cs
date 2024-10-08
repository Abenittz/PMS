using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yapms.Data;
using yapms.Dtos.Project;
using yapms.Interfaces;
using yapms.Mappers;

namespace yapms.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsRepository _projectRepo;
        private readonly ApplicationDBContext _context;
        public ProjectsController(ApplicationDBContext context, IProjectsRepository projectRepo)
        {
            _context = context;
            _projectRepo = projectRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var projects = await _projectRepo.GetAllAsync();
            var userDto = projects.Select(s => s.ToProjectDto());

            return Ok(projects);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var projects = await _projectRepo.GetByIdAsync(id);

            if (projects == null)
            {
                return NotFound();
            };

            return Ok(projects);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProjectRequestDto projectDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var project = projectDto.ToProjectFromProjectDto();
            await _projectRepo.CreateAsync(project);

            return CreatedAtAction(nameof(GetById), new { ID = project.ID }, project.ToProjectDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProjectsDto projectsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingProject = await _projectRepo.UpdateAsync(id, projectsDto);

            if (existingProject == null)
            {
                Console.WriteLine("i am null");
                return NotFound();
            };

            return Ok(existingProject);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var project = await _projectRepo.DeleteAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}