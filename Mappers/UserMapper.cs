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
        public static UserDto ToUserDto(this Users userModel)
        {
            return new UserDto
            {
                ID = userModel.ID,
                Firstname = userModel.Firstname,
                Lastname = userModel.Lastname,
                Password = userModel.Password,
                Email = userModel.Email,
                Username = userModel.Username,
                ProfilePicture = userModel.ProfilePicture,
                PhoneNo = userModel.PhoneNo,
                SkillSet = userModel.SkillSet
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