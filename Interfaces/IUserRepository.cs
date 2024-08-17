using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yapms.Dtos.Users;
using yapms.Models;

namespace yapms.Interfaces
{
    public interface IUserRepository
    {
        Task<List<Users>> GetAllAsync();
        Task<Users?> GetByIdAsync(int id);
        Task<Users> CreateAsync(Users user);
        Task<Users?> UpdateAsync(int id, UpdateUsersRequestdto userDto);
        Task<Users?> DeleteAsync(int id);
    }
}