using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingEvaluationSystem.DB.Entitys
{
    public class Subject : BaseEntity
    {
        public Subject()
        {
            Questions = new List<QuestionBank>();
        }
        public string? Name { get; set; }
        public virtual List<QuestionBank> Questions { get; set; }
        [NotMapped]
        public bool Check { get; set; }
    }
}
