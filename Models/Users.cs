using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace yapms.Models
{
    [Table("Users")]
    public class Users
    {
         public int ID { get; set; } 
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string PhoneNo { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string ProfilePicture { get; set; } = string.Empty;
        public string SkillSet { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<UserSkills> UserSkills { get; set; } = new List<UserSkills>();
    }
}