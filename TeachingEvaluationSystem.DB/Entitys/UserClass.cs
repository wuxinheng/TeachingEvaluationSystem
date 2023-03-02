using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingEvaluationSystem.DB.Entitys
{
    public class UserClass
    {
        public int Id { get; set; }
        public int? ClassesId { get; set; }
        public int? UserId { get; set; }

        public virtual Class? Classes { get; set; }
        public virtual User? User { get; set; }
    }
}
