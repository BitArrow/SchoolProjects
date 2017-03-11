using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Models;

namespace DAL.Repositories
{
    public class QuestionAnswerRepository : EFRepository<QuestionAnswer>, IQuestionAnswerRepository
    {
        public QuestionAnswerRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public void LockQuestionAnswers(Question question)
        {
            var qa = DbSet.Where(x => x.QuestionId == question.QuestionId).ToList();

            foreach (var questionAnswer in qa)
            {
                questionAnswer.Locked = true;
            }
        }

        public List<QuestionAnswer> GetAllQuestionAnswersByQuestionId(Guid questionId)
        {
            return DbSet.Where(a => a.QuestionId == questionId).ToList();
        }
    }
}
