using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUAClient.Models;

namespace WUAClient.Service.Interface
{
    interface IQuestionService
    {
        Task<ObservableCollection<Question>> getAll();

        Task<Question> getById(Guid id);

        Task<ObservableCollection<Question>> findByTitle(string query);

        Task<ObservableCollection<Question>> findByDescription(string query);

        Task<Question> addQuestion(Question question);

        Task<Question> updateQuestion(Question question);

        Task<Question> deleteQuestion(Question question);
    }
}
