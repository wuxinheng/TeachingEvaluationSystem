using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TeachingEvaluationSystem.DB.Entitys;
using TeachingEvaluationSystem.DB;
using Microsoft.EntityFrameworkCore;
using TeachingEvaluationSystem.Service.Global;

namespace TeachingEvaluationSystem.Service
{
    public class QuestionTypeService
    {
        private readonly TeachingEvaluationSystemDB _dbContext;
        private readonly GlobalInfo _globalInfo;
        public QuestionTypeService(TeachingEvaluationSystemDB dbContext, GlobalInfo globalInfo)
        {
            _dbContext = dbContext;
            _globalInfo = globalInfo;
        }

        public Task<Comom.Page<QuestionType>> GetPage(int index, int size)
        {
            var questions = _dbContext.Set<QuestionType>().ToList().Take(size).Skip((index - 1) * size).ToList();
            Comom.Page<QuestionType> page = new Comom.Page<QuestionType>()
            {
                Index = index,
                Data = questions,
                Size = size,
                Total = _dbContext.Users.Count(),
                TotalPgae = (int)Math.Ceiling(Convert.ToDouble(_dbContext.Users.Count()) / size),
            };
            return Task.FromResult(page);
        }

        public Task<List<QuestionType>> GetList()
        {
            var questions = _dbContext.Set<QuestionType>().ToList();
            return Task.FromResult(questions);
        }


        public Task<QuestionType> Get(int id)
        {
            var questions = _dbContext.Set<QuestionType>().FirstOrDefault(x => x.Id == id);

            return Task.FromResult(questions);
        }

        public async Task<bool> Detele(QuestionType user)
        {
            _dbContext.Set<QuestionType>().Remove(user);
            var count = await _dbContext.SaveChangesAsync();
            return count > 0;
        }

        public async Task<bool> Save(QuestionType question)
        {
            var dbquestion =  _dbContext.Set<QuestionType>().FirstOrDefault(x => x.Id == question.Id);
            if (dbquestion == null)
            {
                dbquestion = question;
                await _dbContext.Set<QuestionType>().AddAsync(dbquestion);
            }
            else
            {
                _dbContext.Set<QuestionType>().Update(question);
            }
            var count = await _dbContext.SaveChangesAsync();
            return count > 0;
        }

        public async Task<bool> Save(List<QuestionType> questions)
        {
            foreach (var item in questions)
            {
                var dbquestion =  _dbContext.Set<QuestionType>().FirstOrDefault(x => x.Id == item.Id);
                if (dbquestion == null)
                {
                    dbquestion = item;
                    await _dbContext.Set<QuestionType>().AddAsync(dbquestion);
                }
                else
                {
                    _dbContext.Set<QuestionType>().Update(item);
                }

            }
            var count = await _dbContext.SaveChangesAsync();
            return count > 0;
        }
    }
}
