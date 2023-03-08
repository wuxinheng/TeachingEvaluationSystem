using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TeachingEvaluationSystem.DB;
using TeachingEvaluationSystem.DB.Entitys;

namespace TeachingEvaluationSystem.Data
{
    public class UserAnswerService : BaseService<UserAnswer>
    {
        public UserAnswerService(TeachingEvaluationSystemDB dbContext, GlobalInfo globalInfo) : base(dbContext, globalInfo)
        {
        }

        public Task<UserAnswer> Get(int studentId, int classId, int subjectId, int teacherId)
        {
            try
            {
                var users = _dbContext.Set<UserAnswer>().FirstOrDefault(x => x.ClassId == classId && x.StudentId == studentId && x.SubjectId == subjectId && x.TeacherId == teacherId);
                return Task.FromResult(users);
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
