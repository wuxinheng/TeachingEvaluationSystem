using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TeachingEvaluationSystem.DB;
using TeachingEvaluationSystem.DB.Entitys;

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
            var dbt = await _dbContext.Set<UserClass>().FirstOrDefaultAsync(x => x.Id == t.Id);
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
    }



}
