using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.Interfaces
{
    public interface IQuestionAnswerRepository : IEFRepository<QuestionAnswer>
    {
        void LockQuestionAnswers(Question question);
        List<QuestionAnswer> GetAllQuestionAnswersByQuestionId(Guid questionId);
    }
}
