using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingEvaluationSystem.DB.Entitys
{
    [Table("Subjects")]
    public class Subject : BaseEntity
    {
        public Subject()
        {
            Questions = new List<QuestionBankSubject>();
        }
        public string? Name { get; set; }
        public virtual List<QuestionBankSubject>? Questions { get; set; }
        public int GrossScore { get; set; }
        [NotMapped]
        public bool Check { get; set; }
        public int? UserClassId { get; set; }
        public UserClass? UserClasses { get; set; }
        
    }
}
