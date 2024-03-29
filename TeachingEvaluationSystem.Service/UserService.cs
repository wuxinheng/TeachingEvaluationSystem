﻿using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TeachingEvaluationSystem.Comom;
using TeachingEvaluationSystem.DB;
using TeachingEvaluationSystem.DB.Entitys;
using TeachingEvaluationSystem.Service.Global;

namespace TeachingEvaluationSystem.Service
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

        public Task<Page<User>> GetPage(int index, int size)
        {
            var users = _dbContext.Set<User>().ToList().Take(size).Skip((index - 1) * size).ToList();
            Comom.Page<User> page = new Comom.Page<User>()
            {
                Index = index,
                Data = users,
                Size = size,
                Total = _dbContext.Users.Count(),
                TotalPgae = (int)Math.Ceiling(Convert.ToDouble(_dbContext.Users.Count()) / size),
            };
            return Task.FromResult(page);
        }

        public async Task<List<User>> GetUsers(int roleId, List<int> userIds)
        {
            var users = await _dbContext.Set<User>().Where(x => x.RoleId == roleId).Where(x => !userIds.Contains(x.Id)).ToListAsync();
            return users;
        }

        public Task<User> Get(int id)
        {
            var users = _dbContext.Set<User>().FirstOrDefault(x => x.Id == id);

            return Task.FromResult(users);
        }

        public async Task<bool> Detele(User user)
        {
            _dbContext.Set<User>().Remove(user);
            var count = await _dbContext.SaveChangesAsync();
            return count > 0;
        }

        public async Task<bool> Save(User user)
        {
            var dbuser = _dbContext.Set<User>().FirstOrDefault(x => x.Id == user.Id);
            if (dbuser == null)
            {
                dbuser = user;
                await _dbContext.Set<User>().AddAsync(dbuser);
            }
            else
            {
                _dbContext.Set<User>().Update(user);
            }
            var count = await _dbContext.SaveChangesAsync();
            return count > 0;
        }
    }
}
