using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yapms.Dtos.Project
{
    public class CreateProjectRequestDto
    {
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
    }
}