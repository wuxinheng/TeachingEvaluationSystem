using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingEvaluationSystem.DB.Entitys
{
    public class OptionBank
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public QuestionBank? QuestionBank { get; set; }
        public decimal Weight { get; set; }

    }
}
