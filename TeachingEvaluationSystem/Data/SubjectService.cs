using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TeachingEvaluationSystem.DB;
using TeachingEvaluationSystem.DB.Entitys;

namespace TeachingEvaluationSystem.Data
{
    public class SubjectService : BaseService<Subject>
    {
        public SubjectService(TeachingEvaluationSystemDB dbContext, GlobalInfo globalInfo) : base(dbContext, globalInfo)
        {
        }
    }
}
