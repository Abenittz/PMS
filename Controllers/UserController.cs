using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yapms.Data;
using yapms.Dtos.Users;
using yapms.Interfaces;
using yapms.Mappers;

namespace yapms.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IUserRepository _userRepo;
        public UserController(ApplicationDBContext context, IUserRepository userRepo)
        {
            _context = context;
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var user = await _userRepo.GetAllAsync();
            var userDto = user.Select(s => s.ToUserDto());
            
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var users = await _userRepo.GetByIdAsync(id);

            if (users==null){
                return NotFound();
            }

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUsersRequestdto userDto){
            var user = userDto.ToUserFromCreateDto();
            await _userRepo.CreateAsync(user);
            return CreatedAtAction(nameof(GetById), new {id = user.ID}, user.ToUserDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUsersRequestdto updateDto){
            var user = await _userRepo.UpdateAsync(id, updateDto);

            if (user==null){
                return NotFound();
            }

            return Ok(user.ToUserDto());

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var user = await _userRepo.DeleteAsync(id);
            
            if (user==null){
                return NotFound();
            }

            return NoContent();

        }
    }
}