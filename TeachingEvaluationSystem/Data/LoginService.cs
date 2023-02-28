using Microsoft.EntityFrameworkCore;

using TeachingEvaluationSystem.DB;
using TeachingEvaluationSystem.DB.Entitys;

namespace TeachingEvaluationSystem.Data
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

        public async Task<bool> Login(User currUser)
        {
            try
            {
                var user = await _dbContext.Set<User>().FirstOrDefaultAsync(x => x.Name == currUser.Name && x.Password == currUser.Password);
                if (user == null)
                {
                    return false;
                }
                _globalInfo.User=user;
                return true;
            }
            catch (Exception e)
            {

                throw;
            }
           
        }
    }
}
