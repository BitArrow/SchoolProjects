using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUAClient.Models;

namespace WUAClient.Service.Interface
{
    interface IQuestionAnswerService
    {
        Task<ObservableCollection<QuestionAnswer>> getAll();

        Task<QuestionAnswer> getQuestionAnswerById(Guid id);

        Task<ObservableCollection<QuestionAnswer>> findQuestionAnswersByTitle(string query);

        Task<ObservableCollection<QuestionAnswer>> findQuestionAnswersByQuestionId(Guid id);

        Task<QuestionAnswer> addQuestionAnswer(QuestionAnswer qAnswer);

        Task<QuestionAnswer> updateQuestionAnswer(QuestionAnswer qAnswer);

        Task<QuestionAnswer> deleteQuestionAnswer(QuestionAnswer qAnswer);
    }
}
