using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUAClient.Models;
using WUAClient.Service;
using WUAClient.Service.Interface;

namespace WUAClient.ViewModels
{
    public class AddEditQuestionVM : BaseVM
    {
        private Question _question;
        private ObservableCollection<QuestionAnswer> _filteredQuestionAnswers;
        private IQuestionService _qService;
        private IQuestionAnswerService _qaService;

        public Question Question
        {
            get { return _question; }
            set { _question = value; }
        }

        public ObservableCollection<QuestionAnswer> FilteredQuestionAnswers
        {
            get { return _filteredQuestionAnswers; }
            set
            {
                _filteredQuestionAnswers = value;
                RaisePropertyChanged("FilteredQuestionAnswers");
            }
        }

        public AddEditQuestionVM()
        {
            _question = new Question();
            _filteredQuestionAnswers = new ObservableCollection<QuestionAnswer>();
            _qService = new QuestionSOAPService();
            _qaService = new QuestionAnswerSOAPService();
        }

        public async void LoadQuestionAnswers()
        {
            FilteredQuestionAnswers = await _qaService.findQuestionAnswersByQuestionId(_question.QuestionId);
        }

        public void Add()
        {
            Question.QuestionId = new Guid();
            _qService.addQuestion(Question);
        }

        public void SaveChanges()
        {
            _qService.updateQuestion(Question);
        }

        public void Delete()
        {
            _qService.deleteQuestion(Question);
        }
    }
}
