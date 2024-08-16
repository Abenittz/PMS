using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yapms.Models
{
    public class UserSkills
    {
         public int ID { get; set; }
        public required int UserID { get; set; }
        public required int SkillID { get; set; }
        
        public Skills? Skills { get; set; }
        public Users? Users {get; set;}

    }
}