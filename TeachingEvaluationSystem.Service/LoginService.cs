using Microsoft.EntityFrameworkCore;

using TeachingEvaluationSystem.DB;
using TeachingEvaluationSystem.DB.Entitys;
using TeachingEvaluationSystem.Service.Global;

namespace TeachingEvaluationSystem.Service
{
    public class LoginService
    {
        private readonly TeachingEvaluationSystemDB _dbContext;
        private readonly GlobalInfo _globalInfo;
        public LoginService(TeachingEvaluationSystemDB dbContext, GlobalInfo globalInfo)
        {
            _dbContext = dbContext;
            _globalInfo = globalInfo;
        }

        public Task<bool> Login(User currUser)
        {
            try
            {
                
                var user = _dbContext.Set<User>().FirstOrDefault(x => x.Name == currUser.Name && x.Password == currUser.Password);
                
                if (user == null)
                {
                    return Task.FromResult(false);
                }
                user.Class = _dbContext.Classes.FirstOrDefault(x => x.Id == user.ClassId);
                _globalInfo.User = user;
                return Task.FromResult(true);
            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
