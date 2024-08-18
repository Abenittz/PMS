using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace yapms.Models
{
    public class Tasks
    {
        public int ID { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; }
        public int? ProjectsID { get; set; }
        public Projects? Projects { get; set; }
        
    }
}