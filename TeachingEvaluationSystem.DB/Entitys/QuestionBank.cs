using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingEvaluationSystem.DB.Entitys
{
    public class QuestionBank
    {
        public int Id { get; set; }
        public string? Tile { get; set; }
        public string? Type { get; set; }
        public List<OptionBank>? OptionBanks { get; set; }

    }
}
