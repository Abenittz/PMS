using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using yapms.Data;
using yapms.Dtos.Users;
using yapms.Interfaces;
using yapms.Models;

namespace yapms.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository(ApplicationDBContext context)
        {
            _context = context;   
        }

        public async Task<Users> CreateAsync(Users user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<Users?> DeleteAsync(int id)
        {
           var user = await _context.Users.FirstOrDefaultAsync(x => x.ID==id);
            if (user == null){
                return null;
            }

             _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<Users>> GetAllAsync()
        {
           return await _context.Users.ToListAsync();
        }

        public async Task<Users?> GetByIdAsync(int id)
        {
           return await _context.Users.FindAsync(id);
        }

        public async Task<Users?> UpdateAsync(int id, UpdateUsersRequestdto userDto)
        {
             var currentUser = await _context.Users.FirstOrDefaultAsync(x => x.ID == id);

            if (currentUser==null){
                return null;
            }

            currentUser.Username = userDto.Username;
            currentUser.Email = userDto.Email;
            currentUser.Firstname = userDto.Firstname;
            currentUser.Lastname = userDto.Lastname;
            currentUser.Password = userDto.Password; 
            currentUser.PhoneNo = userDto.PhoneNo;
            currentUser.ProfilePicture = userDto.ProfilePicture;
            currentUser.SkillSet = userDto.SkillSet;

            await _context.SaveChangesAsync();
            return currentUser;
        }

       
    }
}