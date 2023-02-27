using Microsoft.EntityFrameworkCore;

using TeachingEvaluationSystem.DB;
using TeachingEvaluationSystem.DB.Entitys;

namespace TeachingEvaluationSystem.Data
{
    public class LoginService
    {
        private readonly TeachingEvaluationSystemDB _dbContext;

        public LoginService(TeachingEvaluationSystemDB dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Login(string userName, string password, string validateCode)
        {
            try
            {
                var user = await _dbContext.Set<User>().FirstOrDefaultAsync(x => x.Name == userName && x.Password == password);
                if (user == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {

                throw;
            }
           
        }
    }
}
