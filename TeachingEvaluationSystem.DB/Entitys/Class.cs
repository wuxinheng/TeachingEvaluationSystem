using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingEvaluationSystem.DB.Entitys
{
    public class Class
    {
        public Class()
        {
            Teachers = new List<UserClass>();
            Students = new List<User>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual List<UserClass> Teachers { get; set; }
        public virtual List<User> Students { get; set; }
    }
}
