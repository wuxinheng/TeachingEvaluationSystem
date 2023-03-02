using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingEvaluationSystem.DB.Entitys
{
    public class QuestionBank
    {
        public QuestionBank()
        {
            OptionBanks = new List<OptionBank>();
        }
        public int Id { get; set; }
        public string? Tile { get; set; }
        public string? Type { get; set; }
        public virtual List<OptionBank> OptionBanks { get; set; }

    }
}
