using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingEvaluationSystem.DB.Entitys
{
    public class UserAnswer : BaseEntity
    {
        public UserAnswer()
        {
            User = new User();
            OptionBank = new OptionBank();
            QuestionBank = new QuestionBank();
        }
        public User User { get; set; }
        public OptionBank OptionBank { get; set; }
        public QuestionBank QuestionBank { get; set; }
        public int QuestionScores { get; set; }
        public int OptionScores { get; set; }
    }
}
