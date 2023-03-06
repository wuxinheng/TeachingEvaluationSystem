using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            Code = Guid.NewGuid();
            Roles = new List<Role>();
        }
        public int Id { get; set; }
        [Required] public string? Tile { get; set; }
        public string? Type { get; set; }
        public virtual List<OptionBank> OptionBanks { get; set; }
        public virtual List<Role> Roles { get; set; }
        [NotMapped]
        public int Sequence { get; set; }
        [NotMapped]
        public Guid Code { get; set; }
        [NotMapped]
        public bool? Check { get; set; }
    }
}
