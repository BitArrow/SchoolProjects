using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUAClient.Models;
using WUAClient.Service.Interface;

namespace WUAClient.Service
{
    class QuestionSOAPService : IQuestionService
    {
        private DailyService.DailyServiceClient _client;

        public QuestionSOAPService()
        {
            _client = new DailyService.DailyServiceClient();
        }

        public async Task<ObservableCollection<Question>> getAll()
        {
            ObservableCollection<Question> questions = new ObservableCollection<Question>();
            var result = await _client.getAllQuestionsAsync();
            foreach (var questionDto in result)
            {
                questions.Add(Converter.convertToQuestion(questionDto));
            }

            return questions;
        }

        public async Task<Question> getById(Guid id)
        {
            return Converter.convertToQuestion(await _client.getQuestionByIdAsync(id));
        }

        public async Task<ObservableCollection<Question>> findByTitle(string query)
        {
            ObservableCollection<Question> questions = new ObservableCollection<Question>();
            var result = await _client.findQuestionByTitleAsync(query);
            foreach (var questionDto in result)
            {
                questions.Add(Converter.convertToQuestion(questionDto));
            }

            return questions;
        }

        public async Task<ObservableCollection<Question>> findByDescription(string query)
        {
            ObservableCollection<Question> questions = new ObservableCollection<Question>();
            var result = await _client.findQuestionByDescriptionAsync(query);
            foreach (var questionDto in result)
            {
                questions.Add(Converter.convertToQuestion(questionDto));
            }

            return questions;
        }

        public async Task<Question> addQuestion(Question question)
        {
            await _client.addQuestionAsync(Converter.convertToQuestionDTO(question));
            return null;
        }

        public async Task<Question> updateQuestion(Question question)
        {
            await _client.updateQuestionAsync(Converter.convertToQuestionDTO(question));
            return null;
        }

        public async Task<Question> deleteQuestion(Question question)
        {
            await _client.deleteQuestionAsync(Converter.convertToQuestionDTO(question));
            return null;
        }
    }
}
