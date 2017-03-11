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
    public class AddEditQuestionAnswerVM
    {
        private Question _question;
        private QuestionAnswer _qAnswer;
        private IQuestionAnswerService _service;

        public Question Question
        {
            get { return _question; }
            set { _question = value; }
        }

        public QuestionAnswer QuestionAnswer
        {
            get { return _qAnswer; }
            set { _qAnswer = value; }
        }

        public AddEditQuestionAnswerVM()
        {
            _question = new Question();
            _qAnswer = new QuestionAnswer();
            _service = new QuestionAnswerSOAPService();
        }

        public void Add()
        {
            QuestionAnswer.QuestionAnswerId = new Guid();
            QuestionAnswer.QuestionId = Question.QuestionId;
            _service.addQuestionAnswer(QuestionAnswer);
        }

        public void SaveChanges()
        {
            _service.updateQuestionAnswer(QuestionAnswer);
        }

        public void Delete()
        {
            _service.deleteQuestionAnswer(QuestionAnswer);
        }
    }
}
