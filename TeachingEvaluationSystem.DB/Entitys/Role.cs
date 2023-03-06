using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingEvaluationSystem.DB.Entitys
{
    public class Role : BaseEntity
    {
        public Role()
        {
            Menus = new List<Menu>();
            Questions=new List<QuestionBank>();
        }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual List<Menu> Menus { get; set; }
        public virtual List<QuestionBank> Questions { get; set; }
    }
}
