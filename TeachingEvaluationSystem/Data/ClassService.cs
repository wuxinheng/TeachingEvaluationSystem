using Microsoft.EntityFrameworkCore;
using TeachingEvaluationSystem.DB;

namespace TeachingEvaluationSystem.Data
{
    public class ClassService
    {
        private readonly TeachingEvaluationSystemDB _dbContext;
        private readonly GlobalInfo _globalInfo;
        public ClassService(TeachingEvaluationSystemDB dbContext, GlobalInfo globalInfo)
        {
            _dbContext = dbContext;
            _globalInfo = globalInfo;
        }

        public Task<Comom.Page<TeachingEvaluationSystem.DB.Entitys.Class>> GetPage(int index, int size)
        {
            var classes = _dbContext.Set<DB.Entitys.Class>().ToList().Take(size).Skip((index - 1) * size).ToList();
            Comom.Page<DB.Entitys.Class> page = new Comom.Page<DB.Entitys.Class>()
            {
                Index = index,
                Data = classes,
                Size = size,
                Total = _dbContext.Classes.Count(),
                TotalPgae = (int)Math.Ceiling(Convert.ToDouble(_dbContext.Classes.Count()) / size),
            };
            return Task.FromResult(page);
        }

        public async Task<DB.Entitys.Class> Get(int id)
        {
            var classes = await _dbContext.Set<DB.Entitys.Class>().FirstOrDefaultAsync(x => x.Id == id);
            return classes;
        }

        public async Task<bool> Detele(DB.Entitys.Class @class)
        {
            _dbContext.Set<DB.Entitys.Class>().Remove(@class);
            var count = await _dbContext.SaveChangesAsync();
            return count > 0;
        }

        public async Task<bool> Save(DB.Entitys.Class @class)
        {
            var dbclass = await _dbContext.Set<DB.Entitys.Class>().FirstOrDefaultAsync(x => x.Id == @class.Id);
            if (dbclass == null)
            {
                dbclass = @class;
                await _dbContext.Set<DB.Entitys.Class>().AddAsync(dbclass);
            }
            else
            {
                _dbContext.Set<DB.Entitys.Class>().Update(@class);
            }
            var count = await _dbContext.SaveChangesAsync();
            return count > 0;
        }
    }
}
