using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TeachingEvaluationSystem.DB;
using TeachingEvaluationSystem.DB.Entitys;
using TeachingEvaluationSystem.Model;

namespace TeachingEvaluationSystem.Data
{
    public class UserClassesService
    {
        private readonly TeachingEvaluationSystemDB _dbContext;

        public UserClassesService(TeachingEvaluationSystemDB dbContext, GlobalInfo globalInfo)
        {
            _dbContext = dbContext;
            _globalInfo = globalInfo;
        }

        private readonly GlobalInfo _globalInfo;


        public async Task<List<User>> GetUsers(int classId)
        {
            var users = await _dbContext.Set<UserClass>().Where(x => x.ClassesId == classId).Select(x => x.User).ToListAsync();
            return users;
        }

        public Task<UserClass> Get(int id)
        {
            try
            {

                var result = new UserClass();
                result = _dbContext.UserClasses?.FirstOrDefault(x => x.Id == id) ?? new();
                return Task.FromResult(result);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<bool> Save(UserClass t)
        {
            var dbt = _dbContext.Set<UserClass>().FirstOrDefault(x => x.Id == t.Id);
            if (dbt == null)
            {
                dbt = t;
                await _dbContext.Set<UserClass>().AddAsync(dbt);
            }
            else
            {
                _dbContext.Set<UserClass>().Update(t);
            }
            var count = await _dbContext.SaveChangesAsync();
            return count > 0;
        }


        public List<ClassTeacherSubject> GetClassTeacherSubjects(User user)
        {
            var result = _dbContext.UserClasses.Where(x => x.ClassesId == user.ClassId)
                  .Join(_dbContext.Users, uc => uc.UserId, u => u.Id, (uc, u) => new { uc.ClassesId, uc.Id, UserName = u.Name, UserId = u.Id })
                  .Join(_dbContext.Classes, uc => uc.ClassesId, c => c.Id, (uc, c) => new { ClassName = c.Name, ClassId = c.Id, uc.Id, uc.UserName, uc.UserId })
                  .Join(_dbContext.Subjects, uc => uc.Id, s => s.UserClassId, (uc, s) => new ClassTeacherSubject()
                  {
                      SubjectId = s.Id,
                      SubjectName = s.Name,
                      ClassId = uc.ClassId,
                      ClassName = uc.ClassName,
                      IsClose = false,
                      UserId = uc.UserId,
                      UserName = uc.UserName,
                  }).ToList();

            var yearMonth = DateTime.Now.ToString("yyyy-MM");
            var userAnswers = _dbContext.UserAnswers.Where(x => x.YearMonth == yearMonth).ToList();

            foreach (var item in result)
            {
                var Score = userAnswers.FirstOrDefault(x => x.TeacherId == item.UserId && x.SubjectId == item.SubjectId && x.ClassId == item.ClassId)?.Scores;
                item.Score = Score??-1;
                if (Score >= 0)
                {
                    item.IsClose = true;
                }
            }

            return result;
        }
    }



}
