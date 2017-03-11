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
    public class AllQuestionAnswersVM :BaseVM
    {
        private ObservableCollection<QuestionAnswer> _questions;
        private IQuestionAnswerService _service;
        private ObservableCollection<QuestionAnswer> _filteredQuestions;

        public ObservableCollection<QuestionAnswer> Questions
        {
            get { return _questions; }
            set { _questions = value; }
        }
        

        public ObservableCollection<QuestionAnswer> FilteredQuestions
        {
            get { return _filteredQuestions; }
            set
            {
                _filteredQuestions = value;
                RaisePropertyChanged("FilteredQuestions");
            }
        }


        public AllQuestionAnswersVM()
        {
            _questions = new ObservableCollection<QuestionAnswer>();
            _filteredQuestions = new ObservableCollection<QuestionAnswer>();
            _service = new QuestionAnswerSOAPService();
        }

        public void FilterByTitle(string title)
        {
            FilteredQuestions = new ObservableCollection<QuestionAnswer>(_questions.Where(t => t.Title.ToUpper().Contains(title.ToUpper())));
        }

        public void ClearFilter()
        {
            FilteredQuestions = Questions;
        }

        public async void LoadAllQuestionAnswers()
        {
            Questions = await _service.getAll();
            FilteredQuestions = Questions;
        }
    }
}
