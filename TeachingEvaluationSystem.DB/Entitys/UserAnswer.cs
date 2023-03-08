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
            AnswerDetails = new List<UserAnswerDetail>();
        }
        public int StudentId { get; set; }
        public User Teacher { get; set; }
        public int TeacherId { get; set; }
        public Subject Subject { get; set; }
        public int SubjectId { get; set; }
        public Class Class { get; set; }
        public int ClassId { get; set; }
        public int Scores { get; set; }
        public string YearMonth { get; set; }
        public List<UserAnswerDetail> AnswerDetails { get; set; }
    }
}
