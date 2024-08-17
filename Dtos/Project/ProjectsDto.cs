using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yapms.Dtos.Tasks;

namespace yapms.Dtos.Project
{
    public class ProjectsDto
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public List<TasksDto> Tasks { get; set; }
    }
}