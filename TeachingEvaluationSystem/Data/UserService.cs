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
    public class UserService
    {
        private readonly TeachingEvaluationSystemDB _dbContext;
        private readonly GlobalInfo _globalInfo;
        public UserService(TeachingEvaluationSystemDB dbContext, GlobalInfo globalInfo)
        {
            _dbContext = dbContext;
            _globalInfo = globalInfo;
        }

        public  Task<Comom.Page<User>> GetPage(int index, int size)
        {
            try
            {
                var users1 = _dbContext.Set<User>().Take(size).Skip((index - 1) * size).ToList();
                var users = _dbContext.Set<User>().ToList().Take(size).Skip((index-1)*size).ToList();
                Comom.Page<User> page = new Comom.Page<User>()
                {
                    Index = index,
                    Data = users,
                    Size = size,
                    Total = _dbContext.Users.Count(),
                    TotalPgae = _dbContext.Users.Count(),
                };
                return Task.FromResult(page);
            }
            catch (Exception e)
            {

                throw;
            }
        }

    }
}
