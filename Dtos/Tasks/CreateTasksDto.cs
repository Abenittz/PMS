using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yapms.Dtos.Tasks
{
    public class CreateTasksDto
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}