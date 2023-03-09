using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TeachingEvaluationSystem.DB;
using TeachingEvaluationSystem.DB.Entitys;
using TeachingEvaluationSystem.Service.Global;

namespace TeachingEvaluationSystem.Service.Base
{
    public class BaseService<T> where T : BaseEntity, new()

    {
        protected readonly TeachingEvaluationSystemDB _dbContext;
        protected readonly GlobalInfo _globalInfo;
        public BaseService(TeachingEvaluationSystemDB dbContext, GlobalInfo globalInfo)
        {
            _dbContext = dbContext;
            _globalInfo = globalInfo;
        }

        public Task<Comom.Page<T>> GetPage(int index, int size)
        {
            var users = _dbContext.Set<T>().ToList().Take(size).Skip((index - 1) * size).ToList();
            Comom.Page<T> page = new Comom.Page<T>()
            {
                Index = index,
                Data = users,
                Size = size,
                Total = _dbContext.Users.Count(),
                TotalPgae = (int)Math.Ceiling(Convert.ToDouble(_dbContext.Users.Count()) / size),
            };
            return Task.FromResult(page);
        }

        public async Task<List<T>> GetList()
        {
            var users = await _dbContext.Set<T>().ToListAsync();
            return users;
        }

        public Task<T> Get(int id)
        {
            try
            {
                var users = _dbContext.Set<T>().FirstOrDefault(x => x.Id == id);
                return Task.FromResult(users);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<bool> Detele(T t)
        {
            _dbContext.Set<T>().Remove(t);
            var count = await _dbContext.SaveChangesAsync();
            return count > 0;
        }

        public async Task<bool> Save(T t)
        {
            try
            {


                var dbt = await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == t.Id);
                if (dbt == null)
                {
                    dbt = t;
                    await _dbContext.Set<T>().AddAsync(dbt);
                }
                else
                {
                    _dbContext.Set<T>().Update(t);
                }
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
