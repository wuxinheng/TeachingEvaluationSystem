using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TeachingEvaluationSystem.DB.Entitys;
using TeachingEvaluationSystem.DB;
using Microsoft.EntityFrameworkCore;

namespace TeachingEvaluationSystem.Data
{
    public class MenuService
    {
        private readonly TeachingEvaluationSystemDB _dbContext;
        private readonly GlobalInfo _globalInfo;
        public MenuService(TeachingEvaluationSystemDB dbContext, GlobalInfo globalInfo)
        {
            _dbContext = dbContext;
            _globalInfo = globalInfo;
        }

        public Task<Comom.Page<Menu>> GetPage(int index, int size)
        {
            var menus = _dbContext.Set<Menu>().ToList().Take(size).Skip((index - 1) * size).ToList();
            Comom.Page<Menu> page = new Comom.Page<Menu>()
            {
                Index = index,
                Data = menus,
                Size = size,
                Total = _dbContext.Menus.Count(),
                TotalPgae = (int)Math.Ceiling(Convert.ToDouble(_dbContext.Menus.Count()) / size),
            };
            return Task.FromResult(page);
        }

        public async Task<List<Menu>> GetList()
        {
            var menus = await _dbContext.Set<Menu>().ToListAsync();
            return menus;
        }

        public Task<Menu> Get(int id)
        {
            var menus = _dbContext.Set<Menu>().FirstOrDefault(x => x.Id == id);

            return Task.FromResult(menus);
        }

        public async Task<bool> Detele(Menu role)
        {
            _dbContext.Set<Menu>().Remove(role);
            var count = await _dbContext.SaveChangesAsync();
            return count > 0;
        }

        public async Task<bool> Save(Menu role)
        {
            var dbrole =  _dbContext.Set<Menu>().FirstOrDefault(x => x.Id == role.Id);
            if (dbrole == null)
            {
                dbrole = role;
                await _dbContext.Set<Menu>().AddAsync(dbrole);
            }
            else
            {
                _dbContext.Set<Menu>().Update(role);
            }
            var count = await _dbContext.SaveChangesAsync();
            return count > 0;
        }
    }
}
