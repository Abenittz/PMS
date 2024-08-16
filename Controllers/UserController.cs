using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yapms.Data;
using yapms.Dtos.Users;
using yapms.Mappers;

namespace yapms.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public UserController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var user = await _context.Users.ToListAsync();
            
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var users = await _context.Users.FindAsync(id);

            if (users==null){
                return NotFound();
            }

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUsersRequestdto userDto){
            var user = userDto.ToUserFromCreateDto();
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = user.ID}, user.ToUserDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateUsersRequestdto updateDto){
            var user = await _context.Users.FirstOrDefaultAsync(x => x.ID == id);

            if (user==null){
                return NotFound();
            }

            user.Username = updateDto.Username;
            user.Email = updateDto.Email;
            user.Firstname = updateDto.Firstname;
            user.Lastname = updateDto.Lastname;
            user.Password = updateDto.Password; 
            user.PhoneNo = updateDto.PhoneNo;
            user.ProfilePicture = updateDto.ProfilePicture;
            user.SkillSet = updateDto.SkillSet;

            await _context.SaveChangesAsync();
            return Ok(user);

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var user = await _context.Users.FirstOrDefaultAsync(x => x.ID==id);
            if (user==null){
                return NotFound();
            }

             _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}