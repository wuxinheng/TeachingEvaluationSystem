using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingEvaluationSystem.DB.Entitys
{
    public class QuestionBankSubject : BaseEntity
    {
        public QuestionBankSubject()
        {
            Subject = new Subject();
            QuestionBank = new QuestionBank();
        }
        public Subject Subject { get; set; }
        public QuestionBank QuestionBank { get; set; }
        public int Score { get; set; }
    }
}
