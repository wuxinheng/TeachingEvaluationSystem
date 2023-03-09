using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingEvaluationSystem.Service.Model
{
    public class ClassTeacherSubject
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public int Score { get; set; }
        public bool IsClose { get; set; }
    }
}
