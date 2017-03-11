using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.Interfaces
{
    public interface IQuestionRepository : IEFRepository<Question>
    {
        bool DeleteQuestion(Question question);
    }
}
