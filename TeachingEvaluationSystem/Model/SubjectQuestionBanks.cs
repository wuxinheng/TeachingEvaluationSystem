using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TeachingEvaluationSystem.DB.Entitys;

namespace TeachingEvaluationSystem.Model
{
    public class SubjectQuestionBank
    {
        public SubjectQuestionBank()
        {
            OptionBanks = new List<OptionBank>();
            QuestionType = new QuestionType();
            QuestionBank = new QuestionBank();
            Code = Guid.NewGuid();
        }
        public int Sequence { get; set; }
        public string Title { get; set; }
        public int Score { get; set; }
        public QuestionBank QuestionBank { get; set; }
        public QuestionType QuestionType { get; set; }
        public List<OptionBank> OptionBanks { get; set; }
        public Guid Code { get; set; }
    }
}
