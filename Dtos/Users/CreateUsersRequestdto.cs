using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yapms.Dtos.Users
{
    public class CreateUsersRequestdto
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string PhoneNo { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string ProfilePicture { get; set; } = string.Empty;
        public string SkillSet { get; set; } = string.Empty;
    }
}