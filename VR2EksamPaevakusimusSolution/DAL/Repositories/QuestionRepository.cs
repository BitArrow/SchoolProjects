using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Models;

namespace DAL.Repositories
{
    public class QuestionRepository : EFRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public bool DeleteQuestion(Question question)
        {
            try
            {
                foreach (var questionAnswer in question.QuestionAnswers.ToArray())
                {
                    DeleteEntity(questionAnswer, DbContext.Set<QuestionAnswer>());
                }
                Delete(question);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void DeleteEntity(Object entity, DbSet dbSet)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                dbSet.Attach(entity);
                dbSet.Remove(entity);
            }
        }
    }
}
