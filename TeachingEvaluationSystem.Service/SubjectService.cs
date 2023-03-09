using TeachingEvaluationSystem.DB;
using TeachingEvaluationSystem.DB.Entitys;
using TeachingEvaluationSystem.Service.Base;
using TeachingEvaluationSystem.Service.Global;
using TeachingEvaluationSystem.Service.Model;

namespace TeachingEvaluationSystem.Service
{
    public class SubjectService : BaseService<Subject>
    {
        public SubjectService(TeachingEvaluationSystemDB dbContext, GlobalInfo globalInfo) : base(dbContext, globalInfo)
        {
        }

        public Task<List<SubjectQuestionBank>> GetSubjectQuestionBanks(Subject subject)
        {
            var _subject = _dbContext.Subjects.FirstOrDefault(x => x.Id == subject.Id);
            var i = 1;
            var result = _subject.Questions.Select(x => new SubjectQuestionBank()
            {
                Sequence = i++,
                Score = x.Score,
                Title = x.QuestionBank.Tile,
                QuestionType = x.QuestionBank.QuestionType,
                OptionBanks = x.QuestionBank.OptionBanks,
                QuestionBank = x.QuestionBank,
            }).OrderBy(x => x.QuestionType.Id).ToList();
            return Task.FromResult(result);
        }
    }
}
