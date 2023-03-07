using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingEvaluationSystem.DB.Entitys
{
    public class OptionBank : BaseEntity
    {
        [Required] public string? Content { get; set; }
        public QuestionBank? QuestionBank { get; set; }
        [Required] public double Weight { get; set; }

    }
}
