using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingEvaluationSystem.DB.Entitys
{
    public class Role
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Menu>? Menus { get; set; }
        public List<User>? Users { get; set; }
        public List<QuestionBank>? QuestionBanks { get; set; }
    }
}
