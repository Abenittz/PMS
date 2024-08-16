using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yapms.Dtos.Users;
using yapms.Models;

namespace yapms.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this Users usreDto)
        {
            return new UserDto
            {
                ID = usreDto.ID,
                Firstname = usreDto.Firstname,
                Lastname = usreDto.Lastname,
                Password = usreDto.Password,
                Email = usreDto.Email,
                Username = usreDto.Username,
                ProfilePicture = usreDto.ProfilePicture,
                PhoneNo = usreDto.PhoneNo,
                SkillSet = usreDto.SkillSet
            };
        }
        public static Users ToUserFromCreateDto(this CreateUsersRequestdto usersDto)
        {
            return new Users
            {
                Firstname = usersDto.Firstname,
                Lastname = usersDto.Lastname,
                Password = usersDto.Password,
                Email = usersDto.Email,
                Username = usersDto.Username,
                ProfilePicture = usersDto.ProfilePicture,
                PhoneNo = usersDto.PhoneNo,
                SkillSet = usersDto.SkillSet
            };
        }
    }
}