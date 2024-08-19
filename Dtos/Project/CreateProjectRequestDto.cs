using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yapms.Dtos.Project
{
    public class CreateProjectRequestDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name can't be over 100 characters")]
        public required string Name { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Must be atleat 3 characters")]
        public string Description { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } 
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}