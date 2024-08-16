using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAll(){
            var users = _context.Users.ToList();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id){
            var users = _context.Users.Find(id);

            if (users==null){
                return NotFound();
            }

            return Ok(users);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUsersRequestdto userDto){
            var user = userDto.ToUserFromCreateDto();
            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = user.ID}, user.ToUserDto());
        }
    }
}