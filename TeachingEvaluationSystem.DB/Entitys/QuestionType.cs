using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingEvaluationSystem.DB.Entitys
{
    public class QuestionType : BaseEntity
    {
        public string? Name { get; set; }
        [Required] public double? Weight { get; set; }
    }
}
