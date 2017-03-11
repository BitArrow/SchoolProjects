using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WUAClient.Models;
using WUAClient.Service;
using WUAClient.Service.Interface;

namespace WUAClient.ViewModels
{
    public class MainPageVM : BaseVM
    {
        private ObservableCollection<Question> _filteredQuestions;
        private IQuestionService _service;

        public ObservableCollection<Question> FilteredQuestions
        {
            get { return _filteredQuestions; }
            private set
            {
                _filteredQuestions = value;
                RaisePropertyChanged("FilteredQuestions");
            }
        }

        private ObservableCollection<Question> _questions;

        public ObservableCollection<Question> Questions
        {
            get { return _questions; }
            set { _questions = value; }
        }


        public MainPageVM()
        {
            _filteredQuestions = new ObservableCollection<Question>();
            _questions = new ObservableCollection<Question>();
            _service = new QuestionSOAPService();
        }

        public async void LoadQuestions()
        {
            Questions = await _service.getAll();
            FilteredQuestions = Questions;
        }

        public void FindQuestionsByTitle(string title)
        {
            FilteredQuestions = new ObservableCollection<Question>(_questions.Where(t => t.Title.ToUpper().Contains(title.ToUpper())));
        }

        public void FindQuestionsByDescription(string desc)
        {
            FilteredQuestions = new ObservableCollection<Question>(_questions.Where(t => t.Description.ToUpper().Contains(desc.ToUpper())));
        }

        public void ClearFilter()
        {
            FilteredQuestions = Questions;
        }
    }
}
