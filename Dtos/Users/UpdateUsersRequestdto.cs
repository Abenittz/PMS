using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yapms.Dtos.Users
{
    public class UpdateUsersRequestdto
    {
        [Required]
        [MaxLength(20, ErrorMessage = "username must not be greater than 20 characters")]
        [MinLength(2, ErrorMessage = "username must be atleast 2 characters")]
        public required string Username { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [MaxLength(100, ErrorMessage = "Email must not be greater than 100 characters.")]
        public required string Email { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        [Phone(ErrorMessage = "Invalid phone number format.")]
        [MaxLength(15, ErrorMessage = "Phone number must not be greater than 15 characters.")]
        public string PhoneNo { get; set; } = string.Empty;
       [MaxLength(50, ErrorMessage = "Firstname must not be greater than 50 characters.")]
        public string Firstname { get; set; } = string.Empty;

        [MaxLength(50, ErrorMessage = "Lastname must not be greater than 50 characters.")]
        public string Lastname { get; set; } = string.Empty;

        [Url(ErrorMessage = "Invalid URL format.")]
        public string ProfilePicture { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "SkillSet must not be greater than 500 characters.")]
        public string SkillSet { get; set; } = string.Empty;
    }
}