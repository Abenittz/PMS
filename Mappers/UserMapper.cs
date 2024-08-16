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
        public static Users creatUsersReqestdto(this CreateUsersRequestdto usersDto)
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