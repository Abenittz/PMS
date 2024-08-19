using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yapms.Dtos.Tasks
{
    public class UpdateTaskDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Title must not be over 50 characters")]
        public required string Title { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Description must not be below 3 characters")]
        public required string Description { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DueDate { get; set; }
    }
}