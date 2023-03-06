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
    public class QuestionBankService
    {
        private readonly TeachingEvaluationSystemDB _dbContext;
        private readonly GlobalInfo _globalInfo;
        public QuestionBankService(TeachingEvaluationSystemDB dbContext, GlobalInfo globalInfo)
        {
            _dbContext = dbContext;
            _globalInfo = globalInfo;
        }

        public Task<Comom.Page<QuestionBank>> GetPage(int index, int size)
        {
            var questions = _dbContext.Set<QuestionBank>().ToList().Take(size).Skip((index - 1) * size).ToList();
            Comom.Page<QuestionBank> page = new Comom.Page<QuestionBank>()
            {
                Index = index,
                Data = questions,
                Size = size,
                Total = _dbContext.Users.Count(),
                TotalPgae = (int)Math.Ceiling(Convert.ToDouble(_dbContext.Users.Count()) / size),
            };
            return Task.FromResult(page);
        }

        public Task<List<QuestionBank>> GetList()
        {
            var questions = _dbContext.Set<QuestionBank>().ToList();
            for (int i = 0; i < questions.Count; i++)
            {
                questions[i].Sequence = i + 1;
            }
            return Task.FromResult(questions);
        }


        public async Task<QuestionBank> Get(int id)
        {
            var questions = await _dbContext.Set<QuestionBank>().FirstOrDefaultAsync(x => x.Id == id);

            return questions;
        }

        public async Task<bool> Detele(QuestionBank user)
        {
            _dbContext.Set<QuestionBank>().Remove(user);
            var count = await _dbContext.SaveChangesAsync();
            return count > 0;
        }

        public async Task<bool> Save(QuestionBank question)
        {
            var dbquestion = await _dbContext.Set<QuestionBank>().FirstOrDefaultAsync(x => x.Id == question.Id);
            if (dbquestion == null)
            {
                dbquestion = question;
                await _dbContext.Set<QuestionBank>().AddAsync(dbquestion);
            }
            else
            {
                _dbContext.Set<QuestionBank>().Update(question);
            }
            var count = await _dbContext.SaveChangesAsync();
            return count > 0;
        }

        public async Task<bool> Save(List<QuestionBank> questions)
        {
            try
            {

            
            foreach (var item in questions)
            {
                var dbquestion = await _dbContext.Set<QuestionBank>().FirstOrDefaultAsync(x => x.Id == item.Id);
                if (dbquestion == null)
                {
                    dbquestion = item;
                    await _dbContext.Set<QuestionBank>().AddAsync(dbquestion);
                }
                else
                {
                    _dbContext.Set<QuestionBank>().Update(item);
                }

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
