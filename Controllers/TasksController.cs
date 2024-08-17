using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yapms.Data;
using yapms.Dtos.Tasks;
using yapms.Mappers;

namespace yapms.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public TasksController(ApplicationDBContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var tasks = await _context.Tasks.ToListAsync();
            var tasksDto = tasks.Select(t => t.ToTasksDto());

            return Ok(tasks);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id){
            var tasks = await _context.Tasks.FirstOrDefaultAsync(x => x.ID == id);

            if(tasks == null){
                return NotFound();
            }

            return Ok(tasks.ToTasksDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTasksDto taskDto){
            var tasks = taskDto.ToTaskFromTaskDto();
            await _context.Tasks.AddAsync(tasks);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = tasks.ID}, tasks.ToTasksDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateTaskDto updateDto, [FromRoute] int id){
            var existingTask = await _context.Tasks.FirstOrDefaultAsync(x => x.ID == id);
            Console.WriteLine(id);

            if (existingTask == null){
                return NotFound();
            }

            existingTask.Title = updateDto.Title;
            existingTask.Description = updateDto.Description;
            existingTask.CreatedDate = updateDto.CreatedDate;
            existingTask.DueDate = updateDto.DueDate; 

            await _context.SaveChangesAsync();
            return Ok(existingTask.ToTasksDto());  
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var existingTask = await _context.Tasks.FirstOrDefaultAsync(x => x.ID == id);
            if (existingTask == null){
                return NotFound();
            }

            _context.Remove(existingTask);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}