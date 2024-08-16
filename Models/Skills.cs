using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yapms.Models
{
    public class Skills
    {
         public int ID { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}