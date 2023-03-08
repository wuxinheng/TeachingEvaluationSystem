using Microsoft.EntityFrameworkCore;

using TeachingEvaluationSystem.DB;
using TeachingEvaluationSystem.DB.Entitys;

namespace TeachingEvaluationSystem.Data
{
    public class RoleService
    {
        private readonly TeachingEvaluationSystemDB _dbContext;
        private readonly GlobalInfo _globalInfo;
        public RoleService(TeachingEvaluationSystemDB dbContext, GlobalInfo globalInfo)
        {
            _dbContext = dbContext;
            _globalInfo = globalInfo;
        }

        public Task<Comom.Page<Role>> GetPage(int index, int size)
        {
            var roles = _dbContext.Set<Role>().ToList().Take(size).Skip((index - 1) * size).ToList();
            Comom.Page<Role> page = new Comom.Page<Role>()
            {
                Index = index,
                Data = roles,
                Size = size,
                Total = _dbContext.Roles.Count(),
                TotalPgae = (int)Math.Ceiling(Convert.ToDouble(_dbContext.Roles.Count()) / size),
            };
            return Task.FromResult(page);
        }

        public async Task<List<Role>> GetList()
        {
            var roles = await _dbContext.Set<Role>().ToListAsync();
            return roles;
        }

        public  Task<Role> Get(int id)
        {
            var roles = _dbContext.Set<Role>().FirstOrDefault(x => x.Id == id);

            return Task.FromResult(roles);
        }

        public async Task<bool> Detele(Role role)
        {
            _dbContext.Set<Role>().Remove(role);
            var count = await _dbContext.SaveChangesAsync();
            return count > 0;
        }

        public async Task<bool> Save(Role role)
        {
            var dbrole =  _dbContext.Set<Role>().FirstOrDefault(x => x.Id == role.Id);
            if (dbrole == null)
            {
                dbrole = role;
                await _dbContext.Set<Role>().AddAsync(dbrole);
            }
            else
            {
                _dbContext.Set<Role>().Update(role);
            }
            var count = await _dbContext.SaveChangesAsync();
            return count > 0;
        }
    }
}
